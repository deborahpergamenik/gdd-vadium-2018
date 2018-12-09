using PalcoNet.Common;
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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class frmBuscarEmpresa : Form
    {
        public char filtro { get; set; }
        public string valor { get; set; }
        public int cantResultados { get; set; }

        public class ResultadoEmpresa
        {
            public int usuario_id { get; set; }
            public string razonSocial { get; set; }

            public ResultadoEmpresa(int _usuario_id, string _razonSocial)
            {
                usuario_id = _usuario_id;
                razonSocial = _razonSocial;
            }
        }

        public List<ResultadoEmpresa> resultados = new List<ResultadoEmpresa>();

        public frmBuscarEmpresa(char _filtro, string _valor)
        {
            this.filtro = _filtro;
            this.valor = _valor;

            InitializeComponent();

            this.cantResultados = cargarLista();
            formatearDataGrid();
        }

        public int cargarLista()
        {
            int resultado = 0;

            switch (filtro)
            {
                case 'R': // Razón Social
                    resultado = buscarrazonSocial();
                    break;
                case 'C': // cuit
                    resultado = buscarcuit();
                    break;
                case 'E': // mail
                    resultado = buscarmail();
                    break;
            }

            return resultado;
        }

        public int buscarrazonSocial()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@razonSocial", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.EMPRESA WHERE razonSocial = @razonSocial", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int usuario_id = Convert.ToInt32(lector["usuario_id"]);
                    string razonSocial = this.valor;

                    ResultadoEmpresa resultado = new ResultadoEmpresa(usuario_id, razonSocial);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarcuit()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@cuit", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id, razonSocial FROM VADIUM.EMPRESA WHERE cuit = @cuit", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int usuario_id = Convert.ToInt32(lector["usuario_id"]);
                    string razonSocial = Convert.ToString(lector["razonSocial"]);

                    ResultadoEmpresa resultado = new ResultadoEmpresa(usuario_id, razonSocial);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarmail()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@mail", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id, razonSocial FROM VADIUM.EMPRESA WHERE mail = @mail", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int usuario_id = Convert.ToInt32(lector["usuario_id"]);
                    string razonSocial = Convert.ToString(lector["razonSocial"]);

                    ResultadoEmpresa resultado = new ResultadoEmpresa(usuario_id, razonSocial);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public void formatearDataGrid()
        {
            int widthrazonSocial = 227;
            int widthBotones = 85;

            dgResultados.DataSource = resultados;
            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewColumn col_idUser = dgResultados.Columns[0];
            col_idUser.Visible = false;

            DataGridViewColumn col_razonSocial = dgResultados.Columns[1];
            col_razonSocial.Resizable = DataGridViewTriState.False;
            col_razonSocial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_razonSocial.Width = widthrazonSocial;

            DataGridViewButtonColumn botonesModificar = new DataGridViewButtonColumn();
            botonesModificar.HeaderText = "";
            botonesModificar.Text = "Modificar";
            botonesModificar.Name = "btnModificar";
            botonesModificar.Width = widthBotones;
            botonesModificar.UseColumnTextForButtonValue = true;
            botonesModificar.Resizable = DataGridViewTriState.False;

            DataGridViewButtonColumn botonesEliminar = new DataGridViewButtonColumn();
            botonesEliminar.HeaderText = "";
            botonesEliminar.Text = "Eliminar";
            botonesEliminar.Name = "btnEliminar";
            botonesEliminar.Width = widthBotones;
            botonesEliminar.UseColumnTextForButtonValue = true;
            botonesEliminar.Resizable = DataGridViewTriState.False;

            dgResultados.Columns.Add(botonesModificar);
            dgResultados.Columns.Add(botonesEliminar);
        }

        public void eliminarEmpresa(int id)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_activo = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Usuario inusuario_activo.");
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    frmModificarEmpresa form1 = new frmModificarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    this.Hide();
                    form1.Show();
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Se inhabilitará a la empresa " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[3].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        eliminarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    }
                    break;
            }
        }
    }
}
