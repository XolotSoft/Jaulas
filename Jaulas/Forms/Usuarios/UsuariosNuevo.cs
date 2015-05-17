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
    public partial class UsuariosNuevo : Form
    {
        public UsuariosNuevo()
        {
            InitializeComponent();
        }
        private BaseDatos bd = new BaseDatos();
        private static UsuariosNuevo frmInst = null;
        public static UsuariosNuevo Instancia()
        {
            if (frmInst == null ||  frmInst.IsDisposed == true) frmInst = new UsuariosNuevo();
            frmInst.BringToFront();
            return frmInst;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
        }
    }
}
