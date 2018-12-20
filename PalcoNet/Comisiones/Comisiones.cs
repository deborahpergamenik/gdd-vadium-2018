using PalcoNet.Common;
using PalcoNet.Login;
using PalcoNet.Model;
using System;
using System.Collections.Generic;
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

namespace PalcoNet.Comisiones
{
    public partial class Comisiones : Form
    {
        DataTable compras = new DataTable();
        public frmSeleccionFuncionalidades _frmSeleccionFuncionalidad { get; set; }

        public Comisiones(frmSeleccionFuncionalidades frmSeleccionFuncionalidad)
        {
            InitializeComponent();
            this._frmSeleccionFuncionalidad = frmSeleccionFuncionalidad;
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@cantidad", this.textBox1.Text);
            String commandtext = "VADIUM.obtenerCompras";
            DataTable table = SqlConnector.obtenerDataTable(commandtext, "SP", listaParametros);
            this.dataGridView1.DataSource = table;
            dataGridView1.Update();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtSource = (DataTable)dataGridView1.DataSource;

            dt.Columns.Add("id");
            foreach (DataRow row in dtSource.Rows) {
                dt.Rows.Add(row["id"].ToString());
            }
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@compras", dt);
            SqlConnector.ExecStoredProcedureSinRet("VADIUM.crearFactura", listaParametros2);
            SqlConnector.cerrarConexion();
            
            //vuelvo a cargar el DG
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@cantidad", this.textBox1.Text);
            DataTable table = SqlConnector.obtenerDataTable( "VADIUM.obtenerCompras", "SP", listaParametros);
            this.dataGridView1.DataSource = table;
            dataGridView1.Update();

        }
    }
}
