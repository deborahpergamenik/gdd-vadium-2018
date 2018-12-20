using PalcoNet.Common;
using PalcoNet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class frmListadoEstadistico : Form
    {
        public frmListadoEstadistico()
        {
            InitializeComponent();
            //Cargando combo de trimestre
            this.cmbTrimestre.Items.Add(1);
            this.cmbTrimestre.Items.Add(2);
            this.cmbTrimestre.Items.Add(3);

            //Cargando Combo de tipos de listados
            this.cmbTipoListado.Items.Add("Empresas con mayor cantidad de localidades no vendidas");
            this.cmbTipoListado.Items.Add("Clientes con mayores puntos vencidos");
            this.cmbTipoListado.Items.Add("Clientes con mayor cantidad de compras");
            loadGrado();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.verificarCampos(this.groupBoxFiltros))
            {
                int anio = Convert.ToInt32(this.txtAnio.Text);
                int trimestre = this.cmbTrimestre.SelectedIndex + 1;
                int opcionElegida = this.cmbTipoListado.SelectedIndex + 1;
                int? grado = null;
                if (cmbGrado.SelectedItem != null)
                    grado =Convert.ToInt32( ((ComboBoxItem)cmbGrado.SelectedItem).Value);

                ListadoEstadistico listado = new ListadoEstadistico(trimestre, anio,grado);

                this.top5DataGridView.DataSource = listado.buscar(opcionElegida);

                if (this.top5DataGridView.DataSource == null)
                {
                    MessageBox.Show("¡No se encontraron resultados!. Por favor, verifique los filtros seleccionados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.top5DataGridView.Refresh();


                this.top5DataGridView = Interfaz.bloquearDataGridView(this.top5DataGridView);
            }
        }


        private void anioTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool verificarCampos(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var anioYTrimestre = c as TextBox;
                var tipoListado = c as ComboBox;


                if (anioYTrimestre != null && anioYTrimestre.Text == "")
                {
                    string str = "Los campos obligatorios no pueden estar vacios";
                    DialogResult result = MessageBox.Show(str, "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (cmbTrimestre.SelectedIndex == -1 || cmbTipoListado.SelectedIndex == -1)
            {

                string str = "Los campos obligatorios no pueden estar vacios";
                DialogResult result = MessageBox.Show(str, "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void loadGrado()
        {
            List<ComboBoxItem> grados = Grados.ObtenerTodosLosGrados().Select(x => new ComboBoxItem { Text = x.Descripcion, Value = x.Id }).ToList();
            grados.ForEach(x => cmbGrado.Items.Add(x));
        }

        private void cmbTipoListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Empresas con mayor cantidad de localidades no vendidas
            if (this.cmbTipoListado.SelectedIndex == 0)
            {
                cmbGrado.Visible = true;
                lblGrado.Visible = true;
                
            }
            else 
            {
                cmbGrado.Visible = false;
                lblGrado.Visible = false;
            }
        }

        private void frmListadoEstadistico_Load(object sender, EventArgs e)
        {

        }
        
    }
}
