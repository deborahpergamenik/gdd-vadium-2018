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
            public int IdUsuario { get; set; }
            public string RazonSocial { get; set; }

            public ResultadoEmpresa(int _IdUsuario, string _RazonSocial)
            {
                IdUsuario = _IdUsuario;
                RazonSocial = _RazonSocial;
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
                    resultado = buscarRazonSocial();
                    break;
                case 'C': // CUIT
                    resultado = buscarCUIT();
                    break;
                case 'E': // Email
                    resultado = buscarEmail();
                    break;
            }

            return resultado;
        }

        public int buscarRazonSocial()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@RazonSocial", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario FROM PalcoNet.Empresa WHERE RazonSocial = @RazonSocial", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
                    string RazonSocial = this.valor;

                    ResultadoEmpresa resultado = new ResultadoEmpresa(IdUsuario, RazonSocial);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarCUIT()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@CUIT", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario, RazonSocial FROM PalcoNet.Empresa WHERE CUIT = @CUIT", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
                    string RazonSocial = Convert.ToString(lector["RazonSocial"]);

                    ResultadoEmpresa resultado = new ResultadoEmpresa(IdUsuario, RazonSocial);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public int buscarEmail()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Email", this.valor);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario, RazonSocial FROM PalcoNet.Empresa WHERE Email = @Email", listaParametros, SqlConnector.iniciarConexion());

            int cantRes = 0;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
                    string RazonSocial = Convert.ToString(lector["RazonSocial"]);

                    ResultadoEmpresa resultado = new ResultadoEmpresa(IdUsuario, RazonSocial);
                    resultados.Add(resultado);
                }
            }

            SqlConnector.cerrarConexion();
            return cantRes;
        }

        public void formatearDataGrid()
        {
            int widthRazonSocial = 227;
            int widthBotones = 85;

            dgResultados.DataSource = resultados;
            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewColumn col_idUser = dgResultados.Columns[0];
            col_idUser.Visible = false;

            DataGridViewColumn col_razonSocial = dgResultados.Columns[1];
            col_razonSocial.Resizable = DataGridViewTriState.False;
            col_razonSocial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_razonSocial.Width = widthRazonSocial;

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
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", id);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET Estado = 0 WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Usuario inEstado.");
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    frmModificarEmpresa form1 = new frmModificarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value), this);
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
