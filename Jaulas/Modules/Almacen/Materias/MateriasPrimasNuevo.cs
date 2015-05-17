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
    public partial class MateriasPrimasNuevo : Form
    {
        public MateriasPrimasNuevo()
        {
            InitializeComponent();
        }
        private static MateriasPrimasNuevo frmInst = null;
        public static MateriasPrimasNuevo Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasPrimasNuevo();
            frmInst.BringToFront();
            return frmInst;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
