﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class frmGenerarPublicacion : Form
    {
        public frmGenerarPublicacion()
        {
            InitializeComponent();
        }

        public frmGenerarPublicacion(string modo)
        {
            if (modo == "Nuevo")
            {
                InitializeComponent();
            }
        }
    }
}
