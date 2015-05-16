﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jaulas
{
    public partial class MateriasNuevo : Form
    {
        public MateriasNuevo()
        {
            InitializeComponent();
        }
        private static MateriasNuevo frmInst = null;
        public static MateriasNuevo Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasNuevo();
            frmInst.BringToFront();
            return frmInst;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
