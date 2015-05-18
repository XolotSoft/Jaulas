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
    public partial class PuntoVenta : Form
    {
        public PuntoVenta()
        {
            InitializeComponent();
        }

        private static PuntoVenta frmInst = null;
        public static PuntoVenta Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new PuntoVenta();
            frmInst.BringToFront();
            return frmInst;
        }
    }
}
