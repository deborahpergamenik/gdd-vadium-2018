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

namespace PalcoNet.Canje_Puntos
{
    public partial class frmCanjePuntos : Form
    {
        DataTable premios = new DataTable();
        int usuario_id = 0;
        int idCliente = 0;
        double puntos = 0;

        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmCanjePuntos(int _usuario_id, frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            InitializeComponent();
            this.usuario_id = _usuario_id;
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
        }

        private void frmCanjePuntos_Load(object sender, EventArgs e)
        {

            string queryPuntos = "SELECT premio_id, nombre, descripcion , stock, valor " +
                                                               "FROM VADIUM.PREMIO p " +
                                                               "WHERE p.stock > 0 ";
            if (!UserInstance.getUserInstance().esAdmin)
            {
                idCliente = (int)UserInstance.getUserInstance().clienteId;

                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros2, "@cliente_id", this.idCliente);
                SqlConnector.agregarParametro(listaParametros2, "@fecha", Configuration.getActualDate());
                SqlDataReader lector2 = SqlConnector.ejecutarReader("SELECT SUM(cantidad) AS cantidad " +
                                                                    "FROM VADIUM.PUNTOS " +
                                                                    "WHERE cliente_id = @cliente_id AND fechaVencimiento > @fecha " +
                                                                    "GROUP BY cliente_id", listaParametros2, SqlConnector.iniciarConexion());

                if (lector2.HasRows)
                {
                    lector2.Read();
                    puntos = Convert.ToDouble(lector2["cantidad"]);
                }
                queryPuntos = queryPuntos + "  AND p.valor < " + puntos ;
                SqlConnector.cerrarConexion();
                txtPuntos.Text = puntos.ToString();
            }
            else
            {
                MessageBox.Show("Usuario ADMIN. Solo puede tener visualización de los premios a canjear.", "Aviso");
            }

            SqlDataReader lector = SqlConnector.ejecutarReader(queryPuntos, SqlConnector.iniciarConexion());
            lector.Read();
            premios.Load(lector);
            SqlConnector.cerrarConexion();
            dgvCanjearPuntos.DataSource = premios;
            dgvCanjearPuntos.Columns["premio_id"].Visible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeleccionFuncionalidades.Show();
        }

        private void dgvCanjearPuntos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && !UserInstance.getUserInstance().esAdmin)
            {
                double costoPuntos = double.Parse(dgvCanjearPuntos.Rows[e.RowIndex].Cells["valor"].Value.ToString());
                int stock = (int)dgvCanjearPuntos.Rows[e.RowIndex].Cells["stock"].Value;
                if (stock == 0)
                    MessageBox.Show("No queda Stock disponible");
                else if (puntos < costoPuntos)
                    MessageBox.Show("No poseen puntos suficientes para este premio");
                else
                {
                    List<SqlParameter> parametros = new List<SqlParameter>();
                    SqlConnector.agregarParametro(parametros, "@cliente_id", idCliente);
                    SqlConnector.agregarParametro(parametros, "@premio_id", (int)dgvCanjearPuntos.Rows[e.RowIndex].Cells["premio_id"].Value);
                    SqlConnector.agregarParametro(parametros, "@fecha_actual", Configuration.getActualDate());
                    SqlConnector.ExecStoredProcedureSinRet("VADIUM.CANJEAR_PREMIO", parametros);
                    SqlConnector.cerrarConexion();

                    puntos -= (int)costoPuntos;
                    txtPuntos.Text = puntos.ToString();
                    dgvCanjearPuntos.Rows[e.RowIndex].Cells["stock"].Value = stock - 1;
                }
            }
        }
    }
}
