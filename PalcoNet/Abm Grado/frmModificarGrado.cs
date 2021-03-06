﻿using PalcoNet.Common;
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
        private Button botonSeleccionado { get; set; }
        private DataGridView dgv { get; set; }
        private List<Grado> listaGradosBD { get; set; }
        private Grado gradoViejo { get; set; }


        public frmModificarGrado(Button botonSeleccionado, DataGridView dgv)
        {
            InitializeComponent();

            this.botonSeleccionado = botonSeleccionado;
            this.dgv = dgv;          
            if (botonSeleccionado.Text == "Modificar")
            {
                //Genero la lista de visibilidades para usarla como referencia si hay algun cambio
                listaGradosBD = this.generarGradosBD(this.dgv);

                //Guardando la visibilidad a modificar
                gradoViejo = dgv.CurrentRow.DataBoundItem as Grado;

                //Cargando la form con los datos de la fila del DGV seleccionada
                //agregando al combo los codigos de grado
                this.cargarComboBoxCodigos();

                this.cargarForm(gradoViejo);
            }
        }

        private List<Grado> generarGradosBD(DataGridView dgv)
        {
            List<Grado> listaGrados = Grado.ObtenerTodosLosGrados();
            return listaGrados;
        }

        private void cargarForm(Grado grado)
        {
            this.txtNombre.Text = grado.Descripcion;
            this.txtCostoPublicacion.Text = Convert.ToString(grado.Costo_Publicacion);
            this.cmbGrado.SelectedItem = grado.TipoGrado;
        }

        private void cargarComboBoxCodigos()
        {
            int i = Convert.ToInt32(this.dgv.Rows[0].Cells[0].Value);

            while (i < this.dgv.RowCount)
            {
                this.cmbGrado.Items.Add(i);
                i++;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //si es nuevo
            if (this.botonSeleccionado.Text == "Nueva")
            {
                bool chequeado = this.chequearCampos();

                if (chequeado)
                {
                    if (!SqlConnector.existeString(txtNombre.Text, "PalcoNet.Grados", "Descripcion"))
                    {
                        //Datos del form
                        string nombre = this.txtNombre.Text;
                        decimal costo = Convert.ToDecimal(this.txtCostoPublicacion.Text);
                        string tipoGrado = this.cmbGrado.SelectedItem.ToString();

                        List<SqlParameter> parametros = new List<SqlParameter>();

                        SqlConnector.agregarParametro(parametros, "@descripcion", nombre);
                        SqlConnector.agregarParametro(parametros, "@costoPublicacion", costo);
                        SqlConnector.agregarParametro(parametros, "@tipoGrado", tipoGrado);

                        SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
                        paramRet.Direction = System.Data.ParameterDirection.Output;
                        parametros.Add(paramRet);

                        int idInsertada = (int)SqlConnector.ExecStoredProcedure("PalcoNet.AgregarGrado", parametros);
                        SqlConnector.cerrarConexion();

                        MessageBox.Show("¡Grado Agregado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                        MessageBox.Show("Ya existe un Grado con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            } 
            //si se quiere modificar
            else if (this.botonSeleccionado.Text == "Modificar")
            {
                bool chequeado = this.chequearCampos();

                if (chequeado)
                {
                    //Datos del form
                    string nombre = this.txtNombre.Text;
                    decimal costo = Convert.ToDecimal(this.txtCostoPublicacion.Text);
                    string tipoGrado = this.cmbGrado.SelectedItem.ToString();

                    Grado gradoNuevo = new Grado(tipoGrado, nombre, costo);

                    this.editarGrado(gradoNuevo, this.gradoViejo);
                    this.Close();                    
                }
            }
        }


        private void editarGrado(Grado gradoNuevo, Grado gradoViejo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            
            SqlConnector.agregarParametro(parametros, "@descripcion", gradoNuevo.Descripcion);
            SqlConnector.agregarParametro(parametros, "@costoPublicacion", gradoNuevo.Costo_Publicacion);

            //nombre viejo, para usarlo en el string
            String nombreViejo = gradoViejo.Descripcion;

            SqlConnector.agregarParametro(parametros, "@descripcionVieja", nombreViejo);

            //Exec storedProcedure
            SqlConnector.ExecStoredProcedureSinRet("PalcoNet.EditarGrado", parametros);
            SqlConnector.cerrarConexion();


            MessageBox.Show("¡Grado Modificado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool chequearCampos()
        {
            bool chequeado = false;

            //chequeo de campos obligatorios
            if (this.txtNombre.Text.Equals("") || this.txtCostoPublicacion.Text.Equals("") || this.cmbGrado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor complete los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                chequeado = true;

            return chequeado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
        }

        private void txtCostoPublicacionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCostoPublicacion.Text.Contains(','))
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

                if (e.KeyChar == ',' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }


        }
    }
}
