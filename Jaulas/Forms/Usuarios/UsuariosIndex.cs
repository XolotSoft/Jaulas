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
    public partial class UsuariosIndex : Form
    {
        public UsuariosIndex()
        {
            InitializeComponent();
        }
        private static UsuariosIndex frmInst = null;
        public static UsuariosIndex Instncia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new UsuariosIndex();
            frmInst.BringToFront();
            return frmInst;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            UsuariosNuevo nuevo = null;
            nuevo = UsuariosNuevo.Instancia();
            nuevo.MdiParent = MDI.ActiveForm;
            nuevo.Show();
            this.Close();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
