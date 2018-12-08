using PalcoNet.Login;
using PalcoNet.Model;
using PalcoNet.Registro_de_Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class frmLogin : Form
    {
        public const int CANTIDAD_MAXIMA_usuario_intentosLogin = 3;
        public frmLogin()
        {
            InitializeComponent();
        }      


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!txtUsuario.Text.Equals("") && !txtpassword.Text.Equals(""))
            {
                string username = txtUsuario.Text;
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtpassword.Text));
                string password = bytesDeHasheoToString(bytesDeHasheo);
                Usuario usuarioLogin = new Usuario(0, username, password);
                if (usuarioLogin.obtenerPK())
                {
                    if (usuarioLogin.habilitado())
                    {
                        int pVez = usuarioLogin.primera_vez();
                        if (pVez == 0)
                        {
                            if (usuarioLogin.verificarContrasenia())
                            {
                                usuarioLogin.Resetearusuario_intentosLoginFallidos();
                                if (usuarioLogin.obtenerRoles())
                                {
                                    if (usuarioLogin.Roles.Count() == 1)
                                    {
                                        this.Hide();
                                        UserInstance.getUserInstance().loadInformation(usuarioLogin, usuarioLogin.Roles[0]);
                                        frmSeleccionFuncionalidades formSeleccionFuncionalidades = new frmSeleccionFuncionalidades(usuarioLogin, usuarioLogin.Roles[0].Id, true);
                                        formSeleccionFuncionalidades.Show();
                                    }
                                    else
                                    {
                                        this.Hide();
                                        frmSeleccionRoles formSeleccionRoles = new frmSeleccionRoles(usuarioLogin);
                                        formSeleccionRoles.Show();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El usuario no tiene roles asignados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                usuarioLogin.sumarIntentoFallido();
                                if (usuarioLogin.cantidadusuario_intentosLoginFallidos() == CANTIDAD_MAXIMA_usuario_intentosLogin)
                                {
                                    usuarioLogin.inhabilitarUsuario();
                                    MessageBox.Show("Usuario inhabilitado.", "Error");
                                }
                                else
                                {
                                    MessageBox.Show("Usuario o contraseña incorrecta, le quedan " + (CANTIDAD_MAXIMA_usuario_intentosLogin - usuarioLogin.usuario_intentosLoginFallidos()).ToString() + " usuario_intentosLogin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            if (pVez == 2)
                            {
                                if (usuarioLogin.verificarContraseniaSinHash(txtpassword.Text))
                                {
                                    frmCambiarpassword frmpassword = new frmCambiarpassword(true);
                                    frmpassword.Show();
                                }
                                else
                                {
                                    usuarioLogin.sumarIntentoFallido();
                                    if (usuarioLogin.cantidadusuario_intentosLoginFallidos() == CANTIDAD_MAXIMA_usuario_intentosLogin)
                                    {
                                        usuarioLogin.inhabilitarUsuario();
                                        MessageBox.Show("Usuario inhabilitado.", "Error");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Usuario o contraseña incorrecta, le quedan " + (CANTIDAD_MAXIMA_usuario_intentosLogin - usuarioLogin.usuario_intentosLoginFallidos()).ToString() + " usuario_intentosLogin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            if (pVez == 1)
                            {
                                frmCambiarpassword frmpassword = new frmCambiarpassword(false);
                                frmpassword.Show();
                            }
                        }
                    }
                    else
                    {
                        //viendo la causa de la inhabiltacion

                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe.", "Error");
                }

            }
            else
            {
                MessageBox.Show("Por favor, ingrese los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            frmRegistroUsuario frmRegistroUsuario = new frmRegistroUsuario(this);
            frmRegistroUsuario.Show();
            this.Hide();
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
    }
}
