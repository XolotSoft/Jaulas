using System;
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
    public partial class EmpleadoNuevo : Form
    {
        public EmpleadoNuevo()
        {
            InitializeComponent();
        }

        private static EmpleadoNuevo frmInst = null;

        public static EmpleadoNuevo Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new EmpleadoNuevo();
            frmInst.BringToFront();
            return frmInst;
        }
    }
}
