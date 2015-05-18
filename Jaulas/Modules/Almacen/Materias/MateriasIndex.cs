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
            rdbStock.Select();
            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterias.RowHeadersVisible = false;
        }

        string filtrar;
        private static MateriasIndex frmInst = null;
        public static MateriasIndex Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasIndex();
            frmInst.BringToFront();
            return frmInst;
        }

        private void MateriasIndex_Load(object sender, EventArgs e)
        {
            Stock();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MateriasNuevo nuevo = null;
            nuevo = MateriasNuevo.Instancia();
            nuevo.MdiParent = MdiAdmin.ActiveForm;
            nuevo.Show();
            this.Close();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            MateriasCompras compras = null;
            compras = MateriasCompras.Instancia();
            compras.MdiParent = MdiAdmin.ActiveForm;
            compras.Show();
            this.Close();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbStock.Checked)
            {
                Stock();
                lblTitulo.Text = "Stock de materias primas";
            }
        }

        private void rdbCompras_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompras.Checked)
            {
                Compras();
                lblTitulo.Text = "Historial de compras";
            }
        }

        private void rdbCatalogo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCatalogo.Checked)
            {
                Catalogo();
                lblTitulo.Text = "Catálogo de materias primas";
            }  
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdbCatalogo.Checked)
            {
                if (e.RowIndex < 0) return;
                string id = Convert.ToString(dgvMaterias.Rows[e.RowIndex].Cells[0].Value);
                Variables.MateriaId(id);
                Editar();
            }
        }

        private void dgvMaterias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbCatalogo.Checked)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    string id = Convert.ToString(dgvMaterias.Rows[dgvMaterias.CurrentRow.Index].Cells[0].Value);
                    Variables.MateriaId(id);
                    Editar();
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txbFiltrar.Text.Trim();
            if (rdbStock.Checked)
            {
                filtrar = " WHERE m.nombre LIKE '%" + filtro + "%' OR m.modelo LIKE '%" + filtro + "%' OR s.cantidad LIKE '%" + filtro + "%'";
                Stock();
            }

            if (rdbCompras.Checked)
            {
                filtrar = " WHERE m.nombre LIKE '%" + filtro + "%' OR c.cantidad LIKE '%" + filtro + "%' OR c.costo LIKE '%" + filtro + "%' OR c.total LIKE '%" + filtro + "%' OR c.fecha LIKE '%" + filtro + "%'";
                Compras();
            }

            if (rdbCatalogo.Checked)
            {
                filtrar = " WHERE nombre LIKE '%"+ filtro +"%' OR modelo LIKE '%"+ filtro +"%' OR descripcion LIKE '%"+ filtro +"%'";
                Catalogo();
            }
        }

        private void Stock()
        {
            BaseDatos stock = new BaseDatos();
            string sql = "SELECT m.nombre AS Nombre, m.modelo AS Modelo, s.cantidad AS Existencias FROM stock_materias s INNER JOIN materias m ON s.materia_id = m.id" + filtrar;
            stock.buscar(sql);
            dgvMaterias.DataSource = stock.ds.Tables[0];
        }

        private void Compras()
        {
            BaseDatos compras = new BaseDatos();
            string sql = "SELECT m.nombre AS Materia, c.cantidad AS Cantidad, c.costo AS Costo, c.total AS Total, c.fecha AS Fecha FROM compras c INNER JOIN materias m ON c.materia_id = m.id" + filtrar;
            compras.buscar(sql);         
            dgvMaterias.DataSource = compras.ds.Tables[0];
        }
        private void Catalogo()
        {
            BaseDatos catalogo = new BaseDatos();
            string sql = "SELECT id, nombre AS Nombre, modelo AS Modelo, descripcion AS Descripcion FROM materias" + filtrar;
            catalogo.buscar(sql);
            dgvMaterias.DataSource = catalogo.ds.Tables[0];
            dgvMaterias.Columns["id"].Visible = false;
        }

        private void Editar()
        {
            MateriasEditar editar = null;
            editar = MateriasEditar.Instancia();
            editar.MdiParent = MdiAdmin.ActiveForm;
            editar.Show();
            this.Close();
        }

        private void txbFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnFiltrar.PerformClick();
            }
        }
    }
}
