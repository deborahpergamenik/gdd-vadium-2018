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
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT empresa_id, razonSocial FROM VADIUM.EMPRESA", listaParametros, SqlConnector.iniciarConexion());
            if (lector.HasRows())
            {
                while (lector.Read())
                {
                    int empId = Convert.ToInt32(lector["empresa_id"]);
                    cmbEmpresa.Items.Add(new ComboBoxItem { Text = lector["razonSocial"].ToString(), Value = empId });
                }

               
            }
            
            SqlConnector.cerrarConexion();
            MessageBox.Show("Ingresar Los la empresa de las compras a filtrar y luego de que se carguen las publicaciones ingresar seleccionar la publicacion a facturar");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidNumber(this.textBox1.Text))
            {
                int cant = Convert.ToInt32(textBox1.Text);
                buscar(cant);
            }
        }

        private bool ValidNumber(string text)
        {
            int outval;
            if (!int.TryParse(text, out outval))
            {
                MessageBox.Show("La cantidad debe ser un valor numerico");
                return false;
            }
            return true;
        }

        public void buscar(int cantidad)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@cantidad", cantidad);
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


        private void textboxNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                   && !char.IsDigit(e.KeyChar)
                   )
            {
                e.Handled = true;
            }
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            _frmSeleccionFuncionalidad.Show();
        }
    }
}
