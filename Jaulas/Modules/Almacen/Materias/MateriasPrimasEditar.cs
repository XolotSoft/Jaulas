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
    public partial class MateriasPrimasEditar : Form
    {
        public MateriasPrimasEditar()
        {
            InitializeComponent();
        }
        private static MateriasPrimasEditar frmInst = null;
        public static MateriasPrimasEditar Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasPrimasEditar();
            frmInst.BringToFront();
            return frmInst;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
