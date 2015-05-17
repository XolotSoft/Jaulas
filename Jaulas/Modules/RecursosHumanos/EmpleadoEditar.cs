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
    public partial class EmpleadoEditar : Form
    {
        public EmpleadoEditar()
        {
            InitializeComponent();
        }

        private static EmpleadoEditar frmInst = null;

        public static EmpleadoEditar Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new EmpleadoEditar();
            frmInst.BringToFront();
            return frmInst;
        }
    }
}
