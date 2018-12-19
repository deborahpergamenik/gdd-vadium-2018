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
    { int paginaActual;
        int cantPublicacionesPorPagina = 18; 
        int cantPublicacionesTotal;
        int ultimaPagina;
        string descripcion;
       
        DateTime? start = null;
        DateTime? finish = null;
        static List<int> rubros = new List<int>();
        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmComprar(frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            InitializeComponent();
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
            paginaActual = 0;
          
            contarPublicaciones();
            cargarPublicaciones();
            cargarRubros();


            if (!chkDesde.Checked)
            {
                //dateTimePickerDesde.CustomFormat = " ";
                dateTimePickerDesde.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                //dateTimePickerDesde.CustomFormat = null;
                dateTimePickerDesde.Format = DateTimePickerFormat.Long;
            }
            if (!chkHasta.Checked)
            {
                //dateTimePickerHasta.CustomFormat = " ";
                dateTimePickerHasta.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                //dateTimePickerHasta.CustomFormat = null;
                dateTimePickerHasta.Format = DateTimePickerFormat.Long;
            }
        }

        private void cargarRubros()
        {
            Rubros.obtenerRubros().ForEach(x => cmbRubros.Items.Add(new ComboBoxItem { Text =x.Descripcion, Value=x.Id }));
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
            Publicaciones_Datagrid.DataSource = Publicaciones.obtenerPublicaiones(desde, hasta, rubros, descripcion, start, finish);
     

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

        private void btnUltimaPag_Click(object sender, EventArgs e)
        {
            paginaActual = ultimaPagina;
            contarPublicaciones();
            cargarPublicaciones();
        }


        private void contarPublicaciones()
        {
            cantPublicacionesTotal = Publicaciones.getTotal(rubros, descripcion, start, finish);;
            ultimaPagina = cantPublicacionesTotal / cantPublicacionesPorPagina;

            if (ultimaPagina < 1)
                ultimaPagina = 0;
            

        }

        private void btnAbrirPublicacion_Click(object sender, EventArgs e)
        {
            if (UserInstance.userInstance.rol.nombre.ToLower().Contains("admin"))
            {
                MessageBox.Show("No puede generar una publicacion porque  este usuario no tiene una empresa asociado");
                return;
            }
            if (Publicaciones_Datagrid.SelectedRows.Count == 0)
                return;
            else
            {
                var row =  Publicaciones_Datagrid.SelectedRows[0];
                var cell = row.Cells[0];
                var val = cell.Value;
                int codigoPublicacion = Convert.ToInt32( val);
                frmDetallePublicacion detalleForm = new frmDetallePublicacion(codigoPublicacion);
                detalleForm.ShowDialog();
                this.Hide();
            }

        }

        private void btnAgregarRubros_Click(object sender, EventArgs e)
        {
            //frmAgregarRubro agregarRubros = new frmAgregarRubro(rubros);
            //agregarRubros.ShowDialog();

            //cargarTxtRubros();

        }

        //private void cargarTxtRubros()
        //{
        //    string str = "";

        //    for (int i = 0; i < rubros.Count; i++)
        //    {
        //        if (i == 0)
        //            str += rubros[i].Descripcion;
        //        else
        //            str += ", " + rubros[i].Descripcion;
        //    }

        //    txtRubros.Text = str;
        //}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            paginaActual = 0;

            if (chkDesde.Checked)
               start = dateTimePickerDesde.Value;
            if (chkHasta.Checked)
                finish = dateTimePickerHasta.Value;
            descripcion = txtDescripcion.Text;
            foreach (ComboBoxItem item in lstRubros.Items)
            {
                rubros.Add((int)item.Value);
            }
            contarPublicaciones();
            cargarPublicaciones();
        }


       

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            cmbRubros.SelectedValue = null;
            rubros.Clear();

            paginaActual = 0;
            
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

        private void cmbRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem rubro = (ComboBoxItem)cmbRubros.SelectedValue;
            lstRubros.Items.Add(rubro);
        }

        private void lstRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = lstRubros.SelectedIndex;
            lstRubros.Items.Remove(select);
        }

        private void chkDesde_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
