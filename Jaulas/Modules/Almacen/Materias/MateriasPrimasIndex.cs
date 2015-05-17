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
    public partial class MateriasPrimasIndex : Form
    {
        public MateriasPrimasIndex()
        {
            InitializeComponent();
        }
        private static MateriasPrimasIndex frmInst = null;
        public static MateriasPrimasIndex Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasPrimasIndex();
            frmInst.BringToFront();
            return frmInst;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MateriasPrimasNuevo nuevo = null;
            nuevo = MateriasPrimasNuevo.Instancia();
            nuevo.MdiParent = MdiAdmin.ActiveForm;
            nuevo.Show();
            this.Close();
        }

    }
}
