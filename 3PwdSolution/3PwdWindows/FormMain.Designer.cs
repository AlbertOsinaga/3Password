
namespace _3PwdWindows
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxCuentas = new System.Windows.Forms.ListBox();
            this.lblVersionMasterFile = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnShowPwd = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuentas";
            // 
            // lbxCuentas
            // 
            this.lbxCuentas.FormattingEnabled = true;
            this.lbxCuentas.ItemHeight = 15;
            this.lbxCuentas.Location = new System.Drawing.Point(32, 63);
            this.lbxCuentas.Name = "lbxCuentas";
            this.lbxCuentas.Size = new System.Drawing.Size(148, 319);
            this.lbxCuentas.TabIndex = 1;
            this.lbxCuentas.SelectedIndexChanged += new System.EventHandler(this.lbxCuentas_SelectedIndexChanged);
            // 
            // lblVersionMasterFile
            // 
            this.lblVersionMasterFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersionMasterFile.AutoSize = true;
            this.lblVersionMasterFile.Location = new System.Drawing.Point(374, 9);
            this.lblVersionMasterFile.Name = "lblVersionMasterFile";
            this.lblVersionMasterFile.Size = new System.Drawing.Size(30, 15);
            this.lblVersionMasterFile.TabIndex = 2;
            this.lblVersionMasterFile.Text = "V/M";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(374, 32);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(18, 15);
            this.lblMensaje.TabIndex = 3;
            this.lblMensaje.Text = "M";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnShowPwd);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblCuenta);
            this.panel1.Location = new System.Drawing.Point(196, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 319);
            this.panel1.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(277, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(188, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(24, 286);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnShowPwd
            // 
            this.btnShowPwd.Location = new System.Drawing.Point(308, 87);
            this.btnShowPwd.Name = "btnShowPwd";
            this.btnShowPwd.Size = new System.Drawing.Size(44, 23);
            this.btnShowPwd.TabIndex = 5;
            this.btnShowPwd.Tag = "";
            this.btnShowPwd.Text = "<o>";
            this.toolTip1.SetToolTip(this.btnShowPwd, "Mostrar");
            this.btnShowPwd.UseVisualStyleBackColor = true;
            this.btnShowPwd.Click += new System.EventHandler(this.btnShowPwd_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Enabled = false;
            this.txtPwd.Location = new System.Drawing.Point(103, 87);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.ReadOnly = true;
            this.txtPwd.Size = new System.Drawing.Size(199, 23);
            this.txtPwd.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(103, 54);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(199, 23);
            this.txtId.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Id o Usuario:";
            // 
            // lblCuenta
            // 
            this.lblCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblCuenta.ForeColor = System.Drawing.Color.White;
            this.lblCuenta.Location = new System.Drawing.Point(136, 19);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(45, 15);
            this.lblCuenta.TabIndex = 0;
            this.lblCuenta.Text = "Cuenta";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(566, 63);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblVersionMasterFile);
            this.Controls.Add(this.lbxCuentas);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3Password";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxCuentas;
        private System.Windows.Forms.Label lblVersionMasterFile;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Button btnShowPwd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}