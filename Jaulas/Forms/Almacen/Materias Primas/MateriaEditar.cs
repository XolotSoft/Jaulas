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
    public partial class MateriaEditar : Form
    {
        public MateriaEditar()
        {
            InitializeComponent();
        }
        private static MateriaEditar frmInst = null;
        public static MateriaEditar Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriaEditar();
            frmInst.BringToFront();
            return frmInst;
        }
    }
}
