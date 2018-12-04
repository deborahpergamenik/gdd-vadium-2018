using PalcoNet.Common;
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

namespace PalcoNet.Abm_Rol
{
    public partial class frmEditarRoles : Form
    {
        Rol RolActual; //Rol seleccionado en el datagridview, como objeto Rol
        string nombreAux; //aux para permitir varias actualizaciones en Modificar, sin tener que salir y entrar, y que no permita poner el mismo nombre.
        bool guardarNuevo; //Flag para saber al momento de apretar el boton Guardar, si es nuevo o modificar (ya que comparten el mismo form)

        //Constructor modo "nuevo"
        public frmEditarRoles(string modo)
        {
            InitializeComponent();
            if (modo == "nuevo")
            {
                List<Funcionalidad> lista = Funcionalidades.obtenerFuncionalidades(SqlConnector.iniciarConexion(), 0); //0 son todas

                chkListFuncionalidades.DisplayMember = "Nombre";
                chkListFuncionalidades.ValueMember = "ID_Funcionalidad";
                cargarCheckboxList(lista);

                chkEstado.Enabled = false;
                guardarNuevo = true;
            }

        }

        //Constructor modo "modificar", necesito los datos del Rol seleccionado
        public frmEditarRoles(string modo, Rol unRol)
        {
            InitializeComponent();
            RolActual = unRol;

            if (modo == "modificar")
            {
                List<Funcionalidad> listaFuncQueTiene = Funcionalidades.obtenerFuncionalidades(SqlConnector.iniciarConexion(), unRol.Id);
                List<Funcionalidad> listaTodasLasFunc = Funcionalidades.obtenerTodasLasFuncionalidades(SqlConnector.iniciarConexion());

                txtNombre.Text = unRol.Nombre;
                txtNombre.Focus();
                txtNombre.SelectAll();
                nombreAux = unRol.Nombre;

                chkListFuncionalidades.DisplayMember = "Nombre";
                chkListFuncionalidades.ValueMember = "ID_Funcionalidad";

                cargarCheckboxList(listaTodasLasFunc);
                actualizarCheckboxList(listaFuncQueTiene);

                //si esta habilitado, NO permitir cambiar check, caso contrario permitir.
                if (unRol.Estado)
                {
                    chkEstado.Enabled = false;
                }
                else chkEstado.Enabled = true;

                guardarNuevo = false;
            }
        }

        //Carga el checkbox con todas las funcionalidades
        private void cargarCheckboxList(List<Funcionalidad> lista)
        {
            for (int i = 0; i < lista.Count(); i++)
            {
                chkListFuncionalidades.Items.Add(new Funcionalidad(lista[i].Id, lista[i].Descripcion));
            }
        }

