﻿using PalcoNet.Model;
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
    public partial class frmDetallePublicacion : Form
    {
        Publicacion publi;

        public frmDetallePublicacion(Publicacion unaPublicacion)
        {
            InitializeComponent();
            publi = unaPublicacion;
        }
    }
}
