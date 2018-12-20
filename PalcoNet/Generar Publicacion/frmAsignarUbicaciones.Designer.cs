namespace PalcoNet.Generar_Publicacion
{
    partial class frmAsignarUbicaciones
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbTipoUbicaciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbNumeradas = new System.Windows.Forms.CheckBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFilasInicial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAsientosFinal = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFilasFinal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAsientosInicial = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(906, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(906, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 59);
            this.button2.TabIndex = 1;
            this.button2.Text = "Confirmar ubicaciones";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbTipoUbicaciones
            // 
            this.cmbTipoUbicaciones.FormattingEnabled = true;
            this.cmbTipoUbicaciones.Location = new System.Drawing.Point(49, 100);
            this.cmbTipoUbicaciones.Name = "cmbTipoUbicaciones";
            this.cmbTipoUbicaciones.Size = new System.Drawing.Size(139, 28);
            this.cmbTipoUbicaciones.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de ubicaciones";
            // 
            // chbNumeradas
            // 
            this.chbNumeradas.AutoSize = true;
            this.chbNumeradas.Location = new System.Drawing.Point(311, 102);
            this.chbNumeradas.Name = "chbNumeradas";
            this.chbNumeradas.Size = new System.Drawing.Size(117, 24);
            this.chbNumeradas.TabIndex = 4;
            this.chbNumeradas.Text = "Numeradas";
            this.chbNumeradas.UseVisualStyleBackColor = true;
            this.chbNumeradas.CheckedChanged += new System.EventHandler(this.chbNumeradas_CheckedChanged);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(554, 100);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 26);
            this.txtCantidad.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Filas";
            // 
            // cmbFilasInicial
            // 
            this.cmbFilasInicial.FormattingEnabled = true;
            this.cmbFilasInicial.Location = new System.Drawing.Point(49, 225);
            this.cmbFilasInicial.Name = "cmbFilasInicial";
            this.cmbFilasInicial.Size = new System.Drawing.Size(139, 28);
            this.cmbFilasInicial.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(650, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Asientos";
            // 
            // cmbAsientosFinal
            // 
            this.cmbAsientosFinal.FormattingEnabled = true;
            this.cmbAsientosFinal.Location = new System.Drawing.Point(710, 225);
            this.cmbAsientosFinal.Name = "cmbAsientosFinal";
            this.cmbAsientosFinal.Size = new System.Drawing.Size(139, 28);
            this.cmbAsientosFinal.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Inicial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Final";
            // 
            // cmbFilasFinal
            // 
            this.cmbFilasFinal.FormattingEnabled = true;
            this.cmbFilasFinal.Location = new System.Drawing.Point(226, 225);
            this.cmbFilasFinal.Name = "cmbFilasFinal";
            this.cmbFilasFinal.Size = new System.Drawing.Size(139, 28);
            this.cmbFilasFinal.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(758, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Final";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(581, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Inicial";
            // 
            // cmbAsientosInicial
            // 
            this.cmbAsientosInicial.FormattingEnabled = true;
            this.cmbAsientosInicial.Location = new System.Drawing.Point(533, 225);
            this.cmbAsientosInicial.Name = "cmbAsientosInicial";
            this.cmbAsientosInicial.Size = new System.Drawing.Size(139, 28);
            this.cmbAsientosInicial.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Precio del conjunto";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(393, 342);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 26);
            this.txtPrecio.TabIndex = 17;
            // 
            // frmAsignarUbicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 427);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.cmbAsientosInicial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbFilasFinal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAsientosFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFilasInicial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.chbNumeradas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoUbicaciones);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmAsignarUbicaciones";
            this.Text = "frmAsignarUbicaciones";
            this.Load += new System.EventHandler(this.frmAsignarUbicaciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbTipoUbicaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbNumeradas;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFilasInicial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAsientosFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFilasFinal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbAsientosInicial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrecio;
    }
}