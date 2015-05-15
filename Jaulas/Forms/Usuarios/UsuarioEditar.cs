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
    public partial class UsuarioEditar : Form
    {
        public UsuarioEditar()
        {
            InitializeComponent();
        }
        private static UsuarioEditar frmInst = null;
        public static UsuarioEditar Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new UsuarioEditar();
            frmInst.BringToFront();
            return frmInst;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