        //Actualiza el checkbox con todas las funcionalidades que tiene en la BD, checkeadas.
        private void actualizarCheckboxList(List<Funcionalidad> listaFuncQueTiene)
        {
            foreach (Funcionalidad func in listaFuncQueTiene)
            {
                for (int i = 0; i < chkListFuncionalidades.Items.Count; i++)
                {
                    Funcionalidad otraFunc = chkListFuncionalidades.Items[i] as Funcionalidad;

                    if (func.Id == otraFunc.Id)
                    {
                        chkListFuncionalidades.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Complete el nombre del nuevo Rol", "Error - Falta llenar algun campo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
            }
            else
            {
                //TODO No estoy seguro si esto esta prohibido! por las dudas obligo a que ingrese una.
                int cant = chkListFuncionalidades.CheckedItems.Count;
                if (cant < 1)
                {
                    MessageBox.Show("Selecciones al menos una funcionalidad", "Error - Falta llenar algun campo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Me quedo con las funcionalidades que estan checkeadas
                    List<Funcionalidad> listaNuevasFunc = filtrarSeleccionadas();

                    if (guardarNuevo)
                    //Inserto un nuevo rol
                    {
                        bool respuesta = Roles.insertarNuevoRol(txtNombre.Text, listaNuevasFunc);

                        if (respuesta == false)
                        {
                            MessageBox.Show("Ya existe un rol con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNombre.Focus();
                            txtNombre.SelectAll();
                        }
                        else
                        {
                            MessageBox.Show("Rol creado con éxito! Puede seguir creando roles.", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Interfaz.limpiarCheckboxList(chkListFuncionalidades);
                            Interfaz.limpiarInterfaz(this);
                            txtNombre.Focus();
                        }
                    }
                    else if (!guardarNuevo)
                    //Modifico el rol actualmente seleccionado
                    {
                        //Esto es para que si modifico el rol una vez, y lo paso de inhabilitado-->habilitado y SIGUE modificando, ya no le deje cambiar el checkbox habilitado
                        if (chkEstado.Checked)
                            chkEstado.Enabled = false;

                        List<Funcionalidad> listaFuncActuales = Funcionalidades.obtenerFuncionalidades(SqlConnector.iniciarConexion(), RolActual.Id);

                        //Me fijo que haya hecho al menos un cambio.. el OR (||) es por si entro como habilitado o deshabilitado.
                        if (sonIguales(listaNuevasFunc, listaFuncActuales) && (txtNombre.Text == nombreAux) && (RolActual.Estado || !RolActual.Estado && !chkEstado.Checked))
                        {
                            MessageBox.Show("Por favor realice al menos un cambio", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            //actualizo al RolActual que fue habilitado (en caso de checkear el box), para que si sigue modificando ya se lo considere habilitado
                            if (chkEstado.Checked)
                                RolActual.Estado = true;


                            //UPDATE de los cambios realizados, con cuidado especial en Habilitado. Con que haya un cambio, actualizo todo, por mas que sean redundantes
                            //dos de los 3 campos (por ejemplo), es un solo acceso a la BD.
                            if (RolActual.Estado)
                                Roles.updatearRol(txtNombre.Text, listaNuevasFunc, true, RolActual.Id);
                            else
                                Roles.updatearRol(txtNombre.Text, listaNuevasFunc, false, RolActual.Id);


                            //TODO creo que es al pedo el aux
                            nombreAux = txtNombre.Text;

                            //UPDATE de FUNCIONALIDADES_X_ROL - Aca si pongo un if, ya que son muchos accesos a la BD y si son iguales no son es necesario.
                            if (!sonIguales(listaNuevasFunc, listaFuncActuales))
                                actualizarFuncionalidadPorRol(listaNuevasFunc, listaFuncActuales);

                            MessageBox.Show("Rol modificado con éxito! Puede seguir modificandolo o volver a ABM Rol", "Succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                }
            }
        }

        //Se fija si las dos listas de funcionalidades dadas son iguales (respecto a ID_Funcionalidad)
        public static bool sonIguales(List<Funcionalidad> listaNuevasFunc, List<Funcionalidad> listaFuncActuales)
        {
            if (listaFuncActuales.Count != listaNuevasFunc.Count)
                return false;

            for (int i = 0; i < listaFuncActuales.Count; i++)
            {
                bool encontro = false;

                for (int j = 0; j < listaNuevasFunc.Count; j++)
                {
                    if (listaNuevasFunc[j].Id == listaFuncActuales[i].Id)
                    {
                        encontro = true;
                        break;
                    }
                }

                if (!encontro)
                    return false;
            }
            return true;
        }

        //Dadas las funcionalidades que estan actualmente en la BD y las que selecciono nuevas (o saco algunas que ya estaban), Delete o Insert
        private void actualizarFuncionalidadPorRol(List<Funcionalidad> listaNuevasFunc, List<Funcionalidad> listaFuncActuales)
        {
            for (int i = 0; i < listaFuncActuales.Count; i++)
            {
                bool encontro = false;

                for (int j = 0; j < listaNuevasFunc.Count; j++)
                {
                    if (listaNuevasFunc[j].Id == listaFuncActuales[i].Id)
                    {
                        encontro = true;
                        break;
                    }
                }

                if (!encontro)
                    //delete
                    Funcionalidades.BorrarFuncionalidadEnRol(nombreAux, listaFuncActuales[i].Descripcion);
            }

            for (int i = 0; i < listaNuevasFunc.Count; i++)
            {
                bool encontro = false;

                for (int j = 0; j < listaFuncActuales.Count; j++)
                {
                    if (listaFuncActuales[j].Id == listaNuevasFunc[i].Id)
                    {
                        encontro = true;
                        break;
                    }
                }
                if (!encontro)
                    //agregar
                    Funcionalidades.AgregarFuncionalidadEnRol(nombreAux, listaNuevasFunc[i]);
            }
        }

        //Devuelve Lista de funcionalidades que estan seleccionadas en el checkboxlist
        private List<Funcionalidad> filtrarSeleccionadas()
        {
            List<Funcionalidad> funcionalidadesNuevoRol = new List<Funcionalidad>();

            for (int i = 0; i < chkListFuncionalidades.Items.Count; i++)
            {
                if (chkListFuncionalidades.GetItemChecked(i))
                {
                    Funcionalidad func = chkListFuncionalidades.Items[i] as Funcionalidad;
                    funcionalidadesNuevoRol.Add(func);
                }
            }
            return funcionalidadesNuevoRol;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
