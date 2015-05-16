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
    public partial class MateriasIndex : Form
    {
        public MateriasIndex()
        {
            InitializeComponent();
        }
        private static MateriasIndex frmInst = null;
        public static MateriasIndex Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasIndex();
            frmInst.BringToFront();
            return frmInst;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MateriasNuevo nuevo = null;
            nuevo = MateriasNuevo.Instancia();
            nuevo.MdiParent = MdiAdmin.ActiveForm;
            nuevo.Show();
            this.Close();
        }

    }
}
