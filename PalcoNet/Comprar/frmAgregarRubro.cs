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

namespace PalcoNet.Comprar
{
    public partial class frmAgregarRubro : Form
    {
        private List<Rubro> rubros;
        public static List<Rubro> rubrosSeleccionados;


        public frmAgregarRubro(List<Rubro> rubrosFiltro)
        {
            InitializeComponent();
            rubrosSeleccionados = rubrosFiltro;
            rubros = Rubros.obtenerRubros();

            cblRubros.DisplayMember = "descripcion";
            cblRubros.ValueMember = "rubro_id";
            cargarCheckboxlist();
            actualizarCheckboxList();
        }

        private void actualizarCheckboxList()
        {
            foreach (Rubro rubro in rubrosSeleccionados)
            {
                for (int i = 0; i < cblRubros.Items.Count; i++)
                {
                    Rubro otroRubro = cblRubros.Items[i] as Rubro;

                    if (rubro.Id == otroRubro.Id)
                    {
                        cblRubros.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        private void cargarCheckboxlist()
        {
            for (int i = 0; i < rubros.Count(); i++)
            {
                cblRubros.Items.Add(new Rubro(rubros[i].Id, rubros[i].Descripcion));
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            guardarSeleccionados();
        }

        private void guardarSeleccionados()
        {
            rubrosSeleccionados.Clear();

            for (int i = 0; i < cblRubros.Items.Count; i++)
            {
                if (cblRubros.GetItemChecked(i))
                {
                    Rubro rubro = cblRubros.Items[i] as Rubro;
                    rubrosSeleccionados.Add(rubro);
                }
            }

        }

        private void btnNinguno_Click(object sender, EventArgs e)
        {
            foreach (int i in cblRubros.CheckedIndices)
            {
                cblRubros.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
