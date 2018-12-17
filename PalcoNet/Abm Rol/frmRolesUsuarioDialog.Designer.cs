namespace PalcoNet.Abm_Rol
{
    partial class frmRolesUsuarioDialog
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsuarionombre = new System.Windows.Forms.TextBox();
            this.lblIdUser = new System.Windows.Forms.Label();
            this.txtusuario_id = new System.Windows.Forms.TextBox();
            this.cblRoles = new System.Windows.Forms.CheckedListBox();
            this.lblRoles = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancelar.Location = new System.Drawing.Point(153, 301);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(261, 301);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Controls.Add(this.txtUsuarionombre);
            this.groupBox1.Controls.Add(this.lblIdUser);
            this.groupBox1.Controls.Add(this.txtusuario_id);
            this.groupBox1.Controls.Add(this.cblRoles);
            this.groupBox1.Controls.Add(this.lblRoles);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(363, 265);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asigne los roles al Usuario:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(8, 47);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(115, 17);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Nombre Usuario:";
            // 
            // txtUsuarionombre
            // 
            this.txtUsuarionombre.Location = new System.Drawing.Point(131, 43);
            this.txtUsuarionombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuarionombre.Name = "txtUsuarionombre";
            this.txtUsuarionombre.ReadOnly = true;
            this.txtUsuarionombre.Size = new System.Drawing.Size(217, 22);
            this.txtUsuarionombre.TabIndex = 9;
            // 
            // lblIdUser
            // 
            this.lblIdUser.AutoSize = true;
            this.lblIdUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdUser.Location = new System.Drawing.Point(8, 79);
            this.lblIdUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdUser.Name = "lblIdUser";
            this.lblIdUser.Size = new System.Drawing.Size(78, 17);
            this.lblIdUser.TabIndex = 4;
            this.lblIdUser.Text = "ID Usuario:";
            // 
            // txtusuario_id
            // 
            this.txtusuario_id.Location = new System.Drawing.Point(93, 79);
            this.txtusuario_id.Margin = new System.Windows.Forms.Padding(4);
            this.txtusuario_id.Name = "txtusuario_id";
            this.txtusuario_id.ReadOnly = true;
            this.txtusuario_id.Size = new System.Drawing.Size(255, 22);
            this.txtusuario_id.TabIndex = 5;
            // 
            // cblRoles
            // 
            this.cblRoles.FormattingEnabled = true;
            this.cblRoles.Location = new System.Drawing.Point(93, 111);
            this.cblRoles.Margin = new System.Windows.Forms.Padding(4);
            this.cblRoles.Name = "cblRoles";
            this.cblRoles.Size = new System.Drawing.Size(255, 140);
            this.cblRoles.TabIndex = 1;
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoles.Location = new System.Drawing.Point(8, 111);
            this.lblRoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(48, 17);
            this.lblRoles.TabIndex = 7;
            this.lblRoles.Text = "Roles:";
            // 
            // frmRolesUsuarioDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 342);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRolesUsuarioDialog";
            this.Text = "frmRolesUsuarioDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsuarionombre;
        private System.Windows.Forms.TextBox txtusuario_id;
        private System.Windows.Forms.CheckedListBox cblRoles;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Label lblIdUser;
    }
}