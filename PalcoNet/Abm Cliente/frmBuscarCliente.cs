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
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }

            public ResultadoClientes(int idUsuario, string nombre, string apellido)
            {
                IdUsuario = idUsuario;
                Nombre = nombre;
                Apellido = apellido;
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
                case 'N': // Nombre
                    resultado = buscarNombre();
                    break;
                case 'A': // Apellido
                    resultado = buscarApellido();
                    break;
                case 'T': // Tipo de documento
                    resultado = buscarTipoDeDocumento();
                    break;
                case 'D': // Número de documento
                    resultado = buscarNumeroDeDocumento();
                    break;
                case 'E': // E-mail
                    resultado = buscarEmail();
                    break;
            }

            return resultado;
        }

        public int buscarNombre()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@nombre", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario, Nombre, Apellido FROM PalcoNet.Cliente WHERE Nombre = @nombre", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(IdUsuario, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarApellido()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@apellido", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario, Nombre, Apellido FROM PalcoNet.Cliente WHERE Apellido = @apellido", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(IdUsuario, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarTipoDeDocumento()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@numDoc", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario, Nombre, Apellido FROM PalcoNet.Cliente WHERE NumDoc = @numDoc", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(IdUsuario, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarNumeroDeDocumento()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@numDoc", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario, Nombre, Apellido FROM PalcoNet.Cliente WHERE NumDoc = @numDoc", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(IdUsuario, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarEmail()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@email", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario, Nombre, Apellido FROM PalcoNet.Cliente WHERE Email = @email", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
                    string Nombre = Convert.ToString(lector["Nombre"]);
                    string Apellido = Convert.ToString(lector["Apellido"]);

                    ResultadoClientes resultado = new ResultadoClientes(IdUsuario, Nombre, Apellido);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public void formatearDataGrid()
        {
            int widthNombre = 100;
            int widthApellido = 120;
            int widthBotones = 80;

            dgResultados.DataSource = resultados;
            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewColumn col_idUsuario = dgResultados.Columns[0];
            col_idUsuario.Visible = false;

            DataGridViewColumn col_nombre = dgResultados.Columns[1];
            col_nombre.Resizable = DataGridViewTriState.False;
            col_nombre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_nombre.Width = widthNombre;

            DataGridViewColumn col_apellido = dgResultados.Columns[2];
            col_apellido.Resizable = DataGridViewTriState.False;
            col_apellido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_apellido.Width = widthApellido;

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
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", id);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET Estado = 0 WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
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
