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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class frmGrado : Form
    {
        public string descripcionGrado { get; set; }
        public decimal comision { get; set; }
        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmGrado(Login.frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
            InitializeComponent();
            this.formatearDataGrid();
            this.cargarGrillaGrados();
        }

        public void cargarGrillaGrados()
        {
            this.dgvGrados.DataSource = Grados.ObtenerTodosLosGrados();
            this.dgvGrados.Refresh();
        }

        public void formatearDataGrid()
        {
            int widthBotones = 85;

            dgvGrados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGrados.RowHeadersVisible = false;

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

            dgvGrados.Columns.Add(botonesModificar);
            dgvGrados.Columns.Add(botonesEliminar);
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    frmModificarGrado frmEmpresa = new frmModificarGrado(Convert.ToInt32(dgvGrados.Rows[e.RowIndex].Cells[2].Value), this);
                    frmEmpresa.Show();
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Se eliminará el Grado " + Convert.ToString(dgvGrados.Rows[e.RowIndex].Cells[4].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        eliminarGrado(Convert.ToInt32(dgvGrados.Rows[e.RowIndex].Cells[2].Value));
                    }
                    cargarGrillaGrados();
                    break;
            }
        }

        public void eliminarGrado(int id)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@grado_id", id);
            SqlConnector.ejecutarQuery("DELETE VADIUM.GRADO WHERE grado_id = @grado_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Grado Eliminado.");
        }


        private void btnAgregarGrado_Click(object sender, EventArgs e)
        {
            if (chequearCampos())
            {
                cargarGrado();
                MessageBox.Show("Grado agregado con éxito.", "Registro exitoso");
                cargarGrillaGrados();
                txtDescripcionGrado.Text = "";
                txtComision.Text = "";
            }
        }

        public Boolean chequearCampos()
        {
            if (!campoVacio(txtDescripcionGrado) && !campoVacio(txtComision))
            {
                if (!SqlConnector.existeString(txtDescripcionGrado.Text, "VADIUM.GRADO", "descripcion"))
                {
                    if (numeroDecimal(txtComision.Text))
                    {
                        this.descripcionGrado = txtDescripcionGrado.Text;
                        this.comision = Convert.ToDecimal(txtComision.Text);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("La comisión ingresada no es válida.", "Error");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Descripción Grado ya existente", "Error");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                return false;
            }
        }

        public void cargarGrado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@comision", this.comision);
            SqlConnector.agregarParametro(listaParametros, "@descripcion", this.descripcionGrado);
            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.GRADO (comision, descripcion) VALUES (@comision, @descripcion)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public Boolean campoVacio(TextBox textbox)
        {
            return textbox.Text.Equals("");
        }

        public Boolean numeroDecimal(string txtComision)
        {
            bool value = false;
            if (Regex.IsMatch(txtComision, @"^\d+\.?\d*$"))
            {
                value = true;
            }
            return value;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
