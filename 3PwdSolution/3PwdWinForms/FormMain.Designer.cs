
namespace _3PwdWinForms
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
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEdit = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnShowPwd = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.toolTipShow = new System.Windows.Forms.ToolTip(this.components);
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuentas";
            // 
            // lbxCuentas
            // 
            this.lbxCuentas.BackColor = System.Drawing.Color.Gray;
            this.lbxCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxCuentas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbxCuentas.ForeColor = System.Drawing.Color.White;
            this.lbxCuentas.FormattingEnabled = true;
            this.lbxCuentas.ItemHeight = 20;
            this.lbxCuentas.Location = new System.Drawing.Point(12, 51);
            this.lbxCuentas.Name = "lbxCuentas";
            this.lbxCuentas.Size = new System.Drawing.Size(144, 380);
            this.lbxCuentas.TabIndex = 1;
            this.lbxCuentas.SelectedIndexChanged += new System.EventHandler(this.lbxCuentas_SelectedIndexChanged);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMensaje.Location = new System.Drawing.Point(12, 444);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(521, 19);
            this.lblMensaje.TabIndex = 3;
            this.lblMensaje.Text = "M";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.txtNotas);
            this.pnlInfo.Controls.Add(this.txtWeb);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.groupBox1);
            this.pnlInfo.Controls.Add(this.lblEdit);
            this.pnlInfo.Controls.Add(this.btnCopy);
            this.pnlInfo.Controls.Add(this.btnNew);
            this.pnlInfo.Controls.Add(this.btnEdit);
            this.pnlInfo.Controls.Add(this.btnSave);
            this.pnlInfo.Controls.Add(this.btnCancel);
            this.pnlInfo.Controls.Add(this.btnDelete);
            this.pnlInfo.Controls.Add(this.btnShowPwd);
            this.pnlInfo.Controls.Add(this.txtPwd);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.txtId);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Controls.Add(this.lblCuenta);
            this.pnlInfo.Location = new System.Drawing.Point(157, 27);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(504, 403);
            this.pnlInfo.TabIndex = 4;
            // 
            // txtNotas
            // 
            this.txtNotas.Enabled = false;
            this.txtNotas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNotas.Location = new System.Drawing.Point(150, 256);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(302, 72);
            this.txtNotas.TabIndex = 24;
            // 
            // txtWeb
            // 
            this.txtWeb.Enabled = false;
            this.txtWeb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtWeb.Location = new System.Drawing.Point(150, 223);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(302, 27);
            this.txtWeb.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(93, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Notas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(54, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Página Web:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(25, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 4);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEdit.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEdit.ForeColor = System.Drawing.Color.DimGray;
            this.lblEdit.Location = new System.Drawing.Point(22, 16);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(88, 27);
            this.lblEdit.TabIndex = 11;
            this.lblEdit.Text = "EDICION";
            this.lblEdit.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCopy.Location = new System.Drawing.Point(441, 139);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(45, 27);
            this.btnCopy.TabIndex = 10;
            this.btnCopy.Tag = "";
            this.btnCopy.Text = "cop";
            this.toolTipShow.SetToolTip(this.btnCopy, "Copiar");
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNew.Location = new System.Drawing.Point(330, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 29);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Nueva";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.Location = new System.Drawing.Point(411, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 29);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(411, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(330, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(18, 350);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnShowPwd
            // 
            this.btnShowPwd.BackColor = System.Drawing.Color.Gainsboro;
            this.btnShowPwd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowPwd.Location = new System.Drawing.Point(395, 139);
            this.btnShowPwd.Name = "btnShowPwd";
            this.btnShowPwd.Size = new System.Drawing.Size(45, 27);
            this.btnShowPwd.TabIndex = 5;
            this.btnShowPwd.Tag = "";
            this.btnShowPwd.Text = "<o>";
            this.toolTipShow.SetToolTip(this.btnShowPwd, "Mostrar");
            this.btnShowPwd.UseVisualStyleBackColor = false;
            this.btnShowPwd.Click += new System.EventHandler(this.btnShowPwd_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Enabled = false;
            this.txtPwd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPwd.Location = new System.Drawing.Point(150, 139);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(239, 27);
            this.txtPwd.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(21, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Clave (Password):";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Location = new System.Drawing.Point(150, 106);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(239, 27);
            this.txtId.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(55, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Usuario (Id):";
            // 
            // lblCuenta
            // 
            this.lblCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.BackColor = System.Drawing.Color.Gray;
            this.lblCuenta.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCuenta.ForeColor = System.Drawing.Color.White;
            this.lblCuenta.Location = new System.Drawing.Point(21, 59);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(72, 25);
            this.lblCuenta.TabIndex = 0;
            this.lblCuenta.Text = "Cuenta";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(672, 462);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lbxCuentas);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3Password";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxCuentas;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel pnlInfo;
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
        private System.Windows.Forms.ToolTip toolTipShow;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblEdit;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}