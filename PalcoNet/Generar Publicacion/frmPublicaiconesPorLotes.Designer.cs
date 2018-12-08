namespace PalcoNet.Generar_Publicacion
{
    partial class frmPublicaiconesPorLotes
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
            this.lblEspectaculo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpEspectaculo = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblEspectaculo
            // 
            this.lblEspectaculo.AutoSize = true;
            this.lblEspectaculo.Location = new System.Drawing.Point(118, 29);
            this.lblEspectaculo.Name = "lblEspectaculo";
            this.lblEspectaculo.Size = new System.Drawing.Size(144, 20);
            this.lblEspectaculo.TabIndex = 26;
            this.lblEspectaculo.Text = "Fecha espectaculo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 41);
            this.button1.TabIndex = 28;
            this.button1.Text = "Siguiente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpEspectaculo
            // 
            this.dtpEspectaculo.Location = new System.Drawing.Point(89, 79);
            this.dtpEspectaculo.Name = "dtpEspectaculo";
            this.dtpEspectaculo.Size = new System.Drawing.Size(200, 26);
            this.dtpEspectaculo.TabIndex = 29;
            // 
            // frmPublicaiconesPorLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 219);
            this.Controls.Add(this.dtpEspectaculo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEspectaculo);
            this.Name = "frmPublicaiconesPorLotes";
            this.Text = "frmPublicaiconesPorLotes";
            this.Load += new System.EventHandler(this.frmPublicaiconesPorLotes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEspectaculo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpEspectaculo;
    }
}