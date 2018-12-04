namespace PalcoNet.Abm_Grado
{
    partial class frmModificarGrado
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
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtComision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(142, 134);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cmbGrado
            // 
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Location = new System.Drawing.Point(196, 18);
            this.cmbGrado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(160, 24);
            this.cmbGrado.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tipo de Grado (*)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Campos Obligatorios (*)";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(256, 134);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 28);
            this.btnConfirmar.TabIndex = 25;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(26, 134);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(196, 72);
            this.txtComision.Margin = new System.Windows.Forms.Padding(4);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(132, 22);
            this.txtComision.TabIndex = 19;
            this.txtComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoPublicacionTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Comisión (*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "%";
            // 
            // frmModificarGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 223);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cmbGrado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtComision);
            this.Controls.Add(this.label2);
            this.Name = "frmModificarGrado";
            this.Text = "frmModificarGrado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cmbGrado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}