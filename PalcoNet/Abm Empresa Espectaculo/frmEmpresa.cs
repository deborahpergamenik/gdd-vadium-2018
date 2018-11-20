using PalcoNet.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class frmEmpresa : Form
    {
        public frmSeleccionFuncionalidades _frmSeleccionFuncionalidad { get; set; }

        public frmEmpresa(frmSeleccionFuncionalidades frmSeleccionFuncionalidad)
        {
            InitializeComponent();
            this._frmSeleccionFuncionalidad = frmSeleccionFuncionalidad;
        }
    }
}
