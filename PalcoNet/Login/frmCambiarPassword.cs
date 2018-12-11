using PalcoNet.Common;
using PalcoNet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Login
{
    public partial class frmCambiarpassword : Form
    {
        public Boolean primera_vez { get; set; }
        public frmCambiarpassword(Boolean pVez)
        {
            this.primera_vez = pVez;
            InitializeComponent();

            //if (primera_vez)
            //{
            //    passViejoNH.Enabled = false;
            //    MessageBox.Show("Con el fin de mejorar la protección de sus datos personales, hemos implementado\njunto al nuevo sistema de gestión una nueva política de seguridad.\n\nPara ello, le solicitamos que ingrese nuevamente su contraseña, o escoja una nueva. \n\nAtte,\nPalcoNet ", "Bienvenido al nuevo sistema");
            //}
        }

        private void pass2_TextChanged(object sender, EventArgs e)
        {
            pass2.PasswordChar = '*';
        }

        private void pass1_TextChanged(object sender, EventArgs e)
        {
            pass1.PasswordChar = '*';
        }

        private void passViejo_TextChanged(object sender, EventArgs e)
        {
            passViejoNH.PasswordChar = '*';
        }

        public Boolean chequearpassword(string password)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@user", Interfaz.usuario.usuario_username);
            SqlConnector.agregarParametro(listaParametros, "@pass", password);
            SqlDataReader lector = SqlConnector.ObtenerDataReader("VADIUM.VERIFICAR_USUARIO_PASSWORD", "SP", listaParametros);
            //SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_password FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id AND usuario_password = @password", listaParametros, SqlConnector.iniciarConexion());
            bool res = false;
            if (lector.HasRows)
            {
                 res = Convert.ToBoolean(lector["PasswordMatched"].ToString());
            }
            SqlConnector.cerrarConexion();
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((!passViejoNH.Text.Equals("") || primera_vez == true) && !pass1.Text.Equals("") && !pass2.Text.Equals(""))
            {
                //if (primera_vez == false)
                //{
                    
                    string passViejo = passViejoNH.Text;

                    if (chequearpassword(passViejo))
                    {
                        if (pass1.Text == pass2.Text)
                        {
                            UserInstance.getUserInstance().usuario.cambiarpassword(pass1.Text);
                            MessageBox.Show("Contraseña modificada.");
                            UserInstance.getUserInstance().usuario.usuarioLogueado();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El password viejo no es correcto.", "Error");
                    }
                //}
                //else
                //{
                //    if (pass1.Text == pass2.Text)
                //    {
                //        Interfaz.usuario.cambiarpassword(pass1.Text);
                //        MessageBox.Show("Contraseña modificada.");
                //        this.Hide();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Las contraseñas no coinciden.", "Error");
                //    }
                //}
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos solicitados.", "Error");
            }
        }

        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
        }

        private void frmCambiarpassword_Load(object sender, EventArgs e)
        {

        }
    }
}
