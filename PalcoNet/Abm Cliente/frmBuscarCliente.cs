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

namespace PalcoNet.Abm_Cliente
{
    public partial class frmBuscarCliente : Form
    {
        public char filtro { get; set; }
        public string valor { get; set; }
        public int cantResultados { get; set; }

        public class ResultadoClientes
        {
            public int usuario_id { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }

            public ResultadoClientes(int usuario_id, string nombre, string apellido)
            {
                usuario_id = usuario_id;
                nombre = nombre;
                apellido = apellido;
            }
        }

        public List<ResultadoClientes> resultados = new List<ResultadoClientes>();

        public frmBuscarCliente(char _filtro, string _valor)
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
                case 'N': // nombre
                    resultado = buscarnombre();
                    break;
                case 'A': // apellido
                    resultado = buscarapellido();
                    break;
                case 'T': // Tipo de documento
                    resultado = buscarTipoDeDocumento();
                    break;
                case 'D': // Número de documento
                    resultado = buscarNumeroDeDocumento();
                    break;
                case 'E': // E-mail
                    resultado = buscarmail();
                    break;
            }

            return resultado;
        }

        public int buscarnombre()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@nombre", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id, nombre, apellido FROM VADIUM.CLIENTE WHERE nombre = @nombre", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int usuario_id = Convert.ToInt32(lector["usuario_id"]);
                    string nombre = Convert.ToString(lector["nombre"]);
                    string apellido = Convert.ToString(lector["apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(usuario_id, nombre, apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarapellido()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@apellido", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id, nombre, apellido FROM VADIUM.CLIENTE WHERE apellido = @apellido", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int usuario_id = Convert.ToInt32(lector["usuario_id"]);
                    string nombre = Convert.ToString(lector["nombre"]);
                    string apellido = Convert.ToString(lector["apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(usuario_id, nombre, apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarTipoDeDocumento()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@numeroDocumento", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id, nombre, apellido FROM VADIUM.CLIENTE WHERE numeroDocumento = @numeroDocumento", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int usuario_id = Convert.ToInt32(lector["usuario_id"]);
                    string nombre = Convert.ToString(lector["nombre"]);
                    string apellido = Convert.ToString(lector["apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(usuario_id, nombre, apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarNumeroDeDocumento()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@numeroDocumento", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id, nombre, apellido FROM VADIUM.CLIENTE WHERE numeroDocumento = @numeroDocumento", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int usuario_id = Convert.ToInt32(lector["usuario_id"]);
                    string nombre = Convert.ToString(lector["nombre"]);
                    string apellido = Convert.ToString(lector["apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(usuario_id, nombre, apellido);
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
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id, nombre, apellido FROM VADIUM.CLIENTE WHERE mail = @mail", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int usuario_id = Convert.ToInt32(lector["usuario_id"]);
                    string nombre = Convert.ToString(lector["nombre"]);
                    string apellido = Convert.ToString(lector["apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(usuario_id, nombre, apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public void formatearDataGrid()
        {
            int widthnombre = 100;
            int widthapellido = 120;
            int widthBotones = 80;

            dgResultados.DataSource = resultados;
            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewColumn col_usuario_id = dgResultados.Columns[0];
            col_usuario_id.Visible = false;

            DataGridViewColumn col_nombre = dgResultados.Columns[1];
            col_nombre.Resizable = DataGridViewTriState.False;
            col_nombre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_nombre.Width = widthnombre;

            DataGridViewColumn col_apellido = dgResultados.Columns[2];
            col_apellido.Resizable = DataGridViewTriState.False;
            col_apellido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_apellido.Width = widthapellido;

            DataGridViewButtonColumn botonesModificar = new DataGridViewButtonColumn();
            botonesModificar.HeaderText = "";
            botonesModificar.Text = "Modificar";
            botonesModificar.Name = "bMod";
            botonesModificar.Width = widthBotones;
            botonesModificar.UseColumnTextForButtonValue = true;
            botonesModificar.Resizable = DataGridViewTriState.False;

            DataGridViewButtonColumn botonesEliminar = new DataGridViewButtonColumn();
            botonesEliminar.HeaderText = "";
            botonesEliminar.Text = "Eliminar";
            botonesEliminar.Name = "bElim";
            botonesEliminar.Width = widthBotones;
            botonesEliminar.UseColumnTextForButtonValue = true;
            botonesEliminar.Resizable = DataGridViewTriState.False;

            dgResultados.Columns.Add(botonesModificar);
            dgResultados.Columns.Add(botonesEliminar);
        }

        public void eliminarCliente(int id)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_activo = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Usuario inhabilitado.");
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    frmModificarCliente frmCliente = new frmModificarCliente(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value), this);
                    this.Hide();
                    frmCliente.Show();
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Se inhabilitará al cliente " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[3].Value) + ", " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[4].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        eliminarCliente(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    }
                    break;
            }
        }
    }
}
