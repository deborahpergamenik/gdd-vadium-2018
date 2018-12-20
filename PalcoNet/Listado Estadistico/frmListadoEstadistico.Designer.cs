namespace PalcoNet.Listado_Estadistico
{
    partial class frmListadoEstadistico
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.top5DataGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.lblGrado = new System.Windows.Forms.Label();
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbTipoListado = new System.Windows.Forms.ComboBox();
            this.TipoListadoLabel = new System.Windows.Forms.Label();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.TrimestreLabel = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.anioLabel = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top5DataGridView)).BeginInit();
            this.groupBoxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(637, 554);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(137, 41);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.top5DataGridView);
            this.groupBox2.Location = new System.Drawing.Point(15, 262);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(759, 281);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TOP 5:";
            // 
            // top5DataGridView
            // 
            this.top5DataGridView.AllowUserToAddRows = false;
            this.top5DataGridView.AllowUserToDeleteRows = false;
            this.top5DataGridView.AllowUserToResizeColumns = false;
            this.top5DataGridView.AllowUserToResizeRows = false;
            this.top5DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.top5DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.top5DataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.top5DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.top5DataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.top5DataGridView.Location = new System.Drawing.Point(9, 29);
            this.top5DataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.top5DataGridView.Name = "top5DataGridView";
            this.top5DataGridView.ReadOnly = true;
            this.top5DataGridView.RowHeadersVisible = false;
            this.top5DataGridView.Size = new System.Drawing.Size(741, 234);
            this.top5DataGridView.TabIndex = 11;
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.lblGrado);
            this.groupBoxFiltros.Controls.Add(this.cmbGrado);
            this.groupBoxFiltros.Controls.Add(this.label1);
            this.groupBoxFiltros.Controls.Add(this.btnBuscar);
            this.groupBoxFiltros.Controls.Add(this.cmbTipoListado);
            this.groupBoxFiltros.Controls.Add(this.TipoListadoLabel);
            this.groupBoxFiltros.Controls.Add(this.cmbTrimestre);
            this.groupBoxFiltros.Controls.Add(this.TrimestreLabel);
            this.groupBoxFiltros.Controls.Add(this.txtAnio);
            this.groupBoxFiltros.Controls.Add(this.anioLabel);
            this.groupBoxFiltros.Location = new System.Drawing.Point(15, 16);
            this.groupBoxFiltros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxFiltros.Size = new System.Drawing.Size(759, 238);
            this.groupBoxFiltros.TabIndex = 19;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de Búsqueda";
            // 
            // lblGrado
            // 
            this.lblGrado.AutoSize = true;
            this.lblGrado.Location = new System.Drawing.Point(350, 182);
            this.lblGrado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrado.Name = "lblGrado";
            this.lblGrado.Size = new System.Drawing.Size(58, 20);
            this.lblGrado.TabIndex = 21;
            this.lblGrado.Text = "Grado:";
            this.lblGrado.Visible = false;
            // 
            // cmbGrado
            // 
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Location = new System.Drawing.Point(428, 179);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(121, 28);
            this.cmbGrado.TabIndex = 20;
            this.cmbGrado.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Campos Obligatorios (*)";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(622, 179);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 35);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbTipoListado
            // 
            this.cmbTipoListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoListado.FormattingEnabled = true;
            this.cmbTipoListado.Location = new System.Drawing.Point(204, 60);
            this.cmbTipoListado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTipoListado.Name = "cmbTipoListado";
            this.cmbTipoListado.Size = new System.Drawing.Size(529, 28);
            this.cmbTipoListado.TabIndex = 0;
            this.cmbTipoListado.SelectedIndexChanged += new System.EventHandler(this.cmbTipoListado_SelectedIndexChanged);
            // 
            // TipoListadoLabel
            // 
            this.TipoListadoLabel.AutoSize = true;
            this.TipoListadoLabel.Location = new System.Drawing.Point(55, 60);
            this.TipoListadoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TipoListadoLabel.Name = "TipoListadoLabel";
            this.TipoListadoLabel.Size = new System.Drawing.Size(141, 20);
            this.TipoListadoLabel.TabIndex = 4;
            this.TipoListadoLabel.Text = "Tipo de Listado (*):";
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Location = new System.Drawing.Point(514, 119);
            this.cmbTrimestre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(219, 28);
            this.cmbTrimestre.TabIndex = 2;
            // 
            // TrimestreLabel
            // 
            this.TrimestreLabel.AutoSize = true;
            this.TrimestreLabel.Location = new System.Drawing.Point(411, 122);
            this.TrimestreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TrimestreLabel.Name = "TrimestreLabel";
            this.TrimestreLabel.Size = new System.Drawing.Size(99, 20);
            this.TrimestreLabel.TabIndex = 2;
            this.TrimestreLabel.Text = "Trimestre (*):";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(204, 119);
            this.txtAnio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(148, 26);
            this.txtAnio.TabIndex = 1;
            // 
            // anioLabel
            // 
            this.anioLabel.AutoSize = true;
            this.anioLabel.Location = new System.Drawing.Point(55, 122);
            this.anioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(62, 20);
            this.anioLabel.TabIndex = 0;
            this.anioLabel.Text = "Año (*):";
            // 
            // btnAtras
            // 
            this.btnAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAtras.Location = new System.Drawing.Point(15, 554);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(137, 41);
            this.btnAtras.TabIndex = 21;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 631);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxFiltros);
            this.Controls.Add(this.btnAtras);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListadoEstadistico";
            this.Text = "frmListadoEstadistico";
            this.Load += new System.EventHandler(this.frmListadoEstadistico_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.top5DataGridView)).EndInit();
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView top5DataGridView;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbTipoListado;
        private System.Windows.Forms.Label TipoListadoLabel;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Label TrimestreLabel;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label anioLabel;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.ComboBox cmbGrado;
        private System.Windows.Forms.Label lblGrado;
    }
}