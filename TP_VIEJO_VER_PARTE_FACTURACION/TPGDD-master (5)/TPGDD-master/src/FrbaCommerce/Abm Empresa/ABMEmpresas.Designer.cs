﻿namespace FrbaCommerce.Abm_Empresa
{
    partial class ABMEmpresas
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
            this.registrar = new System.Windows.Forms.Button();
            this.tNombreDeContacto = new System.Windows.Forms.TextBox();
            this.tCuit = new System.Windows.Forms.TextBox();
            this.tCiudad = new System.Windows.Forms.TextBox();
            this.tCodigoPostal = new System.Windows.Forms.TextBox();
            this.tDireccion = new System.Windows.Forms.TextBox();
            this.tTelefono = new System.Windows.Forms.TextBox();
            this.tEmail = new System.Windows.Forms.TextBox();
            this.tRazonSocial = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buscar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.tBusqueda = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.registrar);
            this.groupBox1.Controls.Add(this.tNombreDeContacto);
            this.groupBox1.Controls.Add(this.tCuit);
            this.groupBox1.Controls.Add(this.tCiudad);
            this.groupBox1.Controls.Add(this.tCodigoPostal);
            this.groupBox1.Controls.Add(this.tDireccion);
            this.groupBox1.Controls.Add(this.tTelefono);
            this.groupBox1.Controls.Add(this.tEmail);
            this.groupBox1.Controls.Add(this.tRazonSocial);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(400, 363);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nueva empresa";
            // 
            // registrar
            // 
            this.registrar.Location = new System.Drawing.Point(187, 316);
            this.registrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(203, 37);
            this.registrar.TabIndex = 8;
            this.registrar.Text = "Registrar";
            this.registrar.UseVisualStyleBackColor = true;
            this.registrar.Click += new System.EventHandler(this.registrar_Click);
            // 
            // tNombreDeContacto
            // 
            this.tNombreDeContacto.Location = new System.Drawing.Point(187, 279);
            this.tNombreDeContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tNombreDeContacto.MaxLength = 50;
            this.tNombreDeContacto.Name = "tNombreDeContacto";
            this.tNombreDeContacto.Size = new System.Drawing.Size(201, 22);
            this.tNombreDeContacto.TabIndex = 7;
            this.tNombreDeContacto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNoNumerico_KeyPress);
            // 
            // tCuit
            // 
            this.tCuit.Location = new System.Drawing.Point(187, 242);
            this.tCuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tCuit.MaxLength = 50;
            this.tCuit.Name = "tCuit";
            this.tCuit.Size = new System.Drawing.Size(201, 22);
            this.tCuit.TabIndex = 6;
            // 
            // tCiudad
            // 
            this.tCiudad.Location = new System.Drawing.Point(187, 206);
            this.tCiudad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tCiudad.MaxLength = 50;
            this.tCiudad.Name = "tCiudad";
            this.tCiudad.Size = new System.Drawing.Size(201, 22);
            this.tCiudad.TabIndex = 5;
            // 
            // tCodigoPostal
            // 
            this.tCodigoPostal.Location = new System.Drawing.Point(187, 169);
            this.tCodigoPostal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tCodigoPostal.MaxLength = 50;
            this.tCodigoPostal.Name = "tCodigoPostal";
            this.tCodigoPostal.Size = new System.Drawing.Size(201, 22);
            this.tCodigoPostal.TabIndex = 4;
            this.tCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // tDireccion
            // 
            this.tDireccion.Location = new System.Drawing.Point(187, 132);
            this.tDireccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tDireccion.MaxLength = 255;
            this.tDireccion.Name = "tDireccion";
            this.tDireccion.Size = new System.Drawing.Size(201, 22);
            this.tDireccion.TabIndex = 3;
            // 
            // tTelefono
            // 
            this.tTelefono.Location = new System.Drawing.Point(187, 95);
            this.tTelefono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tTelefono.MaxLength = 18;
            this.tTelefono.Name = "tTelefono";
            this.tTelefono.Size = new System.Drawing.Size(201, 22);
            this.tTelefono.TabIndex = 2;
            this.tTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumerico_KeyPress);
            // 
            // tEmail
            // 
            this.tEmail.Location = new System.Drawing.Point(187, 58);
            this.tEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tEmail.MaxLength = 50;
            this.tEmail.Name = "tEmail";
            this.tEmail.Size = new System.Drawing.Size(201, 22);
            this.tEmail.TabIndex = 1;
            // 
            // tRazonSocial
            // 
            this.tRazonSocial.Location = new System.Drawing.Point(187, 21);
            this.tRazonSocial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tRazonSocial.MaxLength = 255;
            this.tRazonSocial.Name = "tRazonSocial";
            this.tRazonSocial.Size = new System.Drawing.Size(201, 22);
            this.tRazonSocial.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 327);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "(*) = Campo obligatorio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Teléfono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Dirección (*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 172);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Código postal (*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 283);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nombre de contacto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 209);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ciudad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 62);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "E-mail (*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Razón Social (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "CUIT (*)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buscar);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbFiltro);
            this.groupBox2.Controls.Add(this.tBusqueda);
            this.groupBox2.Location = new System.Drawing.Point(13, 382);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(400, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Baja o modificación de empresas";
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(317, 46);
            this.buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(73, 37);
            this.buscar.TabIndex = 2;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Filtrar por:";
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(15, 53);
            this.cbFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(108, 24);
            this.cbFiltro.TabIndex = 0;
            // 
            // tBusqueda
            // 
            this.tBusqueda.Location = new System.Drawing.Point(136, 53);
            this.tBusqueda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBusqueda.Name = "tBusqueda";
            this.tBusqueda.Size = new System.Drawing.Size(172, 22);
            this.tBusqueda.TabIndex = 1;
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(13, 481);
            this.back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(113, 37);
            this.back.TabIndex = 0;
            this.back.Text = "<< Volver";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(300, 482);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(113, 37);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ABMEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 534);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.back);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ABMEmpresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Empresas - MercadoNegro";
            this.Load += new System.EventHandler(this.ABMEmpresas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tRazonSocial;
        private System.Windows.Forms.TextBox tNombreDeContacto;
        private System.Windows.Forms.TextBox tCuit;
        private System.Windows.Forms.TextBox tCiudad;
        private System.Windows.Forms.TextBox tCodigoPostal;
        private System.Windows.Forms.TextBox tDireccion;
        private System.Windows.Forms.TextBox tTelefono;
        private System.Windows.Forms.TextBox tEmail;
        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.TextBox tBusqueda;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button btnLimpiar;
    }
}