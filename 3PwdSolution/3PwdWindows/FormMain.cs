using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace _3PwdWindows
{
    public partial class FormMain : Form
    {
        #region Propiedades

        List<RegistroPwd> Pwds { get; set; } = new List<RegistroPwd>();

        #endregion

        public FormMain()
        {
            InitializeComponent();
            Init3Password();
            LoadPwds();
        }

        private void Init3Password()
        {
            lblMensaje.Text = "";
            G.ConfigurationRoot = Config();
            G.Logger = Log.Logger;
            MR.DirMaestro = G.ConfigurationRoot.GetValue<string>("DirMasterFile");
            lblVersionMasterFile.Text = $"3Password   V:{G.Version}  MasterFile:{MR.PathMaestro}";

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
        }

        private void lbxCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCuenta.Text = (lbxCuentas.SelectedItem as RegistroPwd).Producto;
            txtId.Text = (lbxCuentas.SelectedItem as RegistroPwd).UserId;
            txtPwd.Text = "**********";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void btnShowPwd_Click(object sender, EventArgs e)
        {
            txtPwd.Text = (lbxCuentas.SelectedItem as RegistroPwd).UserPwd;
        }
    }
}
