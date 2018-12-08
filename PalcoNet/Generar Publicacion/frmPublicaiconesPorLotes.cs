using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class frmPublicaiconesPorLotes : Form
    {
        public DateTime? espectaculoAnterior;
        public DateTime espectaculo{get;set;}
        public frmPublicaiconesPorLotes(DateTime? espAnterior)
        {
            this.espectaculoAnterior = espAnterior;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.espectaculo = dtpEspectaculo.Value;
            if (this.espectaculoAnterior == null || espectaculo.CompareTo(espectaculoAnterior) > 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese una fecha posterior a " + espectaculoAnterior.ToString());
            }

        }

        private void frmPublicaiconesPorLotes_Load(object sender, EventArgs e)
        {
            dtpEspectaculo.Format = DateTimePickerFormat.Custom;
            dtpEspectaculo.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            if(this.espectaculoAnterior != null)
                MessageBox.Show("Ingrese una fecha posterior a " + espectaculoAnterior.ToString());
        }
    }
}
