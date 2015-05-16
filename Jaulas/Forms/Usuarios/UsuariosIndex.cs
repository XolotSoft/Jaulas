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

        private void UsuariosIndex_Load(object sender, EventArgs e)
        {
            BaseDatos bd = new BaseDatos();
            bd.buscar("SELECT u.id, u.nombre AS Nombre , u.username AS Usuario, c.nombre AS Rol FROM usuarios u INNER JOIN catalogo c ON u.rol_id = c.id");
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.DataSource = bd.ds.Tables[0];
            dgvUsuarios.Columns["id"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            UsuariosNuevo nuevo = null;
            nuevo = UsuariosNuevo.Instancia();
            nuevo.MdiParent = MdiAdmin.ActiveForm;
            nuevo.Show();
            this.Close();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string id = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value);
            Variables.UsuarioId(id);
            Editar();
        }

        private void dgvUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string id = Convert.ToString(dgvUsuarios.Rows[dgvUsuarios.CurrentRow.Index].Cells[0].Value);
                Variables.UsuarioId(id);
                Editar();
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Editar()
        {
            UsuarioEditar editar = null;
            editar = UsuarioEditar.Instancia();
            editar.MdiParent = MdiAdmin.ActiveForm;
            editar.Show();
            this.Close();
        }
    }
}
