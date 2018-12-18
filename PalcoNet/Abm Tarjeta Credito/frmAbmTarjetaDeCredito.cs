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

namespace PalcoNet.Abm_Tarjeta_Credito
{
    public partial class frmAbmTarjetaDeCredito : Form
    {
        public string numeroTarjeta { get; set; }
        public string banco { get; set; }
        public string codigoSeguridad { get; set; }
        public string tipo { get; set; }
        public int cliente_id { get; set; }
        public string mesVencimiento { get; set; }
        public string anioVencimiento { get; set; }
        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmAbmTarjetaDeCredito(frmSeleccionFuncionalidades _frmSeleccionFuncionalidades, int  _cliente_id)
        {
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
            this.cliente_id = _cliente_id;
            InitializeComponent();
            setearComboBoxes();
            this.formatearDataGrid();
            this.cargarGrillaTarjetas();
        }

        public void setearComboBoxes()
        {
            llenarCmbMes();
            llenarCmbAno();
            llenarCmbTipos();
        }

        public void llenarCmbMes()
        {
            int i;
            for (i = 01; i <= 12; i++)
            {
                this.cmbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCmbAno()
        {
            int i;
            for (i = 2018; i <= 2030; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void llenarCmbTipos()
        {
            this.cmbTipo.Items.Add("VISA");
            this.cmbTipo.Items.Add("MASTER CARD");
            this.cmbTipo.Items.Add("AMERICAN EXPRESS");
        }

        public void cargarGrillaTarjetas()
        {
            this.dgvTarjetas.DataSource = Tarjeta.ObtenerTodasLasTarjetas(cliente_id);
            this.dgvTarjetas.Refresh();
        }

        public void formatearDataGrid()
        {
            int widthBotones = 85;

            dgvTarjetas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTarjetas.RowHeadersVisible = false;

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

            dgvTarjetas.Columns.Add(botonesModificar);
            dgvTarjetas.Columns.Add(botonesEliminar);
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    frmModificarTarjetaDeCredito frmEmpresa = new frmModificarTarjetaDeCredito(Convert.ToInt32(dgvTarjetas.Rows[e.RowIndex].Cells[2].Value),Convert.ToInt32(dgvTarjetas.Rows[e.RowIndex].Cells[7].Value), this);
                    frmEmpresa.Show();
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Se eliminará la Tarjeta " + Convert.ToString(dgvTarjetas.Rows[e.RowIndex].Cells[3].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        eliminarTarjeta(dgvTarjetas.Rows[e.RowIndex].Cells[2].Value.ToString(), Convert.ToInt32(dgvTarjetas.Rows[e.RowIndex].Cells[7].Value));
                    }
                    cargarGrillaTarjetas();
                    break;
            }
        }

        public void eliminarTarjeta(string tarjetaId, int clienteId)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@tarjeta_id", tarjetaId);
            SqlConnector.agregarParametro(listaParametros, "@cliente_id", clienteId);
            SqlConnector.ejecutarQuery("DELETE VADIUM.TARJETADECREDITO WHERE tarjeta_id = @tarjeta_id AND cliente_id = @cliente_id ", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Tarjeta Eliminada.");
        }


        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            if (chequearCampos())
            {
                cargarTarjeta();
                MessageBox.Show("Tarjeta agregada con éxito.", "Registro exitoso");
                cargarGrillaTarjetas();
                cmbTipo.SelectedIndex = -1;
                mskNumeroTarjeta.Text = "";
                mskCodSeguridad.Text = "";
                cmbMes.SelectedIndex = -1;
                cmbAno.SelectedIndex = -1;
            }
        }

        public Boolean chequearCampos()
        {
            if (!campoVacio(mskNumeroTarjeta) && !campoVacio(mskCodSeguridad) && !(cmbMes.SelectedIndex == -1) && !(cmbAno.SelectedIndex == -1) && !(cmbTipo.SelectedIndex == -1))
            {
                if (mskNumeroTarjeta.MaskCompleted && mskCodSeguridad.MaskCompleted)
                {
                    if (!SqlConnector.existenSimultaneamente(mskNumeroTarjeta.Text, cliente_id.ToString(), "VADIUM.TARJETADECREDITO", "nroTarjeta", "cliente_id"))
                    {
                        this.numeroTarjeta = mskNumeroTarjeta.Text;
                        this.banco = txtBanco.Text;
                        this.codigoSeguridad = mskCodSeguridad.Text;
                        this.tipo = cmbTipo.SelectedItem.ToString();
                        this.mesVencimiento = cmbMes.SelectedItem.ToString();
                        this.anioVencimiento = cmbAno.SelectedItem.ToString();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("El número de tarjeta ingresada ya existente", "Error");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Número de Tarjeta y Codigo de Seguridad deben estar completos", "Error");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                return false;
            }
        }

        public void cargarTarjeta()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@nroTarjeta", this.numeroTarjeta);
            SqlConnector.agregarParametro(listaParametros, "@banco", this.banco);
            SqlConnector.agregarParametro(listaParametros, "@codSeguridad", this.codigoSeguridad);
            SqlConnector.agregarParametro(listaParametros, "@tipo", this.tipo);
            SqlConnector.agregarParametro(listaParametros, "@cliente_id", this.cliente_id);
            SqlConnector.agregarParametro(listaParametros, "@mesVencimiento", this.mesVencimiento);
            SqlConnector.agregarParametro(listaParametros, "@anioVencimiento", this.anioVencimiento);
            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.TARJETADECREDITO (nroTarjeta, banco, codSeguridad, tipo, cliente_id, mesVencimiento, anioVencimiento) " +
                                       "VALUES (@nroTarjeta, @banco, @codSeguridad, @tipo, @cliente_id, @mesVencimiento, @anioVencimiento)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public Boolean campoVacio(MaskedTextBox textbox)
        {
            return textbox.Text.Equals("");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeleccionFuncionalidades.Show();
        }
    }
}
