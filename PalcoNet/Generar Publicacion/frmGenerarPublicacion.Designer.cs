namespace PalcoNet.Generar_Publicacion
{
    partial class frmGenerarPublicacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dgvPublicaciones = new System.Windows.Forms.DataGridView();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPublicacion = new System.Windows.Forms.Label();
            this.lblEspectaculo = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chbIngresoUnico = new System.Windows.Forms.CheckBox();
            this.txtLotes = new System.Windows.Forms.TextBox();
            this.lblLotes = new System.Windows.Forms.Label();
            this.dtpPublicacion = new System.Windows.Forms.DateTimePicker();
            this.dtpEspectaculo = new System.Windows.Forms.DateTimePicker();
            this.cmbEstados = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnUltimaPag = new System.Windows.Forms.Button();
            this.btnPrimerPag = new System.Windows.Forms.Button();
            this.btnSiguientePag = new System.Windows.Forms.Button();
            this.btnAnteriorPag = new System.Windows.Forms.Button();
            this.chbNuevo = new System.Windows.Forms.CheckBox();
            this.btnAgregarUbicaciones = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCodEspectaculo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1414, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(1534, 246);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(181, 26);
            this.txtDescripcion.TabIndex = 1;
            // 
            // dgvPublicaciones
            // 
            this.dgvPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublicaciones.Location = new System.Drawing.Point(12, 191);
            this.dgvPublicaciones.Name = "dgvPublicaciones";
            this.dgvPublicaciones.RowTemplate.Height = 28;
            this.dgvPublicaciones.Size = new System.Drawing.Size(1338, 596);
            this.dgvPublicaciones.TabIndex = 2;
            this.dgvPublicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPublicaciones_CellContentClick);
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(1883, 246);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(181, 26);
            this.txtStock.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1763, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stock";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(1883, 302);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(181, 26);
            this.txtPrecio.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1763, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Precio";
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(1883, 368);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(181, 26);
            this.txtdireccion.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1763, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "direccion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1414, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Rubro";
            // 
            // cmbRubro
            // 
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(1534, 311);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(181, 28);
            this.cmbRubro.TabIndex = 13;
            // 
            // cmbGrado
            // 
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Location = new System.Drawing.Point(1534, 371);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(181, 28);
            this.cmbGrado.TabIndex = 17;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Enabled = false;
            this.txtEmpresa.Location = new System.Drawing.Point(1883, 428);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(181, 26);
            this.txtEmpresa.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1763, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Empresa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1414, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Grado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(1534, 440);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(181, 28);
            this.cmbEstado.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1414, 442);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Estado";
            // 
            // lblPublicacion
            // 
            this.lblPublicacion.AutoSize = true;
            this.lblPublicacion.Location = new System.Drawing.Point(1482, 525);
            this.lblPublicacion.Name = "lblPublicacion";
            this.lblPublicacion.Size = new System.Drawing.Size(137, 20);
            this.lblPublicacion.TabIndex = 20;
            this.lblPublicacion.Text = "Fecha publicacion";
            // 
            // lblEspectaculo
            // 
            this.lblEspectaculo.AutoSize = true;
            this.lblEspectaculo.Location = new System.Drawing.Point(1831, 525);
            this.lblEspectaculo.Name = "lblEspectaculo";
            this.lblEspectaculo.Size = new System.Drawing.Size(144, 20);
            this.lblEspectaculo.TabIndex = 22;
            this.lblEspectaculo.Text = "Fecha espectaculo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(1728, 646);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(185, 39);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1500, 646);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(185, 39);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // chbIngresoUnico
            // 
            this.chbIngresoUnico.AutoSize = true;
            this.chbIngresoUnico.Location = new System.Drawing.Point(1418, 484);
            this.chbIngresoUnico.Name = "chbIngresoUnico";
            this.chbIngresoUnico.Size = new System.Drawing.Size(134, 24);
            this.chbIngresoUnico.TabIndex = 26;
            this.chbIngresoUnico.Text = "Ingreso Unico";
            this.chbIngresoUnico.UseVisualStyleBackColor = true;
            this.chbIngresoUnico.CheckedChanged += new System.EventHandler(this.cmbIngresoDeLotes_CheckedChanged);
            // 
            // txtLotes
            // 
            this.txtLotes.Location = new System.Drawing.Point(1758, 482);
            this.txtLotes.Name = "txtLotes";
            this.txtLotes.Size = new System.Drawing.Size(181, 26);
            this.txtLotes.TabIndex = 28;
            // 
            // lblLotes
            // 
            this.lblLotes.AutoSize = true;
            this.lblLotes.Location = new System.Drawing.Point(1605, 482);
            this.lblLotes.Name = "lblLotes";
            this.lblLotes.Size = new System.Drawing.Size(133, 20);
            this.lblLotes.TabIndex = 27;
            this.lblLotes.Text = "Cantidad de lotes";
            // 
            // dtpPublicacion
            // 
            this.dtpPublicacion.Location = new System.Drawing.Point(1454, 572);
            this.dtpPublicacion.Name = "dtpPublicacion";
            this.dtpPublicacion.Size = new System.Drawing.Size(200, 26);
            this.dtpPublicacion.TabIndex = 29;
            // 
            // dtpEspectaculo
            // 
            this.dtpEspectaculo.Location = new System.Drawing.Point(1796, 572);
            this.dtpEspectaculo.Name = "dtpEspectaculo";
            this.dtpEspectaculo.Size = new System.Drawing.Size(200, 26);
            this.dtpEspectaculo.TabIndex = 30;
            // 
            // cmbEstados
            // 
            this.cmbEstados.FormattingEnabled = true;
            this.cmbEstados.Location = new System.Drawing.Point(442, 72);
            this.cmbEstados.Name = "cmbEstados";
            this.cmbEstados.Size = new System.Drawing.Size(336, 28);
            this.cmbEstados.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(439, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Estados";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(1175, 32);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(115, 44);
            this.btnReset.TabIndex = 25;
            this.btnReset.Text = "Limpiar";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Descripcion";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(1175, 98);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 60);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 72);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 48);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEstados);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1338, 180);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros:";
            // 
            // btnAtras
            // 
            this.btnAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAtras.Location = new System.Drawing.Point(156, 834);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(124, 47);
            this.btnAtras.TabIndex = 36;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnUltimaPag
            // 
            this.btnUltimaPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimaPag.Location = new System.Drawing.Point(703, 834);
            this.btnUltimaPag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUltimaPag.Name = "btnUltimaPag";
            this.btnUltimaPag.Size = new System.Drawing.Size(126, 47);
            this.btnUltimaPag.TabIndex = 35;
            this.btnUltimaPag.Text = "Ultima";
            this.btnUltimaPag.UseVisualStyleBackColor = true;
            this.btnUltimaPag.Click += new System.EventHandler(this.btnUltimaPag_Click);
            // 
            // btnPrimerPag
            // 
            this.btnPrimerPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimerPag.Location = new System.Drawing.Point(477, 834);
            this.btnPrimerPag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrimerPag.Name = "btnPrimerPag";
            this.btnPrimerPag.Size = new System.Drawing.Size(84, 47);
            this.btnPrimerPag.TabIndex = 32;
            this.btnPrimerPag.Text = "Primera";
            this.btnPrimerPag.UseVisualStyleBackColor = true;
            this.btnPrimerPag.Click += new System.EventHandler(this.btnPrimerPag_Click);
            // 
            // btnSiguientePag
            // 
            this.btnSiguientePag.Location = new System.Drawing.Point(644, 834);
            this.btnSiguientePag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSiguientePag.Name = "btnSiguientePag";
            this.btnSiguientePag.Size = new System.Drawing.Size(39, 47);
            this.btnSiguientePag.TabIndex = 34;
            this.btnSiguientePag.Text = ">";
            this.btnSiguientePag.UseVisualStyleBackColor = true;
            this.btnSiguientePag.Click += new System.EventHandler(this.btnSiguientePag_Click);
            // 
            // btnAnteriorPag
            // 
            this.btnAnteriorPag.Location = new System.Drawing.Point(595, 834);
            this.btnAnteriorPag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAnteriorPag.Name = "btnAnteriorPag";
            this.btnAnteriorPag.Size = new System.Drawing.Size(43, 47);
            this.btnAnteriorPag.TabIndex = 33;
            this.btnAnteriorPag.Text = "<";
            this.btnAnteriorPag.UseVisualStyleBackColor = true;
            this.btnAnteriorPag.Click += new System.EventHandler(this.btnAnteriorPag_Click);
            // 
            // chbNuevo
            // 
            this.chbNuevo.AutoSize = true;
            this.chbNuevo.Location = new System.Drawing.Point(1418, 152);
            this.chbNuevo.Name = "chbNuevo";
            this.chbNuevo.Size = new System.Drawing.Size(80, 24);
            this.chbNuevo.TabIndex = 37;
            this.chbNuevo.Text = "Nuevo";
            this.chbNuevo.UseVisualStyleBackColor = true;
            this.chbNuevo.CheckedChanged += new System.EventHandler(this.chbNuevo_CheckedChanged);
            // 
            // btnAgregarUbicaciones
            // 
            this.btnAgregarUbicaciones.Location = new System.Drawing.Point(1879, 167);
            this.btnAgregarUbicaciones.Name = "btnAgregarUbicaciones";
            this.btnAgregarUbicaciones.Size = new System.Drawing.Size(185, 39);
            this.btnAgregarUbicaciones.TabIndex = 38;
            this.btnAgregarUbicaciones.Text = "Agregar ubicaciones";
            this.btnAgregarUbicaciones.UseVisualStyleBackColor = true;
            this.btnAgregarUbicaciones.Click += new System.EventHandler(this.btnAgregarUbicaciones_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1414, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 20);
            this.label11.TabIndex = 39;
            this.label11.Text = "CodigoEspectaculo";
            // 
            // lblCodEspectaculo
            // 
            this.lblCodEspectaculo.AutoSize = true;
            this.lblCodEspectaculo.Location = new System.Drawing.Point(1591, 191);
            this.lblCodEspectaculo.Name = "lblCodEspectaculo";
            this.lblCodEspectaculo.Size = new System.Drawing.Size(0, 20);
            this.lblCodEspectaculo.TabIndex = 40;
            // 
            // frmGenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2167, 955);
            this.Controls.Add(this.lblCodEspectaculo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAgregarUbicaciones);
            this.Controls.Add(this.chbNuevo);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnUltimaPag);
            this.Controls.Add(this.btnPrimerPag);
            this.Controls.Add(this.btnSiguientePag);
            this.Controls.Add(this.btnAnteriorPag);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpEspectaculo);
            this.Controls.Add(this.dtpPublicacion);
            this.Controls.Add(this.txtLotes);
            this.Controls.Add(this.lblLotes);
            this.Controls.Add(this.chbIngresoUnico);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblEspectaculo);
            this.Controls.Add(this.lblPublicacion);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbGrado);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbRubro);
            this.Controls.Add(this.txtdireccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPublicaciones);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Name = "frmGenerarPublicacion";
            this.Text = "frmGenerarPublicacion";
            this.Load += new System.EventHandler(this.frmGenerarPublicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView dgvPublicaciones;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.ComboBox cmbGrado;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPublicacion;
        private System.Windows.Forms.Label lblEspectaculo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chbIngresoUnico;
        private System.Windows.Forms.TextBox txtLotes;
        private System.Windows.Forms.Label lblLotes;
        private System.Windows.Forms.DateTimePicker dtpPublicacion;
        private System.Windows.Forms.DateTimePicker dtpEspectaculo;
        private System.Windows.Forms.ComboBox cmbEstados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnUltimaPag;
        private System.Windows.Forms.Button btnPrimerPag;
        private System.Windows.Forms.Button btnSiguientePag;
        private System.Windows.Forms.Button btnAnteriorPag;
        private System.Windows.Forms.CheckBox chbNuevo;
        private System.Windows.Forms.Button btnAgregarUbicaciones;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCodEspectaculo;
    }
}