namespace PalcoNet.Abm_Grado
{
    partial class frmGrado
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
            this.dgvGrados = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescripcionGrado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregarGrado = new System.Windows.Forms.Button();
            this.txtComision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(13, 317);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 37);
            this.btnAtras.TabIndex = 8;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // dgvGrados
            // 
            this.dgvGrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrados.GridColor = System.Drawing.SystemColors.Window;
            this.dgvGrados.Location = new System.Drawing.Point(20, 32);
            this.dgvGrados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGrados.MultiSelect = false;
            this.dgvGrados.Name = "dgvGrados";
            this.dgvGrados.ReadOnly = true;
            this.dgvGrados.RowHeadersVisible = false;
            this.dgvGrados.Size = new System.Drawing.Size(632, 235);
            this.dgvGrados.TabIndex = 7;
            this.dgvGrados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultados_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvGrados);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(671, 280);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Baja o modificación de Grado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescripcionGrado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnAgregarGrado);
            this.groupBox1.Controls.Add(this.txtComision);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(729, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(377, 280);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Grado";
            // 
            // txtDescripcionGrado
            // 
            this.txtDescripcionGrado.Location = new System.Drawing.Point(176, 41);
            this.txtDescripcionGrado.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcionGrado.Name = "txtDescripcionGrado";
            this.txtDescripcionGrado.Size = new System.Drawing.Size(160, 22);
            this.txtDescripcionGrado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "Descripcion Grado (*)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(22, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Campos Obligatorios (*)";
            // 
            // btnAgregarGrado
            // 
            this.btnAgregarGrado.Location = new System.Drawing.Point(18, 188);
            this.btnAgregarGrado.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarGrado.Name = "btnAgregarGrado";
            this.btnAgregarGrado.Size = new System.Drawing.Size(162, 34);
            this.btnAgregarGrado.TabIndex = 3;
            this.btnAgregarGrado.Text = "Agregar Grado";
            this.btnAgregarGrado.UseVisualStyleBackColor = true;
            this.btnAgregarGrado.Click += new System.EventHandler(this.btnAgregarGrado_Click);
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(176, 83);
            this.txtComision.Margin = new System.Windows.Forms.Padding(4);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(132, 22);
            this.txtComision.TabIndex = 2;
            this.txtComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComisionTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Comisión (*)";
            // 
            // frmGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 368);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAtras);
            this.Name = "frmGrado";
            this.Text = "frmGrado";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.DataGridView dgvGrados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescripcionGrado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregarGrado;
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.Label label2;
    }
}