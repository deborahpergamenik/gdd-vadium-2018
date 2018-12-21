using PalcoNet.Common;
using PalcoNet.Comprar;
using PalcoNet.Model;
using PalcoNet.Registro_de_Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class frmAgregarTarjetaDeCredito : Form
    {
        public string numeroTarjeta { get; set; }
        public string banco { get; set; }
        public string codigoSeguridad { get; set; }
        public string tipo { get; set; }
        public int cliente_id { get; set; }
        public string mesVencimiento { get; set; }
        public string anioVencimiento { get; set; }
        public frmAbmCliente frmAbmCliente { get; set; }
        public frmModificarCliente frmModificarCliente { get; set; }
        public frmDetallePublicacion frmDetallePublicacion { get; set; }
        public frmRegistroUsuarioCliente frmRegistroUsuarioCliente { get; set; }
        public string tipoRegistroDeTarjeta { get; set; }


        public frmAgregarTarjetaDeCredito(frmRegistroUsuarioCliente _frmRegistroUsuarioCliente)
        {
            this.frmRegistroUsuarioCliente = _frmRegistroUsuarioCliente;
            InitializeComponent();
            setearComboBoxes();
        }

        public frmAgregarTarjetaDeCredito(frmAbmCliente _frmAbmCliente)
        {
            this.frmAbmCliente = _frmAbmCliente;
            InitializeComponent();
            setearComboBoxes();
        }


        public frmAgregarTarjetaDeCredito(frmDetallePublicacion _frmDetallePublicacion)
        {
            this.frmDetallePublicacion = _frmDetallePublicacion;
            InitializeComponent();
            setearComboBoxes();
        }

        public frmAgregarTarjetaDeCredito(frmModificarCliente _frmModificarCliente, Tarjeta tarjeta, string registroDeTarjeta)
        {
            if (registroDeTarjeta == "Nuevo")
            {
                this.frmModificarCliente = _frmModificarCliente;
                tipoRegistroDeTarjeta = registroDeTarjeta;
                InitializeComponent();
                setearComboBoxes();
            }
            else if (registroDeTarjeta == "Modificar")
            {
                this.frmModificarCliente = _frmModificarCliente;
                tipoRegistroDeTarjeta = registroDeTarjeta;
                InitializeComponent();
                setearComboBoxes();
                mskNumeroTarjeta.Text = tarjeta.NumeroTarjeta;
                txtBanco.Text = tarjeta.Banco;
                mskCodSeguridad.Text = tarjeta.CodigoSeguridad;
                cmbTipo.SelectedItem = tarjeta.Tipo;
                cmbMes.SelectedItem = tarjeta.MesVencimiento;
                cmbAno.SelectedItem = tarjeta.AnioVencimiento;
            }
        }

        public frmAgregarTarjetaDeCredito()
        {
            InitializeComponent();
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

        private void btnAsociarTarjeta_Click(object sender, EventArgs e)
        {
            if (chequearCampos())
            {
                Tarjeta tarjeta = new Tarjeta(null, this.numeroTarjeta, this.banco, this.codigoSeguridad, this.tipo, 0, this.mesVencimiento, this.anioVencimiento);

                if (frmRegistroUsuarioCliente != null)
                {
                    frmRegistroUsuarioCliente.tarjetaAsociada = tarjeta;
                }
                else if (frmAbmCliente != null)
                {
                    frmAbmCliente.tarjetaAsociada = tarjeta;
                }
                else if (frmModificarCliente != null)
                {
                    frmModificarCliente.tarjetaAsociada = tarjeta;
                }
                else
                {
                    frmDetallePublicacion.tarjetaAsociada = tarjeta;
                }

                MessageBox.Show("Asociación de tarjeta realizada con éxito.", "Asociación tarjeta exitoso");
                cmbTipo.SelectedIndex = -1;
                mskNumeroTarjeta.Text = "";
                mskCodSeguridad.Text = "";
                cmbMes.SelectedIndex = -1;
                cmbAno.SelectedIndex = -1;
                this.Hide();

                if (frmRegistroUsuarioCliente != null)
                {
                    frmRegistroUsuarioCliente.Show();
                }
                else if (frmAbmCliente != null)
                {
                    frmAbmCliente.Show();
                }
                else if (frmModificarCliente != null)
                {
                    frmModificarCliente.Show();
                }
                else
                {
                    frmDetallePublicacion.Show();
                }
            }
            else
            {
                MessageBox.Show("Error en la asociación de la tarjeta", "Error");
            }
        }

        public Boolean chequearCampos()
        {
            if (!campoVacio(mskNumeroTarjeta) && !campoVacio(mskCodSeguridad) && !(cmbMes.SelectedIndex == -1) && !(cmbAno.SelectedIndex == -1) && !(cmbTipo.SelectedIndex == -1))
            {
                if (mskNumeroTarjeta.MaskCompleted && mskCodSeguridad.MaskCompleted)
                {
                    if (!SqlConnector.existeString(mskNumeroTarjeta.Text, "VADIUM.TARJETADECREDITO", "nroTarjeta"))
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

        public Boolean campoVacio(MaskedTextBox textbox)
        {
            return textbox.Text.Equals("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (frmRegistroUsuarioCliente != null)
            {
                frmRegistroUsuarioCliente.Show();
            }
            else if (frmAbmCliente != null)
            {
                frmAbmCliente.Show();
            }
            else if (frmModificarCliente != null)
            {
                frmModificarCliente.Show();
            }
            else
            {
                frmDetallePublicacion.Show();
            }
        }

        private void frmAgregarTarjetaDeCredito_Load(object sender, EventArgs e)
        {

        }
    }
}
