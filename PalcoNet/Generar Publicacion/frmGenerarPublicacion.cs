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
        public frmGenerarPublicacion()
        {
            InitializeComponent();
            loadData();
            dataGridView1.DataSource = Publicaciones.obtenerPublicaiones(0,20, null, null, null, null);
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
            List<DateTime> espectaculos = new List<DateTime>();
            Publicacion publi = new Publicacion
            {
                Descripcion = txtDescripcion.Text,
                DireccionEspectaculo = txtDireccion.Text,
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
            dtpEspectaculo.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            dtpPublicacion.Format = DateTimePickerFormat.Custom;
            dtpPublicacion.CustomFormat = "MM/dd/yyyy hh:mm:ss"; 
        }
        public void loadData()
        {
            List<ComboBoxItem> estados = Estados.obtenerEstados().Select(x => new ComboBoxItem { Text =x.descripcion, Value =x.codigo }).ToList();
            estados.ForEach(x => cmbEstado.Items.Add(x));

            List<ComboBoxItem> rubros = Rubros.obtenerRubros().Select(x => new ComboBoxItem { Text = x.Descripcion, Value = x.Id }).ToList();
            rubros.ForEach(x => cmbRubro.Items.Add(x));

            List<ComboBoxItem> grados = Grados.ObtenerTodosLosGrados().Select(x => new ComboBoxItem { Text = x.TipoGrado, Value = x.id}).ToList();
            grados.ForEach(x => cmbGrado.Items.Add(x));

           

        }
    }
}
