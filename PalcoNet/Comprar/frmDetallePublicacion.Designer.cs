namespace PalcoNet.Comprar
{
    partial class frmDetallePublicacion
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
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.dgvUbicaciones = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnAsociarTarjeta = new System.Windows.Forms.Button();
            this.mskNumeroTarjeta = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTarjetas = new System.Windows.Forms.ComboBox();
            this.lblTarjetasAsocidas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(1334, 602);
            this.btnComprar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(118, 44);
            this.btnComprar.TabIndex = 19;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1334, 39);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(118, 36);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tipo Ubicacion";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(15, 39);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(180, 28);
            this.cmbTipo.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ubicaciones disponibles";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(36, 602);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(118, 44);
            this.btnAtras.TabIndex = 20;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // dgvUbicaciones
            // 
            this.dgvUbicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUbicaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvUbicaciones.Location = new System.Drawing.Point(14, 118);
            this.dgvUbicaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUbicaciones.Name = "dgvUbicaciones";
            this.dgvUbicaciones.RowTemplate.Height = 28;
            this.dgvUbicaciones.Size = new System.Drawing.Size(1438, 466);
            this.dgvUbicaciones.TabIndex = 21;
            this.dgvUbicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUbicaciones_CellContentClick_1);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Precio total:  $";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(399, 76);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(0, 20);
            this.lblPrecio.TabIndex = 23;
            // 
            // btnAsociarTarjeta
            // 
            this.btnAsociarTarjeta.Location = new System.Drawing.Point(1112, 606);
            this.btnAsociarTarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAsociarTarjeta.Name = "btnAsociarTarjeta";
            this.btnAsociarTarjeta.Size = new System.Drawing.Size(166, 36);
            this.btnAsociarTarjeta.TabIndex = 47;
            this.btnAsociarTarjeta.Text = "Asociar Tarjeta";
            this.btnAsociarTarjeta.UseVisualStyleBackColor = true;
            this.btnAsociarTarjeta.Click += new System.EventHandler(this.btnAsociarTarjeta_Click);
            // 
            // mskNumeroTarjeta
            // 
            this.mskNumeroTarjeta.Enabled = false;
            this.mskNumeroTarjeta.Location = new System.Drawing.Point(926, 610);
            this.mskNumeroTarjeta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mskNumeroTarjeta.Mask = "0000-0000-0000-0000";
            this.mskNumeroTarjeta.Name = "mskNumeroTarjeta";
            this.mskNumeroTarjeta.Size = new System.Drawing.Size(177, 26);
            this.mskNumeroTarjeta.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(726, 614);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 20);
            this.label7.TabIndex = 45;
            this.label7.Text = "Número Tarjeta Asociada";
            // 
            // cmbTarjetas
            // 
            this.cmbTarjetas.FormattingEnabled = true;
            this.cmbTarjetas.Location = new System.Drawing.Point(490, 610);
            this.cmbTarjetas.Name = "cmbTarjetas";
            this.cmbTarjetas.Size = new System.Drawing.Size(181, 28);
            this.cmbTarjetas.TabIndex = 48;
            this.cmbTarjetas.SelectedIndexChanged += new System.EventHandler(this.cmbTarjetas_SelectedIndexChanged);
            // 
            // lblTarjetasAsocidas
            // 
            this.lblTarjetasAsocidas.AutoSize = true;
            this.lblTarjetasAsocidas.Location = new System.Drawing.Point(321, 614);
            this.lblTarjetasAsocidas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTarjetasAsocidas.Name = "lblTarjetasAsocidas";
            this.lblTarjetasAsocidas.Size = new System.Drawing.Size(142, 20);
            this.lblTarjetasAsocidas.TabIndex = 49;
            this.lblTarjetasAsocidas.Text = "Tarjetas asociadas";
            // 
            // frmDetallePublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 668);
            this.Controls.Add(this.lblTarjetasAsocidas);
            this.Controls.Add(this.cmbTarjetas);
            this.Controls.Add(this.btnAsociarTarjeta);
            this.Controls.Add(this.mskNumeroTarjeta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvUbicaciones);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDetallePublicacion";
            this.Text = "frmDetallePublicacion";
            this.Load += new System.EventHandler(this.frmDetallePublicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.DataGridView dgvUbicaciones;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnAsociarTarjeta;
        private System.Windows.Forms.MaskedTextBox mskNumeroTarjeta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTarjetas;
        private System.Windows.Forms.Label lblTarjetasAsocidas;
    }
}