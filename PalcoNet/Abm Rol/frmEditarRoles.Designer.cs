namespace PalcoNet.Abm_Rol
{
    partial class frmEditarRoles
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nombre_Label = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.chkListFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.chkusuario_activo = new System.Windows.Forms.CheckBox();
            this.Funcionalidades_Label = new System.Windows.Forms.Label();
            this.Habilitado_Label = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nombre_Label);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.chkListFuncionalidades);
            this.groupBox1.Controls.Add(this.chkusuario_activo);
            this.groupBox1.Controls.Add(this.Funcionalidades_Label);
            this.groupBox1.Controls.Add(this.Habilitado_Label);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(378, 265);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione las funcionalidades:";
            // 
            // nombre_Label
            // 
            this.nombre_Label.AutoSize = true;
            this.nombre_Label.Location = new System.Drawing.Point(8, 41);
            this.nombre_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nombre_Label.Name = "nombre_Label";
            this.nombre_Label.Size = new System.Drawing.Size(58, 17);
            this.nombre_Label.TabIndex = 0;
            this.nombre_Label.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(127, 41);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(230, 22);
            this.txtnombre.TabIndex = 1;
            // 
            // chkListFuncionalidades
            // 
            this.chkListFuncionalidades.FormattingEnabled = true;
            this.chkListFuncionalidades.Location = new System.Drawing.Point(127, 86);
            this.chkListFuncionalidades.Margin = new System.Windows.Forms.Padding(4);
            this.chkListFuncionalidades.Name = "chkListFuncionalidades";
            this.chkListFuncionalidades.Size = new System.Drawing.Size(230, 123);
            this.chkListFuncionalidades.TabIndex = 2;
            // 
            // chkusuario_activo
            // 
            this.chkusuario_activo.AutoSize = true;
            this.chkusuario_activo.Location = new System.Drawing.Point(127, 226);
            this.chkusuario_activo.Margin = new System.Windows.Forms.Padding(4);
            this.chkusuario_activo.Name = "chkusuario_activo";
            this.chkusuario_activo.Size = new System.Drawing.Size(18, 17);
            this.chkusuario_activo.TabIndex = 3;
            this.chkusuario_activo.UseVisualStyleBackColor = true;
            // 
            // Funcionalidades_Label
            // 
            this.Funcionalidades_Label.AutoSize = true;
            this.Funcionalidades_Label.Location = new System.Drawing.Point(8, 86);
            this.Funcionalidades_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Funcionalidades_Label.Name = "Funcionalidades_Label";
            this.Funcionalidades_Label.Size = new System.Drawing.Size(111, 17);
            this.Funcionalidades_Label.TabIndex = 3;
            this.Funcionalidades_Label.Text = "Funcionalidades";
            // 
            // Habilitado_Label
            // 
            this.Habilitado_Label.AutoSize = true;
            this.Habilitado_Label.Location = new System.Drawing.Point(8, 226);
            this.Habilitado_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Habilitado_Label.Name = "Habilitado_Label";
            this.Habilitado_Label.Size = new System.Drawing.Size(71, 17);
            this.Habilitado_Label.TabIndex = 4;
            this.Habilitado_Label.Text = "Habilitado";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(291, 286);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(183, 286);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmEditarRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 339);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmEditarRoles";
            this.Text = "frmEditarRoles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nombre_Label;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.CheckedListBox chkListFuncionalidades;
        private System.Windows.Forms.CheckBox chkusuario_activo;
        private System.Windows.Forms.Label Funcionalidades_Label;
        private System.Windows.Forms.Label Habilitado_Label;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}