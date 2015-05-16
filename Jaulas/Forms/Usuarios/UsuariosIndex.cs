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
            nuevo.MdiParent = MdiAdmin.ActiveForm;
            nuevo.Show();
            this.Close();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsuariosIndex_Load(object sender, EventArgs e)
        {
            BaseDatos bd = new BaseDatos();
            bd.buscar("SELECT id, nombre AS Nombre ,username AS Usuario, tipo AS Tipo FROM usuarios");
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.DataSource = bd.ds.Tables[0];
            dgvUsuarios.Columns["id"].Visible = false;
        }

    }
}
