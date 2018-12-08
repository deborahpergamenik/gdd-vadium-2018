using PalcoNet.Common;
using PalcoNet.Login;
using PalcoNet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class frmComprar : Form
    {
        int paginaActual;
        int cantPublicacionesPorPagina = 18; 
        int cantPublicacionesTotal;
        int ultimaPagina;
        string filtro;
        bool filtroRubros;
        static List<Rubro> rubros = new List<Rubro>();
        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmComprar(frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            InitializeComponent();
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
            paginaActual = 0;
            filtro = "";
            filtroRubros = false;
            contarPublicaciones();
            cargarPublicaciones();


            if (!chkDesde.Checked)
            {
                dateTimePickerDesde.CustomFormat = " ";
                dateTimePickerDesde.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePickerDesde.CustomFormat = null;
                dateTimePickerDesde.Format = DateTimePickerFormat.Long;
            }
            if (!chkHasta.Checked)
            {
                dateTimePickerHasta.CustomFormat = " ";
                dateTimePickerHasta.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePickerHasta.CustomFormat = null;
                dateTimePickerHasta.Format = DateTimePickerFormat.Long;
            }
        }

        public void cargarPublicaciones()
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

            List<Publicacion> listaPublicaciones = Publicaciones.obtenerPublicacionesPaginadas(desde, hasta, filtro, filtroRubros);
            Publicaciones_Datagrid.DataSource = listaPublicaciones;
            
            
            //AGREGAR COLUMNAS QUE SE CONSIDEREN NECESARIAS MOSTRAR / QUITAR LAS QUE NO IRÍAN
            Publicaciones_Datagrid.Columns["codigoEspectaculo"].Visible = false;
            Publicaciones_Datagrid.Columns["descripcion"].Visible = false;
            Publicaciones_Datagrid.Columns["fecha"].Visible = false;
            Publicaciones_Datagrid.Columns["fechaVencimiento"].Visible = false;
            Publicaciones_Datagrid.Columns["estado_id"].Visible = false;
            Publicaciones_Datagrid.Columns["direccion"].Visible = false;
            Publicaciones_Datagrid.Columns["rubro_id"].Visible = false;
            Publicaciones_Datagrid.Columns["grado_id"].Visible = false;
            Publicaciones_Datagrid.Columns["empresa_id"].Visible = false;

        }

        private void btnSiguientePag_Click(object sender, EventArgs e)
        {
            paginaActual = paginaActual + 1;
            cargarPublicaciones();

        }

        private void btnAnteriorPag_Click(object sender, EventArgs e)
        {

            paginaActual = paginaActual - 1;
            cargarPublicaciones();
        }

        private void btnPrimerPag_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            cargarPublicaciones();
        }

        private void btnUltimaPag_Click(object sender, EventArgs e)
        {
            paginaActual = ultimaPagina;
            cargarPublicaciones();
        }


        private void contarPublicaciones()
        {
            string commandtext = "SELECT COUNT (*) AS cant from VADIUM.PUBLICACION AS p " +
                                 "JOIN VADIUM.ESTADO ep ON e.codigo = p.estado_id ";
            if (filtroRubros)
                commandtext += "JOIN VADIUM.RUBRO_PUBLICACION rp ON p.codigoEspectaculo = rp.codigoEspectaculo ";

            commandtext += "WHERE e.Descripcion != 'Finalizada' ";

            if (filtro != "")
                commandtext += " AND " + filtro;

            SqlDataReader reader = SqlConnector.ejecutarReader(commandtext, SqlConnector.iniciarConexion());

            if (reader.HasRows)
            {
                reader.Read();
                cantPublicacionesTotal = Convert.ToInt32(reader["cant"]);
                ultimaPagina = cantPublicacionesTotal / cantPublicacionesPorPagina;

                if (ultimaPagina < 1)
                    ultimaPagina = 0;
            }

            SqlConnector.cerrarConexion();
        }

        private void btnAbrirPublicacion_Click(object sender, EventArgs e)
        {
            if (Publicaciones_Datagrid.SelectedRows.Count == 0)
                return;
            else
            {
                Publicacion unaPublicacion = Publicaciones_Datagrid.CurrentRow.DataBoundItem as Publicacion;
                frmDetallePublicacion detalleForm = new frmDetallePublicacion(unaPublicacion);
                detalleForm.ShowDialog();
                cargarPublicaciones();
            }

        }

        private void btnAgregarRubros_Click(object sender, EventArgs e)
        {
            frmAgregarRubro agregarRubros = new frmAgregarRubro(rubros);
            agregarRubros.ShowDialog();

            cargarTxtRubros();

        }

        private void cargarTxtRubros()
        {
            string str = "";

            for (int i = 0; i < rubros.Count; i++)
            {
                if (i == 0)
                    str += rubros[i].Descripcion;
                else
                    str += ", " + rubros[i].Descripcion;
            }

            txtRubros.Text = str;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            armarFiltro();
            contarPublicaciones();
            cargarPublicaciones();
        }


        private void armarFiltro()
        {
            filtro = "";
            filtroRubros = false;

            if (rubros != null)
            {
                for (int i = 0; i < rubros.Count; i++)
                {
                    filtroRubros = true;

                    if (i == 0)
                        filtro += " (";
                    else filtro += " or ";

                    filtro = filtro + "r.rubro_id = " + rubros[i].Id;

                    if (i == rubros.Count - 1)
                        filtro += " ) ";
                }
            }

            if (txtDescripcion.Text != "")
            {
                if (filtro != "")
                    filtro += "AND ";
                filtro += " p.descripcion LIKE  '%" + txtDescripcion.Text + "%' ";
            }


            DateTime fechaDesde;
            bool fechaDesdeNula;
            if (dateTimePickerDesde.Text == " ")
            {
                fechaDesdeNula = true;
                fechaDesde = Convert.ToDateTime(null);
            }
            else
            {
                fechaDesdeNula = false;
                fechaDesde = Convert.ToDateTime(dateTimePickerDesde.Text);
            }


            if (!fechaDesdeNula)
            {
                if (filtro != "")
                    filtro += "AND ";
                filtro += " p.fecha >= " + fechaDesde;
            }


            DateTime fechaHasta;
            bool fechaHastaNula;
            if (dateTimePickerHasta.Text == " ")
            {
                fechaHastaNula = true;
                fechaHasta = Convert.ToDateTime(null);
            }
            else
            {
                fechaHastaNula = false;
                fechaHasta = Convert.ToDateTime(dateTimePickerHasta.Text);
            }

            if (!fechaHastaNula)
            {
                if (filtro != "")
                    filtro += "AND ";
                filtro += " p.fecha <= " + fechaHasta;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtRubros.Text = "";
            rubros.Clear();

            paginaActual = 0;
            filtro = "";
            contarPublicaciones();
            cargarPublicaciones();

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeleccionFuncionalidades.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Publicaciones_Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmComprar_Load(object sender, EventArgs e)
        {

        }
    }
}
