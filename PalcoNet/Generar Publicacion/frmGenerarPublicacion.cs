using PalcoNet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class frmGenerarPublicacion : Form
    {
        public bool lotes =false;
        int paginaActual;
        int cantPublicacionesPorPagina = 18;
        int cantPublicacionesTotal;
        int ultimaPagina;
        string descripcion;
        int? estado = null;
        public frmGenerarPublicacion()
        {
            InitializeComponent();
            loadData();
            contarPublicaciones();
            cargarPublicaciones();
        }

        private void cargarPublicaciones()
        {
            int desde;
            int hasta;

            if (paginaActual == 0)
            {
                desde = 0;
                hasta = cantPublicacionesPorPagina;

                if (ultimaPagina != 0)
                {
                    btnAnteriorPag.Enabled = false;
                    btnPrimerPag.Enabled = false;
                    btnSiguientePag.Enabled = true;
                    btnUltimaPag.Enabled = true;
                }
                else
                {
                    btnAnteriorPag.Enabled = false;
                    btnPrimerPag.Enabled = false;
                    btnSiguientePag.Enabled = false;
                    btnUltimaPag.Enabled = false;
                }
            }
            else if (paginaActual == ultimaPagina)
            {
                desde = ((cantPublicacionesPorPagina * paginaActual) + 1);
                hasta = (desde + cantPublicacionesPorPagina - 1);

                btnSiguientePag.Enabled = false;
                btnUltimaPag.Enabled = false;
                btnAnteriorPag.Enabled = true;
                btnPrimerPag.Enabled = true;
            }
            else
            {
                desde = ((cantPublicacionesPorPagina * paginaActual) + 1);
                hasta = (desde + cantPublicacionesPorPagina - 1);

                btnSiguientePag.Enabled = true;
                btnUltimaPag.Enabled = true;
                btnAnteriorPag.Enabled = true;
                btnPrimerPag.Enabled = true;
            }
           
            dgvPublicaciones.DataSource = Publicaciones.obtenerPublicaiones(desde, hasta, null, descripcion, null, null, estado);
     
        }

        private void contarPublicaciones()
        {
            throw new NotImplementedException();
        }

        public frmGenerarPublicacion(string modo)
        {
            if (modo == "Nuevo")
            {
                InitializeComponent();
            }
        }

        private void cmbIngresoDeLotes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIngresoDeLotes.Checked)
            {
                txtLotes.Visible = false;
                lblLotes.Visible = false;
                dtpEspectaculo.Visible = true;
                lblEspectaculo.Visible =true;
                lotes = false;
            }
            else 
            {
                txtLotes.Visible = true;
                lblLotes.Visible = true;
                dtpEspectaculo.Visible = false;
                lblEspectaculo.Visible =false;
                lotes = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (UserInstance.getUserInstance().empresaId == null)
            {
                MessageBox.Show("No puede generar una publicacion porque  este usuario no tiene una empresa asociado");
            }
            List<DateTime> espectaculos = new List<DateTime>();
            Publicacion publi = new Publicacion
            {
                Descripcion = txtDescripcion.Text,
                direccionEspectaculo = txtdireccion.Text,
                FechaPublicacion = dtpPublicacion.Value,


            };
            if (chbIngresoDeLotes.Checked)
            {
                publi.FechaEspectaculo = dtpEspectaculo.Value;
                publi.save();
            }
            else 
            {
                DateTime? lastDate = null;
                for (int i = 0; i<Convert.ToInt32(txtLotes.Text);i++)
                {
                    using (var form = new frmPublicaiconesPorLotes(lastDate))
                    {
                        form.ShowDialog();
                        lastDate = form.espectaculo;
                    }
                    espectaculos.Add((DateTime)lastDate);
                }
                publi.save(espectaculos);
            }
        }

        private void frmGenerarPublicacion_Load(object sender, EventArgs e)
        {

            dtpEspectaculo.Format = DateTimePickerFormat.Custom;
            dtpEspectaculo.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dtpPublicacion.Format = DateTimePickerFormat.Custom;
            dtpPublicacion.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            
        }
        public void loadData()
        {
            List<ComboBoxItem> estados = Estados.obtenerEstados().Select(x => new ComboBoxItem { Text =x.descripcion, Value =x.codigo }).ToList();
            estados.ForEach(x => cmbEstado.Items.Add(x));
            estados.ForEach(x => cmbEstados.Items.Add(x));
            List<ComboBoxItem> rubros = Rubros.obtenerRubros().Select(x => new ComboBoxItem { Text = x.Descripcion, Value = x.Id }).ToList();
            rubros.ForEach(x => cmbRubro.Items.Add(x));

            List<ComboBoxItem> grados = Grados.ObtenerTodosLosGrados().Select(x => new ComboBoxItem { Text = x.Descripcion, Value = x.Id}).ToList();
            grados.ForEach(x => cmbGrado.Items.Add(x));

           

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            cmbEstados.SelectedValue = null;
        }

        private void btnUltimaPag_Click(object sender, EventArgs e)
        {
            paginaActual = ultimaPagina;
            contarPublicaciones();
            cargarPublicaciones();
        }

        private void btnSiguientePag_Click(object sender, EventArgs e)
        {
            paginaActual = paginaActual + 1;
            contarPublicaciones();
            cargarPublicaciones();
        }

        private void btnAnteriorPag_Click(object sender, EventArgs e)
        {
            paginaActual = paginaActual - 1;
            contarPublicaciones();
            cargarPublicaciones();
        }

        private void btnPrimerPag_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            contarPublicaciones();
            cargarPublicaciones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paginaActual = 0;

            
            descripcion = txtDescripcion.Text;
            if(cmbEstado.SelectedItem != null)
                estado = Convert.ToInt32(((ComboBoxItem)cmbEstado.SelectedItem).Value);
            contarPublicaciones();
            cargarPublicaciones();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvPublicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string estado = dgvPublicaciones[12,row].Value.ToString();
            if (estado.ToLower().Equals("finalizado"))
            {
                MessageBox.Show("La publicacion no puede ser modificada en estado finalizado");
            }
            else
            {
                txtDescripcion.Text = dgvPublicaciones[1, row].Value.ToString();
                txtdireccion.Text = dgvPublicaciones[6, row].Value.ToString();
                txtPrecio.Text = "0";//min publicacion 
                txtEmpresa.Text = dgvPublicaciones[10, row].Value.ToString();
                txtStock.Text = dgvPublicaciones[13, row].Value.ToString();
                cmbRubro.SelectedValue = dgvPublicaciones[4, row].Value;
                cmbGrado.SelectedValue = dgvPublicaciones[9, row].Value;
                cmbEstado.SelectedValue = dgvPublicaciones[11, row].Value;
                

                string date = dgvPublicaciones[3, row].Value.ToString();
                dtpPublicacion.Value = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                date = dgvPublicaciones[2, row].Value.ToString();
                dtpEspectaculo.Value = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (estado.ToLower().Equals("publicada"))
                {
                    changehabilityALl(false);
                    cmbEstado.Enabled = true;
                    cmbEstado.Items.Clear();
                    List<ComboBoxItem> estados = Estados.obtenerEstados().Where(x=>!x.descripcion.ToLower().Contains("borrador")).Select(x => new ComboBoxItem { Text = x.descripcion, Value = x.codigo }).ToList();
                    estados.ForEach(x => cmbEstado.Items.Add(x));
                }
                else 
                {

                }
                chbIngresoDeLotes.Enabled = false;
                txtLotes.Enabled = false;
                chbNuevo.Checked = false;
            }
            //if(estado.ToLower().Equals("borrador"))
            //{
            //}
            //else
            //{
            //    MessageBox.Show("La publicacion no esta en estado borrador, por lo tanto no es editable")
            //}
        }
        public void changehabilityALl(bool enable)
        {
            txtDescripcion.Enabled = enable;
            txtdireccion.Enabled = enable;
            txtPrecio.Enabled = enable;
            txtEmpresa.Enabled = enable;
            txtStock.Enabled = enable;
            cmbRubro.Enabled = enable;
            cmbGrado.Enabled = enable;
            cmbEstado.Enabled = enable;
            dtpPublicacion.Enabled = enable;
            dtpEspectaculo.Enabled = enable;
            chbIngresoDeLotes.Enabled = enable;
            txtLotes.Enabled = enable;
            chbNuevo.Checked = enable;
        }

        private void btnAgregarUbicaciones_Click(object sender, EventArgs e)
        {
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
        }
    }
}
