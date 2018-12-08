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
        public frmSeleccionFuncionalidades _frmSeleccionFuncionalidad { get; set; }

        public frmHistorialCliente(frmSeleccionFuncionalidades frmSeleccionFuncionalidad)
        {
            InitializeComponent();
            this._frmSeleccionFuncionalidad = frmSeleccionFuncionalidad;
        }

        private void frmHistorialCliente_Load(object sender, EventArgs e)
        {
            if (UserInstance.getUserInstance().clienteId == null)
            {
                MessageBox.Show("No es cliente");
            }
            else
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@clieteId", (int)UserInstance.getUserInstance().clienteId);
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
    }
}
