using PalcoNet.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Common
{
    public class Interfaz
    {
        public static Usuario usuario { get; set; }

        public static void usuarioLogeado(Usuario usuarioActual)
        {
            usuario = usuarioActual;
        }

        public static void limpiarInterfaz(Control con)
        {


            foreach (Control c in con.Controls)
            {
                var box = c as TextBox;
                var combo = c as ComboBox;
                var datagridview = c as DataGridView;
                var datetimepicker = c as DateTimePicker;
                var checkbox = c as CheckBox;

                //Limpia textbox
                if (box != null)
                {
                    box.Text = string.Empty;
                }

                //Limpia comboBox
                if (combo != null)
                {
                    combo.SelectedIndex = -1;
                }

                //Limpia DataGridView
                if (datagridview != null)
                {
                    datagridview.DataSource = null;
                    datagridview.Refresh();
                }

                //Limpiar DateTimePicker
                if (datetimepicker != null)
                {
                }

                //Limpiar Checkbox
                if (checkbox != null)
                {
                    checkbox.Checked = false;
                }

                limpiarInterfaz(c);

            }
        }

        public static void limpiarCheckboxList(CheckedListBox cbl)
        {
            foreach (int i in cbl.CheckedIndices)
            {
                cbl.SetItemCheckState(i, CheckState.Unchecked);
                cbl.SetSelected(i, false);
            }

        }

        public static bool esNumerico(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public static DateTime obtenerFecha()
        {
            return DateTime.ParseExact(ConfigurationManager.AppSettings["Fecha"], "dd/MM/yyyy", null);
        }

        public static Usuario usuarioActual()
        {
            return usuario;
        }


        //Esto bloquea el ordenamiento del datagrid cuando se toca en algun header de las columnas
        public static DataGridView bloquearDataGridView(DataGridView dgv)
        {

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            return dgv;
        }

    }
}
