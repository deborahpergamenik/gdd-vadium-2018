using PalcoNet.Common;
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

namespace PalcoNet.Abm_Grado
{
    public partial class frmModificarGrado : Form
    {
        public int grado_id { get; set; }
        public decimal comision { get; set; }
        public string descripcionGrado { get; set; }
        public frmGrado frmGrado { get; set; }


        public frmModificarGrado(int _grado_id, frmGrado _frmGrado)
        {
            this.grado_id = _grado_id;
            this.frmGrado = _frmGrado;

            InitializeComponent();
            cargarDatosGrado();
            cargarDatosViejos();
        }


        public void cargarDatosGrado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@grado_id", this.grado_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT comision, descripcion FROM VADIUM.GRADO WHERE grado_id = @grado_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            txtDescripcionGrado.Text = Convert.ToString(lector["descripcion"]);
            txtComision.Text = Convert.ToString(lector["comision"]);

            SqlConnector.cerrarConexion();
        }


        public void cargarDatosViejos()
        {
            this.descripcionGrado = txtDescripcionGrado.Text;
            this.comision = Convert.ToDecimal(txtComision.Text);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string resumenModificaciones = "Se han modificado los campos:";
            string resumenErrores = "No se han podido modificar los campos:";

            Boolean modificacion = false;
            Boolean error = false;

            if (cambioString(this.descripcionGrado, txtDescripcionGrado.Text))
            {
                if (!txtDescripcionGrado.Text.Equals("") && !SqlConnector.existeString(txtDescripcionGrado.Text, "VADIUM.GRADO", "descripcion"))
                {
                    cambiarStringGrados("descripcion", txtDescripcionGrado.Text);
                    resumenModificaciones = resumenModificaciones + "\nDescripcion Grado";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nDescripción Grado (no ingresada o ya existente)";
                    error = true;
                }
            }

            if (cambioDecimal(this.comision, Convert.ToDecimal(txtComision.Text)))
            {
                if (!txtDescripcionGrado.Text.Equals(""))
                {
                    cambiarDecimalGrados("comision", Convert.ToDecimal(txtComision.Text));
                    resumenModificaciones = resumenModificaciones + "\nComision";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nComision no ingresada";
                    error = true;
                }
            }

            if (modificacion)
            {
                MessageBox.Show(resumenModificaciones);
            }

            if (error)
            {
                MessageBox.Show(resumenErrores);
            }

            if (modificacion || error)
            {
                frmGrado.cargarGrillaGrados();
                this.Close();                
            }

        }


        public Boolean cambioString(string string1, string string2)
        {
            return !string1.Equals(string2);
        }

        public Boolean cambioDecimal(decimal decimal1, decimal decimal2)
        {
            if (decimal1 == decimal2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtComisionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtComision.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }


        public void cambiarStringGrados(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@grado_id", this.grado_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.GRADO SET " + columna + " = @Valor WHERE grado_id = @grado_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }


        public void cambiarDecimalGrados(string columna, decimal valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@grado_id", this.grado_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.GRADO SET " + columna + " = @Valor WHERE grado_id = @grado_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
