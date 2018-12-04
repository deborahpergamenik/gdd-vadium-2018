namespace PalcoNet.Canje_Puntos
{
    partial class frmCanjePuntos
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
            this.btnAtras = new System.Windows.Forms.Button();
            this.txtPuntos = new System.Windows.Forms.Label();
            this.dgvCanjearPuntos = new System.Windows.Forms.DataGridView();
            this.ExchangeButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanjearPuntos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Puntos actuales: ";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(785, 294);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 37);
            this.btnAtras.TabIndex = 9;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // txtPuntos
            // 
            this.txtPuntos.AutoSize = true;
            this.txtPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntos.ForeColor = System.Drawing.Color.Red;
            this.txtPuntos.Location = new System.Drawing.Point(167, 23);
            this.txtPuntos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.Size = new System.Drawing.Size(27, 20);
            this.txtPuntos.TabIndex = 10;
            this.txtPuntos.Text = "xx";
            // 
            // dgvCanjearPuntos
            // 
            this.dgvCanjearPuntos.AllowUserToAddRows = false;
            this.dgvCanjearPuntos.AllowUserToDeleteRows = false;
            this.dgvCanjearPuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanjearPuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExchangeButton});
            this.dgvCanjearPuntos.Location = new System.Drawing.Point(18, 55);
            this.dgvCanjearPuntos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCanjearPuntos.Name = "dgvCanjearPuntos";
            this.dgvCanjearPuntos.ReadOnly = true;
            this.dgvCanjearPuntos.Size = new System.Drawing.Size(867, 215);
            this.dgvCanjearPuntos.TabIndex = 11;
            this.dgvCanjearPuntos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCanjearPuntos_CellContentClick);
            // 
            // ExchangeButton
            // 
            this.ExchangeButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExchangeButton.HeaderText = "Canjear";
            this.ExchangeButton.Name = "ExchangeButton";
            this.ExchangeButton.ReadOnly = true;
            this.ExchangeButton.Width = 63;
            // 
            // frmCanjePuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 349);
            this.Controls.Add(this.dgvCanjearPuntos);
            this.Controls.Add(this.txtPuntos);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label1);
            this.Name = "frmCanjePuntos";
            this.Text = "frmCanjePuntos";
            this.Load += new System.EventHandler(this.frmCanjePuntos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanjearPuntos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label txtPuntos;
        private System.Windows.Forms.DataGridView dgvCanjearPuntos;
        private System.Windows.Forms.DataGridViewButtonColumn ExchangeButton;
    }
}