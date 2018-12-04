using PalcoNet.Common;
using PalcoNet.Login;
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

namespace PalcoNet.Canje_Puntos
{
    public partial class frmCanjePuntos : Form
    {
        DataTable premios = new DataTable();
        int idUsuario = 0;
        int idCliente = 0;
        double puntos = 0;

        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmCanjePuntos(int _idUsuario, frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            InitializeComponent();
            this.idUsuario = _idUsuario;
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
        }

        private void frmCanjePuntos_Load(object sender, EventArgs e)
        {
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT * FROM VADIUM.PREMIO", SqlConnector.iniciarConexion());
            lector.Read();
            premios.Load(lector);
            SqlConnector.cerrarConexion();
            dgvCanjearPuntos.DataSource = premios;
            dgvCanjearPuntos.Columns["premioId"].Visible = false;


            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.idUsuario);
            SqlDataReader lector2 = SqlConnector.ejecutarReader("SELECT c.cliente_id " +
                                                                "FROM VADIUM.Cliente c" +
                                                                "JOIN Usuario u ON u.usuario_id = c.usuario_id" +
                                                                "WHERE c.usuario_id = @idUsuario AND u.usuario_activo = 1", listaParametros, SqlConnector.iniciarConexion());
            lector2.Read();
            idCliente = Convert.ToInt32(lector["cliente_id"]);
            SqlConnector.cerrarConexion();


            List<SqlParameter> listaParametros2 = new List<SqlParameter>();        
            SqlConnector.agregarParametro(listaParametros2, "@cliente_id", this.idCliente);
            SqlConnector.agregarParametro(listaParametros2, "@año", DateTime.Now.Year + 1);
            SqlDataReader lector3 = SqlConnector.ejecutarReader("SELECT SUM(cantidad) " +
                                                                "FROM VADIUM.PREMIO_POR_CLIENTE " +
                                                                "WHERE cliente_id = @cliente_id AND vencimiento = @año" +
                                                                "GROUP BY cliente_id", listaParametros2, SqlConnector.iniciarConexion());
            lector3.Read();
            puntos = Convert.ToDouble(lector["IdCliente"]);
            SqlConnector.cerrarConexion();
            txtPuntos.Text = puntos.ToString();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeleccionFuncionalidades.Show();
        }

        private void dgvCanjearPuntos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                double costoPuntos = double.Parse(dgvCanjearPuntos.Rows[e.RowIndex].Cells["puntos"].Value.ToString());
                int stock = (int)dgvCanjearPuntos.Rows[e.RowIndex].Cells["stock"].Value;
                if (stock == 0)
                    MessageBox.Show("No queda Stock disponible");
                else if (puntos < costoPuntos)
                    MessageBox.Show("No poseen puntos suficientes para este premio");
                else
                {
                    List<SqlParameter> parametros = new List<SqlParameter>();
                    SqlConnector.agregarParametro(parametros, "@id_Cliente", idCliente);
                    SqlConnector.agregarParametro(parametros, "@premioId", (int)dgvCanjearPuntos.Rows[e.RowIndex].Cells["premioId"].Value);
                    SqlConnector.agregarParametro(parametros, "@fechaActual", DateTime.Now);
                    //Exec storedProcedure
                    //Hacer insert en PREMIO_POR_CLIENTE
                    SqlConnector.ExecStoredProcedureSinRet("VADIUM.CanjearPremio", parametros);
                    SqlConnector.cerrarConexion();


                    puntos -= (int)costoPuntos;
                    txtPuntos.Text = puntos.ToString();
                    dgvCanjearPuntos.Rows[e.RowIndex].Cells["stock"].Value = stock - 1;
                }
            }
        }
    }
}
