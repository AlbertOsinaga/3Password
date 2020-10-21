using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _3PwdLibrary;
using G = _3PwdLibrary.Global;
using PC = _3PwdLibrary.ProcesadorComandos;

namespace _3PwdWinForms
{
    public partial class FormNew : Form
    {
        #region Metodos Windows
        
        public FormNew()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCuenta.Text))
            {
                var Ok = MessageBox.Show("Cuenta no puede ser blanco", "", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtUserId.Text) || string.IsNullOrEmpty(txtPwd.Text))
            {
                var result = MessageBox.Show("Usuario o Password en blanco!\nDesea salvar así esta cuenta?", "", MessageBoxButtons.YesNo);
                if(result == DialogResult.No)
                    return;
            }

            var cmd = "add";
            cmd += !string.IsNullOrEmpty(txtCuenta.Text) ? (" -cta " + txtCuenta.Text.Trim()) : "";
            cmd += !string.IsNullOrEmpty(txtUserId.Text) ? (" -uid " + txtUserId.Text.Trim()) : "";
            cmd += !string.IsNullOrEmpty(txtPwd.Text) ? (" -pwd " + txtPwd.Text.Trim()) : "";
            cmd += !string.IsNullOrEmpty(txtWeb.Text) ? (" -web " + txtWeb.Text.Trim()) : "";
            cmd += !string.IsNullOrEmpty(txtNotas.Text) ? (" -not " + txtNotas.Text.Trim()) : "";
            var respuesta = PC.Run(cmd);
            
            if(respuesta[0].IsSymbol() && respuesta[0] != G.SeparadorCSV[0])
            {
                var Ok = MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK);
                return;
            }

            Program.FrmMain.NuevaCuenta = txtCuenta.Text;
            Close();
        }

        #endregion
    }
}
