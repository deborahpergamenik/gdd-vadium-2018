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

namespace PalcoNet.Historial_Cliente
{
    public partial class frmHistorialCliente : Form
    {
        public frmSeleccionFuncionalidades frmSeleccionFuncionalidad { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }

        public frmHistorialCliente(frmSeleccionFuncionalidades _frmSeleccionFuncionalidad)
        {
            InitializeComponent();
            this.frmSeleccionFuncionalidad = _frmSeleccionFuncionalidad;
        }

        private void frmHistorialCliente_Load(object sender, EventArgs e)
        {
            if (UserInstance.getUserInstance().esAdmin)
            {
                MessageBox.Show("Usuario ADMIN. Solo puede tener visualización de la pantalla historial de Clientes", "Aviso");
            }
            else
            {                
                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros2, "@cliente_id", (int)UserInstance.getUserInstance().clienteId);
                SqlDataReader lector = SqlConnector.ejecutarReader("SELECT nombre, apellido FROM VADIUM.CLIENTE WHERE cliente_id = @cliente_id", listaParametros2, SqlConnector.iniciarConexion());
                lector.Read();
                NombreCliente = Convert.ToString(lector["nombre"]);
                ApellidoCliente = Convert.ToString(lector["apellido"]);
                SqlConnector.cerrarConexion();

                txtCliente.Text = NombreCliente + " " + ApellidoCliente;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@cliente_id", (int)UserInstance.getUserInstance().clienteId);
                String commandtext = "VADIUM.HistorialCliente";
                DataTable table = SqlConnector.obtenerDataTable(commandtext, "SP", listaParametros);
                if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                }
                else
                {
                    dgvHistorialCliente.DataSource = table;
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
           frmSeleccionFuncionalidad.Show();
        }
    }
}
