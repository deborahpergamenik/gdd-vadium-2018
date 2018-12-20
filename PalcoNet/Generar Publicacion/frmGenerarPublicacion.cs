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
        List<Ubicacion> ubicaciones = new List<Ubicacion>();
        public frmGenerarPublicacion()
        {
            InitializeComponent();
            
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
            int? empresaId =null;
            if(!UserInstance.userInstance.rol.nombre.ToLower().Contains("admin"))
                empresaId = UserInstance.getUserInstance().empresaId;
            dgvPublicaciones.DataSource = Publicaciones.ObtenerPublicacionesPorEmpresa(desde, hasta,  descripcion, estado, empresaId);
     
        }

        private void contarPublicaciones()
        {
            int? empresaId = null;
            if (!UserInstance.userInstance.rol.nombre.ToLower().Contains("admin"))
                empresaId = UserInstance.getUserInstance().empresaId;
            cantPublicacionesTotal = Publicaciones.getTotalCompras(null, descripcion, null, null, estado, empresaId);
            ultimaPagina = cantPublicacionesTotal / cantPublicacionesPorPagina;

            if (ultimaPagina < 1)
                ultimaPagina = 0;
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
            if (chbIngresoUnico.Checked)
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
            if (UserInstance.userInstance.rol.nombre.ToLower().Contains("admin"))
            {
                MessageBox.Show("No puede generar una publicacion porque  este usuario no tiene una empresa asociado");
            }
            if (ValidarInfo())
            {
                List<DateTime> espectaculos = new List<DateTime>();

                Publicacion publi = new Publicacion
                {
                    Descripcion = txtDescripcion.Text,
                    direccionEspectaculo = txtdireccion.Text,
                    FechaPublicacion = dtpPublicacion.Value,
                    precio = Convert.ToInt32( txtPrecio.Text),
                    stock = Convert.ToInt32(txtStock.Text),
                    estado_id = Convert.ToInt32(((ComboBoxItem)cmbEstado.SelectedItem).Value),
                    rubro_id = Convert.ToInt32(((ComboBoxItem)cmbRubro.SelectedItem).Value),
                    grado_id = Convert.ToInt32(((ComboBoxItem)cmbGrado.SelectedItem).Value),
                    ubicaiones = this.ubicaciones,
                    empresaId = Convert.ToInt32(txtEmpresa.Text)

                };
                if (chbIngresoUnico.Checked)
                {
                    if (validarFechas(dtpPublicacion.Value, dtpEspectaculo.Value))
                    {
                        publi.FechaEspectaculo = dtpEspectaculo.Value;
                        if (chbNuevo.Checked)
                        {
                            int? id = publi.save();
                            if (id == null)
                            {
                                MessageBox.Show("Hubo un error al guardar la publicacion, revise sus datos");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Se agrego un espectaculo correctamente, con sus " + ubicaciones.Count + " ubicaciones");
                                reload();
                            }
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(lblPublicacion.Text))
                            {
                                MessageBox.Show("Si desea modificar alguna publicacion, primero seleccione una de la tabla");
                            }
                            publi.CodigoPublicacion = Convert.ToInt32(lblCodEspectaculo.Text);
                            int? id = publi.update();
                            if (id == null)
                            {
                                MessageBox.Show("Hubo un error al modificar la publicacion, revise sus datos");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Se modifico un espectaculo correctamente");
                                reload();
                            }
                        }
                       
                    }
                }
                else
                {
                    if (ValidLotes(txtLotes.Text))
                    {
                        DateTime? lastDate = dtpPublicacion.Value;
                        for (int i = 0; i < Convert.ToInt32(txtLotes.Text); i++)
                        {
                            using (var form = new frmPublicaiconesPorLotes(lastDate))
                            {
                                form.ShowDialog();
                                lastDate = form.espectaculo;
                            }
                            espectaculos.Add((DateTime)lastDate);
                        }
                        int cantOk = publi.save(espectaculos);
                        MessageBox.Show("Se agregaron " +cantOk +" de un espectaculo correctamente, con sus " + ubicaciones.Count + " ubicaciones respectivamente");
                        reload();
                    }
                }
            }
        }

        private void reload()
        {
            clearAll();
            loadData();
            txtDescripcion.Text = "";
            descripcion = "";
            paginaActual = 0;
            contarPublicaciones();
            cargarPublicaciones();
        }

        private bool ValidLotes(string p)
        {
            if (String.IsNullOrEmpty(p))
            {
                MessageBox.Show("Debe asignar un valor a la cantidad de lotes  o definir que solo va a ser una publicacion");
                return false;
            }
            int n;
            if (!int.TryParse(p, out n))
            {
                MessageBox.Show("El campo cantidad debe ser numerico");
                return false;
            }
            return true;
        }

        private bool ValidarInfo( )
        {
            if (String.IsNullOrEmpty(txtdireccion.Text) || String.IsNullOrEmpty(txtDescripcion.Text) || String.IsNullOrEmpty(txtPrecio.Text) || cmbEstado.SelectedItem == null|| cmbGrado.SelectedItem == null|| cmbRubro.SelectedItem == null )
            { 
                MessageBox.Show("Faltan completar datos");
                return false;
            }
            int p;
            string val = txtPrecio.Text;
            if (!int.TryParse(val, out p))
            {
                MessageBox.Show("El precio no es valido");
                return false;
            }
            if (Configuration.getActualDate().CompareTo(dtpPublicacion.Value) > 0)
            {
                MessageBox.Show("La fecha de publicacion debe ser posterior a la de hoy 30/12/2018");
                return false;
            }
           
            return true;
        }

        private bool validarFechas(DateTime publi, DateTime evento)
        {
            if (publi.CompareTo(evento) > 0 || publi.CompareTo(evento) == 0)
            {
                MessageBox.Show("La fecha de publicacion debe ser anterior a la del evento");
                return false;
            }
            return true;
        }


        public void loadInitial()
        {
            chbNuevo.Checked = true;
            chbIngresoUnico.Checked = true;
            txtLotes.Visible = false;
            lblLotes.Visible = false;
            dtpEspectaculo.Visible = true;
            lblEspectaculo.Visible = true;
            lotes = false;
            txtStock.Text = "0";
            ubicaciones.Clear();
        }
        private void frmGenerarPublicacion_Load(object sender, EventArgs e)
        {
            loadData();
            contarPublicaciones();
            cargarPublicaciones();
            loadInitial();

            dtpEspectaculo.Format = DateTimePickerFormat.Custom;
            dtpEspectaculo.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            dtpEspectaculo.Value = Configuration.getActualDate();
            dtpPublicacion.Format = DateTimePickerFormat.Custom;
            dtpPublicacion.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            dtpPublicacion.Value = Configuration.getActualDate();
            
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
            if (UserInstance.getUserInstance().empresaId != null)
                txtEmpresa.Text = UserInstance.getUserInstance().empresaId.ToString();

            dtpEspectaculo.Format = DateTimePickerFormat.Custom;
            dtpEspectaculo.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            dtpPublicacion.Format = DateTimePickerFormat.Custom;
            dtpPublicacion.CustomFormat = "dd/MM/yyyy hh:mm:ss";

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
            if (chbNuevo.Checked)
            {
                MessageBox.Show("Si se quiere editar una fila, primero deseleccione el checkbox 'Nuevo' ");
                return;
            }
            if (UserInstance.getUserInstance().empresaId == null)
            {
                MessageBox.Show("Solamente una empresa puede modificar una publicacion");
            }
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
                txtPrecio.Text = dgvPublicaciones[14, row].Value.ToString();
                txtEmpresa.Text = dgvPublicaciones[10, row].Value.ToString();
                txtStock.Text = dgvPublicaciones[13, row].Value.ToString();
                lblCodEspectaculo.Text = dgvPublicaciones[0, row].Value.ToString();
                cmbRubro.SelectedItem = new ComboBoxItem {Value = Convert.ToInt32(dgvPublicaciones[4, row].Value), Text = dgvPublicaciones[5, row].Value.ToString() };
                cmbRubro.SelectedText = null;
                cmbRubro.SelectedText = dgvPublicaciones[5, row].Value.ToString();
                cmbGrado.SelectedItem = new ComboBoxItem { Value = Convert.ToInt32(dgvPublicaciones[9, row].Value), Text = dgvPublicaciones[7, row].Value.ToString() };
                cmbRubro.SelectedText = null;
                cmbGrado.SelectedText = dgvPublicaciones[7, row].Value.ToString();
                cmbEstado.SelectedItem = new ComboBoxItem { Value = Convert.ToInt32(dgvPublicaciones[11, row].Value), Text = dgvPublicaciones[12, row].Value.ToString() };
                cmbRubro.SelectedText = null;
                cmbEstado.SelectedText = dgvPublicaciones[12, row].Value.ToString();
                

                string date = dgvPublicaciones[3, row].Value.ToString();
                DateTime datetm = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dtpPublicacion.Value = datetm;
                date = dgvPublicaciones[2, row].Value.ToString();
                datetm = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dtpEspectaculo.Value = datetm;
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
                chbIngresoUnico.Enabled = false;
                txtLotes.Enabled = false;
                chbNuevo.Checked = false;
            }
        
        }
        public void changehabilityALl(bool enable)
        {
            txtDescripcion.Enabled = enable;
            txtdireccion.Enabled = enable;
            txtPrecio.Enabled = enable;
            cmbRubro.Enabled = enable;
            cmbGrado.Enabled = enable;
            cmbEstado.Enabled = enable;
            dtpPublicacion.Enabled = enable;
            dtpEspectaculo.Enabled = enable;
            chbIngresoUnico.Enabled = enable;
            txtLotes.Enabled = enable;
            chbNuevo.Checked = enable;
        }
        public void clearAll()
        {
            txtDescripcion.Text = "";
            txtdireccion.Text = "";
            txtPrecio.Text = "";
            txtEmpresa.Text = "";
            txtStock.Text = "";
            loadData();
        }

        private void btnAgregarUbicaciones_Click(object sender, EventArgs e)
        {
            using (var form =  new frmAsignarUbicaciones())
            {
                form.ShowDialog();
                ubicaciones = form.ubicacionesCreadas;
                txtStock.Text = ubicaciones.Count.ToString();
            }
           
           
        }

        private void chbNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNuevo.Checked)
            {
                changehabilityALl(true);
                btnAgregarUbicaciones.Enabled = true;
                clearAll();
            }
            else 
            {
                btnAgregarUbicaciones.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clearAll();

        }
    }
}
