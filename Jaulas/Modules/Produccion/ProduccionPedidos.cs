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
    public partial class ProduccionPedidos : Form
    {
        public ProduccionPedidos()
        {
            InitializeComponent();
        }

        private static ProduccionPedidos frmInst = null;
        public static ProduccionPedidos Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new ProduccionPedidos();
            frmInst.BringToFront();
            return frmInst;
        }

    }
}
