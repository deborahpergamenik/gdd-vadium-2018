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
    public partial class frmGenerarPublicacion : Form
    {
        public bool lotes =false;
        int paginaActual;
        int cantPublicacionesPorPagina = 18;
        int cantPublicacionesTotal;
        int ultimaPagina;
        string descripcion;
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
            int estado =Convert.ToInt32( ((ComboBoxItem)cmbEstado.SelectedItem).Value);
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
            if (cmbIngresoDeLotes.Checked)
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
            if (cmbIngresoDeLotes.Checked)
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
            
        }
    }
}
