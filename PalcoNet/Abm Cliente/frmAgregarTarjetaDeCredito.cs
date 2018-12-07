using PalcoNet.Model;
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
        Tarjeta tarjeta;
        public frmAgregarTarjetaDeCredito(Tarjeta _tarjeta)
        {
            InitializeComponent();
            tarjeta = _tarjeta;
        }

        private void frmAgregarTarjetaDeCredito_Load(object sender, EventArgs e)
        {
            txtNumeroTarjeta.Text = tarjeta.Numero;
            txtCodigoSeguridad.Text = tarjeta.CodigoSeguridad;
            foreach (int Anio in Enumerable.Range(Configuration.getActualDate().Year, 12))
                cmbAnio.Items.Add(Anio);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool tarjetaValida = true;
            if (cmbMes.SelectedIndex == -1 || cmbAnio.SelectedIndex == -1)
            {
                MessageBox.Show("La fecha de vencimiento no puede estar vacia");
                tarjetaValida = false;
            }
            else if (Configuration.getActualDate().Year == int.Parse(cmbAnio.SelectedItem.ToString()) &&
                Configuration.getActualDate().Month > byte.Parse(cmbMes.SelectedItem.ToString()))
            {
                MessageBox.Show("La fecha de vencimiento no puede ser anterior a la fecha de hoy");
                tarjetaValida = false;
            }
            if (String.IsNullOrWhiteSpace(txtNumeroTarjeta.Text))
            {
                MessageBox.Show("El numero de tarjeta no puede estar vacio");
                tarjetaValida = false;
            }
            else if (!chequearSoloNumeros(txtNumeroTarjeta.Text))
            {
                MessageBox.Show("El numero de tarjeta debe estar compuesto de numeros");
                tarjetaValida = false;
            }
            if (String.IsNullOrWhiteSpace(txtCodigoSeguridad.Text))
            {
                MessageBox.Show("El codigo de seguridad no puede estar vacio");
                tarjetaValida = false;
            }
            else if (!chequearSoloNumeros(txtCodigoSeguridad.Text))
            {
                MessageBox.Show("El codigo de seguridad debe estar compuesto de numeros");
                tarjetaValida = false;
            }
            else if (txtCodigoSeguridad.Text.Length > 4)
            {
                MessageBox.Show("El codigo de seguridad no puede tener más de cuatro digitos");
                tarjetaValida = false;
            }
            if (tarjetaValida)
            {
                tarjeta.CodigoSeguridad = txtCodigoSeguridad.Text;
                tarjeta.Numero = txtNumeroTarjeta.Text;
                tarjeta.Mes = byte.Parse(cmbMes.SelectedItem.ToString());
                tarjeta.Anio = int.Parse(cmbAnio.SelectedItem.ToString());
                DialogResult = DialogResult.OK;
            }
        }


        public static bool chequearSoloNumeros(String text)
        {
            return text.All(c => 57 >= c && c >= 48);
        }
    }
}
