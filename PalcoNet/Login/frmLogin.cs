﻿using PalcoNet.Login;
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
        public const int CANTIDAD_MAXIMA_INTENTOS = 3;
        public frmLogin()
        {
            InitializeComponent();
        }      


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!txtUsuario.Text.Equals("") && !txtPassword.Text.Equals(""))
            {
                string username = txtUsuario.Text;
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtPassword.Text));
                string password = bytesDeHasheoToString(bytesDeHasheo);
                Usuario usuarioLogin = new Usuario(0, username, password);
                if (usuarioLogin.obtenerPK())
                {
                    if (usuarioLogin.habilitado())
                    {
                        int pVez = usuarioLogin.primeraVez();
                        if (pVez == 0)
                        {
                            if (usuarioLogin.verificarContrasenia())
                            {
                                usuarioLogin.ResetearIntentosFallidos();
                                if (usuarioLogin.obtenerRoles())
                                {
                                    if (usuarioLogin.Roles.Count() == 1)
                                    {
                                        this.Hide();
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
                                if (usuarioLogin.cantidadIntentosFallidos() == CANTIDAD_MAXIMA_INTENTOS)
                                {
                                    usuarioLogin.inhabilitarUsuario();
                                    MessageBox.Show("Usuario inhabilitado.", "Error");
                                }
                                else
                                {
                                    MessageBox.Show("Usuario o contraseña incorrecta, le quedan " + (CANTIDAD_MAXIMA_INTENTOS - usuarioLogin.intentosFallidos()).ToString() + " intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            if (pVez == 2)
                            {
                                if (usuarioLogin.verificarContraseniaSinHash(txtPassword.Text))
                                {
                                    frmCambiarPassword frmPassword = new frmCambiarPassword(true);
                                    frmPassword.Show();
                                }
                                else
                                {
                                    usuarioLogin.sumarIntentoFallido();
                                    if (usuarioLogin.cantidadIntentosFallidos() == CANTIDAD_MAXIMA_INTENTOS)
                                    {
                                        usuarioLogin.inhabilitarUsuario();
                                        MessageBox.Show("Usuario inhabilitado.", "Error");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Usuario o contraseña incorrecta, le quedan " + (CANTIDAD_MAXIMA_INTENTOS - usuarioLogin.intentosFallidos()).ToString() + " intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            if (pVez == 1)
                            {
                                frmCambiarPassword frmPassword = new frmCambiarPassword(false);
                                frmPassword.Show();
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
