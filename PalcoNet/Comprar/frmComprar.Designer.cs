namespace PalcoNet.Comprar
{
    partial class frmComprar
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
            this.btnAtras = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkHasta = new System.Windows.Forms.CheckBox();
            this.chkDesde = new System.Windows.Forms.CheckBox();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.txtRubros = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.btnAgregarRubros = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAbrirPublicacion = new System.Windows.Forms.Button();
            this.btnUltimaPag = new System.Windows.Forms.Button();
            this.btnPrimerPag = new System.Windows.Forms.Button();
            this.btnSiguientePag = new System.Windows.Forms.Button();
            this.btnAnteriorPag = new System.Windows.Forms.Button();
            this.Publicaciones_Datagrid = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Publicaciones_Datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAtras.Location = new System.Drawing.Point(14, 619);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(118, 39);
            this.btnAtras.TabIndex = 20;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkHasta);
            this.groupBox1.Controls.Add(this.chkDesde);
            this.groupBox1.Controls.Add(this.dateTimePickerHasta);
            this.groupBox1.Controls.Add(this.txtRubros);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePickerDesde);
            this.groupBox1.Controls.Add(this.btnAgregarRubros);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1005, 178);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkHasta
            // 
            this.chkHasta.AutoSize = true;
            this.chkHasta.Location = new System.Drawing.Point(325, 139);
            this.chkHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHasta.Name = "chkHasta";
            this.chkHasta.Size = new System.Drawing.Size(22, 21);
            this.chkHasta.TabIndex = 42;
            this.chkHasta.UseVisualStyleBackColor = true;
            // 
            // chkDesde
            // 
            this.chkDesde.AutoSize = true;
            this.chkDesde.Location = new System.Drawing.Point(323, 61);
            this.chkDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDesde.Name = "chkDesde";
            this.chkDesde.Size = new System.Drawing.Size(22, 21);
            this.chkDesde.TabIndex = 41;
            this.chkDesde.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Location = new System.Drawing.Point(16, 132);
            this.dateTimePickerHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(298, 26);
            this.dateTimePickerHasta.TabIndex = 40;
            // 
            // txtRubros
            // 
            this.txtRubros.Location = new System.Drawing.Point(367, 49);
            this.txtRubros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRubros.Name = "txtRubros";
            this.txtRubros.ReadOnly = true;
            this.txtRubros.Size = new System.Drawing.Size(335, 26);
            this.txtRubros.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(363, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Rubro/s:";
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Location = new System.Drawing.Point(16, 56);
            this.dateTimePickerDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(298, 26);
            this.dateTimePickerDesde.TabIndex = 39;
            // 
            // btnAgregarRubros
            // 
            this.btnAgregarRubros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRubros.Location = new System.Drawing.Point(720, 34);
            this.btnAgregarRubros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarRubros.Name = "btnAgregarRubros";
            this.btnAgregarRubros.Size = new System.Drawing.Size(135, 44);
            this.btnAgregarRubros.TabIndex = 26;
            this.btnAgregarRubros.Text = "Agregar rubros";
            this.btnAgregarRubros.UseVisualStyleBackColor = true;
            this.btnAgregarRubros.Visible = false;
            this.btnAgregarRubros.Click += new System.EventHandler(this.btnAgregarRubros_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(873, 34);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(115, 44);
            this.btnReset.TabIndex = 25;
            this.btnReset.Text = "Limpiar";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Descripcion";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(873, 100);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 60);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(367, 116);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(335, 48);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Desde";
            // 
            // btnAbrirPublicacion
            // 
            this.btnAbrirPublicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPublicacion.Location = new System.Drawing.Point(816, 619);
            this.btnAbrirPublicacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAbrirPublicacion.Name = "btnAbrirPublicacion";
            this.btnAbrirPublicacion.Size = new System.Drawing.Size(202, 48);
            this.btnAbrirPublicacion.TabIndex = 18;
            this.btnAbrirPublicacion.Text = "Abrir Publicacion";
            this.btnAbrirPublicacion.UseVisualStyleBackColor = true;
            this.btnAbrirPublicacion.Click += new System.EventHandler(this.btnAbrirPublicacion_Click);
            // 
            // btnUltimaPag
            // 
            this.btnUltimaPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimaPag.Location = new System.Drawing.Point(528, 629);
            this.btnUltimaPag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUltimaPag.Name = "btnUltimaPag";
            this.btnUltimaPag.Size = new System.Drawing.Size(84, 29);
            this.btnUltimaPag.TabIndex = 17;
            this.btnUltimaPag.Text = "Ultima";
            this.btnUltimaPag.UseVisualStyleBackColor = true;
            this.btnUltimaPag.Click += new System.EventHandler(this.btnUltimaPag_Click);
            // 
            // btnPrimerPag
            // 
            this.btnPrimerPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimerPag.Location = new System.Drawing.Point(380, 629);
            this.btnPrimerPag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrimerPag.Name = "btnPrimerPag";
            this.btnPrimerPag.Size = new System.Drawing.Size(84, 29);
            this.btnPrimerPag.TabIndex = 14;
            this.btnPrimerPag.Text = "Primera";
            this.btnPrimerPag.UseVisualStyleBackColor = true;
            this.btnPrimerPag.Click += new System.EventHandler(this.btnPrimerPag_Click);
            // 
            // btnSiguientePag
            // 
            this.btnSiguientePag.Location = new System.Drawing.Point(500, 629);
            this.btnSiguientePag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSiguientePag.Name = "btnSiguientePag";
            this.btnSiguientePag.Size = new System.Drawing.Size(21, 29);
            this.btnSiguientePag.TabIndex = 16;
            this.btnSiguientePag.Text = ">";
            this.btnSiguientePag.UseVisualStyleBackColor = true;
            this.btnSiguientePag.Click += new System.EventHandler(this.btnSiguientePag_Click);
            // 
            // btnAnteriorPag
            // 
            this.btnAnteriorPag.Location = new System.Drawing.Point(471, 629);
            this.btnAnteriorPag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAnteriorPag.Name = "btnAnteriorPag";
            this.btnAnteriorPag.Size = new System.Drawing.Size(21, 29);
            this.btnAnteriorPag.TabIndex = 15;
            this.btnAnteriorPag.Text = "<";
            this.btnAnteriorPag.UseVisualStyleBackColor = true;
            this.btnAnteriorPag.Click += new System.EventHandler(this.btnAnteriorPag_Click);
            // 
            // Publicaciones_Datagrid
            // 
            this.Publicaciones_Datagrid.AllowUserToAddRows = false;
            this.Publicaciones_Datagrid.AllowUserToDeleteRows = false;
            this.Publicaciones_Datagrid.AllowUserToResizeColumns = false;
            this.Publicaciones_Datagrid.AllowUserToResizeRows = false;
            this.Publicaciones_Datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Publicaciones_Datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Publicaciones_Datagrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Publicaciones_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Publicaciones_Datagrid.Location = new System.Drawing.Point(14, 200);
            this.Publicaciones_Datagrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Publicaciones_Datagrid.MultiSelect = false;
            this.Publicaciones_Datagrid.Name = "Publicaciones_Datagrid";
            this.Publicaciones_Datagrid.ReadOnly = true;
            this.Publicaciones_Datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Publicaciones_Datagrid.Size = new System.Drawing.Size(1005, 395);
            this.Publicaciones_Datagrid.TabIndex = 13;
            this.Publicaciones_Datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Publicaciones_Datagrid_CellContentClick);
            // 
            // frmComprar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 675);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAbrirPublicacion);
            this.Controls.Add(this.btnUltimaPag);
            this.Controls.Add(this.btnPrimerPag);
            this.Controls.Add(this.btnSiguientePag);
            this.Controls.Add(this.btnAnteriorPag);
            this.Controls.Add(this.Publicaciones_Datagrid);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmComprar";
            this.Text = "frmComprar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Publicaciones_Datagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAbrirPublicacion;
        private System.Windows.Forms.Button btnUltimaPag;
        private System.Windows.Forms.Button btnPrimerPag;
        private System.Windows.Forms.Button btnSiguientePag;
        private System.Windows.Forms.Button btnAnteriorPag;
        private System.Windows.Forms.DataGridView Publicaciones_Datagrid;
        private System.Windows.Forms.TextBox txtRubros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarRubros;
        private System.Windows.Forms.CheckBox chkHasta;
        private System.Windows.Forms.CheckBox chkDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
    }
}