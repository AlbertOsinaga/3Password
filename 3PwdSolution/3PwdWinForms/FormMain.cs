using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _3PwdLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using G = _3PwdLibrary.Global;
using MR = _3PwdLibrary.ManejadorRegistros;
using PC = _3PwdLibrary.ProcesadorComandos;

namespace _3PwdWinForms
{
    public partial class FormMain : Form
    {
        #region Propiedades

        List<RegistroPwd> Pwds { get; set; }

        public string NuevaCuenta { get; set; } = "";

        #endregion

        # region Metodos

        private void Init3Password()
        {
            lblMensaje.Text = "";
            G.ConfigurationRoot = Config();
            G.Logger = Log.Logger;
            MR.DirMaestro = G.ConfigurationRoot.GetValue<string>("DirMasterFile");
            lblMensaje.Text = $"3Password   V:{G.Version}  MasterFile:{MR.PathMaestro}";

            #region Functions

            // Construye el configurador appsettings
            void BuildConfig(IConfigurationBuilder builder)

            {
                builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                    .AddEnvironmentVariables();
            }

            // Config Settings & Logging
            IConfigurationRoot Config()
            {
                var builder = new ConfigurationBuilder();
                BuildConfig(builder);
                var configRoot = builder.Build();
                //Bienvenida.Config = configRoot;

                Log.Logger = new LoggerConfiguration()
                    //.ReadFrom.Configuration(builder.Build())
                    .ReadFrom.Configuration(configRoot)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

                //Log.Logger.Information("Application Starting");
                //Bienvenida.Logger = Log.Logger;

                Host.CreateDefaultBuilder()
                    //.ConfigureServices((context, services) =>
                    //{
                    //    services.AddTransient<IGreetingService, GreetingService>();
                    //})
                    .UseSerilog()
                    .Build();

                return configRoot;
            }

            #endregion
        }

        private void LoadPwds()
        {
            Pwds = new List<RegistroPwd>();
            var respuesta = PC.Run("all");
            if (string.IsNullOrEmpty(respuesta))
                return;
            if (respuesta[0].IsSymbol() && respuesta[0] != G.SeparadorCSV[0])
            {
                lblMensaje.Text = respuesta;
                return;
            }

            var rows = respuesta.Split((char)10, (char)13);
            foreach (var row in rows)
            {
                if(!string.IsNullOrEmpty(row))
                {
                    var regPwd = MR.RowToRegistroPwd(row);
                    if(regPwd != null)
                        Pwds.Add(regPwd);
                }
            }
            lbxCuentas.DataSource = Pwds;
            lbxCuentas.DisplayMember = "Producto";
            lbxCuentas.ValueMember = "Producto";
            lbxCuentas.Refresh();
            lbxCuentas.Focus();
        }

        #endregion

        #region Metodos Windows 

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Init3Password();
            LoadPwds();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtId.ReadOnly = true;
            txtPwd.Enabled = false;
            txtPwd.ReadOnly = true;
            lbxCuentas.Enabled = true;

            btnNew.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnShowPwd.Visible = true;
            btnShowPwd.Text = "<o>";
            btnCopy.Visible = true;
            lblEdit.Visible = false;
            pnlInfo.BackColor = Color.WhiteSmoke;

            txtPwd.Text = "****************";
            lbxCuentas.Focus();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var regPwd = lbxCuentas.SelectedItem as RegistroPwd;
            Clipboard.SetData(DataFormats.Text, regPwd.UserPwd);
            MessageBox.Show("Copiado al clipboard!", "OK", MessageBoxButtons.OK);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Desea borrar registro: '{lblCuenta.Text}'?", "CONFIRMACION", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;

            var cmd = "del";

            cmd += lbxCuentas.SelectedValue != null ? (" -cta " + (lbxCuentas.SelectedValue as string).Trim()) : "";
            var respuesta = PC.Run(cmd);

            if (respuesta[0].IsSymbol() && respuesta[0] != G.SeparadorCSV[0]
                    && !(respuesta == "*** Registro borrado! ***"))
            {
                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show(respuesta, "OK", MessageBoxButtons.OK);
            LoadPwds();
            btnCancel_Click(btnSave, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            txtId.ReadOnly = false;
            txtPwd.Enabled = true;
            txtPwd.ReadOnly = false;
            lbxCuentas.Enabled = false;

            btnNew.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = true;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnCopy.Visible = false;
            btnShowPwd.Visible = false;
            lblEdit.Visible = true;
            pnlInfo.BackColor = Color.Gainsboro;

            txtPwd.Text = (lbxCuentas.SelectedItem as RegistroPwd).UserPwd;
            txtPwd.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lbxCuentas.SelectedIndex = -1;
            var frm = new FormNew();
            frm.ShowDialog();
            LoadPwds();
            var regPwdNew = Pwds.Where(r => r.Producto == NuevaCuenta).FirstOrDefault();
            if (!(regPwdNew is null))
                lbxCuentas.SelectedValue = regPwdNew.Producto;
            else
                lbxCuentas.SelectedIndex = 0;
        }

        private void btnShowPwd_Click(object sender, EventArgs e)
        {
            if (btnShowPwd.Text[0] == '<')
            {
                txtPwd.Text = (lbxCuentas.SelectedItem as RegistroPwd).UserPwd;
                btnShowPwd.Text = "[]";
            }
            else
            {
                txtPwd.Text = "****************";
                btnShowPwd.Text = "<o>";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int indexSelected = lbxCuentas.SelectedIndex;

            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtPwd.Text))
            {
                var result = MessageBox.Show("Usuario o Password en blanco!\nDesea salvar así esta cuenta?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }

            var cmd = "upd";

            var regPwd = lbxCuentas.SelectedItem as RegistroPwd;

            cmd += regPwd != null ? (" -nom " + regPwd.UserNombre.Trim()) : "";
            cmd += regPwd != null ? (" -cat " + regPwd.Categoria.Trim()) : "";
            cmd += regPwd != null ? (" -emp " + regPwd.Empresa.Trim()) : "";
            cmd += regPwd != null ? (" -cta " + regPwd.Producto.Trim()) : "";
            cmd += regPwd != null ? (" -nro " + regPwd.Numero.Trim()) : "";
            cmd += !string.IsNullOrEmpty(txtId.Text) ? (" -uid " + txtId.Text.Trim()) : "";
            cmd += !string.IsNullOrEmpty(txtPwd.Text) ? (" -pwd " + txtPwd.Text.Trim()) : "";
            var respuesta = PC.Run(cmd);

            if (respuesta[0].IsSymbol() && respuesta[0] != G.SeparadorCSV[0])
            {
                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK);
                return;
            }

            LoadPwds();
            lbxCuentas.SelectedIndex = indexSelected;
            btnCancel_Click(btnSave, null);
        }

        private void lbxCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxCuentas.SelectedIndex < 0)
                return;

            lblCuenta.Text = (lbxCuentas.SelectedItem as RegistroPwd).Producto;
            txtId.Text = (lbxCuentas.SelectedItem as RegistroPwd).UserId;
            txtPwd.Text = "****************";
            btnShowPwd.Text = "<o>";
        }

        #endregion
    }
}
