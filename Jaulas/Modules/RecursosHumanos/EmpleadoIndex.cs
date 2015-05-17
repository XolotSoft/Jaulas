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
    public partial class EmpleadoIndex : Form
    {
        public EmpleadoIndex()
        {
            InitializeComponent();
        }

        private static EmpleadoIndex frmInst = null;

        public static EmpleadoIndex Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new EmpleadoIndex();
            frmInst.BringToFront();
            return frmInst;
        }

        private void EmpleadoIndex_Load(object sender, EventArgs e)
        {
            BaseDatos bd = new BaseDatos();
            string sql = "SELECT * FROM empleados e INNER JOIN ctatalogo c WHERE e.area_id = c.id";
            bd.buscar(sql);
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.DataSource = bd.ds.Tables[0];
            dgvEmpleados.Columns["id"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EmpleadoNuevo nuevo = null;
            nuevo = EmpleadoNuevo.Instancia();
            nuevo.MdiParent = MdiAdmin.ActiveForm;
            nuevo.Show();
            this.Close();
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string id = Convert.ToString(dgvEmpleados.Rows[e.RowIndex].Cells[0].Value);
            Variables.EmpleadoId(id);
            Editar();
        }

        private void dgvEmpleados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string id = Convert.ToString(dgvEmpleados.Rows[dgvEmpleados.CurrentRow.Index].Cells[0].Value);
                Variables.UsuarioId(id);
                Editar();
            }
        }

        private void Editar()
        {
            EmpleadoEditar editar = null;
            editar = EmpleadoEditar.Instancia();
            editar.MdiParent = MdiAdmin.ActiveForm;
            editar.Show();
            this.Close();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
