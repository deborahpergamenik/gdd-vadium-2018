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

namespace PalcoNet.Generar_Publicacion
{
    public partial class frmAsignarUbicaciones : Form
    {
       public  List<Ubicacion> ubicacionesCreadas = new List<Ubicacion>();
        public frmAsignarUbicaciones()
        {
            InitializeComponent();
            chbNumeradas.Checked = true;
            cmbFilasInicial.Enabled = true;
            cmbFilasFinal.Enabled = true;
            cmbAsientosFinal.Enabled = true;
            cmbAsientosInicial.Enabled = true;
            txtCantidad.Enabled = false;
            cargarCombos();
        }

        private void cargarCombos()
        {
            Ubicaciones.ObtenerTipoDeUbicaciones().ForEach(x => cmbTipoUbicaciones.Items.Add(new ComboBoxItem { Text = x.descripcion, Value = x.id }));
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            foreach (var c in alpha)
            {
                cmbFilasInicial.Items.Add(c);
                cmbFilasFinal.Items.Add(c);
            }
            for (int i = 1; i < 71; i++ )
            {
                cmbAsientosFinal.Items.Add(i);
                cmbAsientosInicial.Items.Add(i);
            }
            
        }

        private void chbNumeradas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNumeradas.Checked)
            {
                cmbFilasInicial.Enabled = true;
                cmbFilasFinal.Enabled = true;
                cmbAsientosFinal.Enabled = true;
                cmbAsientosInicial.Enabled = true;
                txtCantidad.Enabled = false;
            }
            else 
            {
                cmbFilasInicial.Enabled = false;
                cmbFilasFinal.Enabled = false;
                cmbAsientosFinal.Enabled = false;
                cmbAsientosInicial.Enabled = false;
                txtCantidad.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PrecioEsValid(txtPrecio.Text))
            {
                if(cmbTipoUbicaciones.SelectedItem != null)
                {
                    if (!chbNumeradas.Checked)
                    {
                        if(CantidadIsValid(txtCantidad.Text))
                        {
                            int cantidad = Convert.ToInt32(txtCantidad.Text);
                            for(int i = 0 ; i < cantidad; i++)
                            {
                                Ubicacion ubicacion = new Ubicacion{ precio = Convert.ToInt32(txtPrecio.Text),sinNumerar = true, codigoTipoubicacion = Convert.ToInt32(cmbTipoUbicaciones.SelectedValue) };
                                ubicacionesCreadas.Add(ubicacion);
                            }
                            MessageBox.Show("Se agregaron " + cantidad + " ubicaciones sin numerar del tipo " + cmbTipoUbicaciones.SelectedText);
                            Clear();
                        }
                    }
                    else
                    {
                        if (verificarcmbs())
                        {
                            //RANGO DE FILAS
                            string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                            string selectRowStartItem = cmbFilasInicial.SelectedItem.ToString();
                            int startChar = abc.IndexOf(selectRowStartItem);
                            string selectRowFinishItem = cmbFilasFinal.SelectedItem.ToString();
                            int finishChar = abc.IndexOf(selectRowFinishItem);
                            char[] alpha = abc.ToCharArray();
                            //RANGO DE ASIENTOS
                            string stAs = cmbAsientosInicial.SelectedItem.ToString();
                            string fsAs = cmbAsientosFinal.SelectedItem.ToString();
                            int startAs = Convert.ToInt32(stAs);
                            int finsihAs = Convert.ToInt32(fsAs);
                            int cantidad = 0;
                            for (int i = startChar; i <= finishChar; i++)
                            {
                                char c = alpha[i];
                                for (int j = startAs; j <= finsihAs; j++)
                                {
                                    cantidad++;
                                    Ubicacion ubicacion = new Ubicacion { precio = Convert.ToInt32(txtPrecio.Text), sinNumerar = false, codigoTipoubicacion = Convert.ToInt32(((ComboBoxItem)cmbTipoUbicaciones.SelectedItem).Value), fila = c.ToString(), asiento = j };
                                    ubicacionesCreadas.Add(ubicacion);
                                }
                            }
                            MessageBox.Show("Se agregaron " + cantidad + " ubicaciones numeradas del tipo " + ((ComboBoxItem)cmbTipoUbicaciones.SelectedItem).Text);
                            Clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccionar un tipo de ubicacion");
                }
            }

        }

        private bool verificarcmbs()
        {
            if (cmbAsientosFinal.SelectedItem == null || cmbAsientosInicial.SelectedItem == null || cmbFilasFinal.SelectedItem == null || cmbFilasInicial.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar fila y asientos tantos iniciales como finales");
                return false;
            }
            return true;
        }

        private void Clear()
        {
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            
        }

        private bool CantidadIsValid(string p)
        {
            if (String.IsNullOrEmpty(p))
            {
                MessageBox.Show("El campo cantidad no puede ser vacio");
                return false;
            }
            int n;
            if(!int.TryParse(p, out n))
            {
                MessageBox.Show("El campo cantidad debe ser numerico");
                return false;
            }
            return true;
        }

        private bool PrecioEsValid(string p)
        {
            if (String.IsNullOrEmpty(p))
            {
                MessageBox.Show("El campo precio no puede ser vacio");
                return false;
            }
            int n;
            if (!int.TryParse(p, out n))
            {
                MessageBox.Show("El campo precio no tiene un valor valido");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
