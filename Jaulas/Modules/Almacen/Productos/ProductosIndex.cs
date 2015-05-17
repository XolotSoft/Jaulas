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
    public partial class ProductosIndex : Form
    {
        public ProductosIndex()
        {
            InitializeComponent();
            rdbStock.Select();
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.RowHeadersVisible = false;
        }

        string filtrar;
        BaseDatos datos = new BaseDatos();
        private static ProductosIndex frmInst = null;

        public static ProductosIndex Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new ProductosIndex();
            frmInst.BringToFront();
            return frmInst;
        }

        private void StockIndex_Load(object sender, EventArgs e)
        {
            Stock();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ProductosNuevo nuevo = null;
            nuevo = ProductosNuevo.Instancia();
            nuevo.MdiParent = MdiAdmin.ActiveForm;
            nuevo.Show();
            this.Close();
        }

        private void rdbCatalogo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCatalogo.Checked)
            {
                Catalogo();
                lblTitulo.Text = "Catálogo de productos";
            }  
        }

        private void rdbStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbStock.Checked)
            {
                Stock();
                lblTitulo.Text = "Stock de productos";
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdbCatalogo.Checked)
            {
                if (e.RowIndex < 0) return;
                string id = Convert.ToString(dgvProductos.Rows[e.RowIndex].Cells[0].Value);
                Variables.ProductoId(id);
                Editar();
            }
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbCatalogo.Checked)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    string id = Convert.ToString(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells[0].Value);
                    Variables.ProductoId(id);
                    Editar();
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txbFiltrar.Text.Trim();
            if (rdbStock.Checked)
            {
                filtrar = "";
                Stock();
            }

            if (rdbCatalogo.Checked)
            {
                filtrar = " WHERE nombre LIKE '%" + filtro + "%' OR modelo LIKE '%" + filtro + "%' OR descripcion LIKE '%" + filtro + "%'";
                Catalogo();
            }
        }

        private void Stock()
        {
            BaseDatos stock = new BaseDatos();
            string sql = "SELECT p.serie AS 'No. de Serie', p.codigo AS Código, p.modelo AS Modelo, s.cantidad AS Existencia FROM stock_productos s INNER JOIN productos p ON s.producto_id = p.id" + filtrar;
            stock.buscar(sql);
            dgvProductos.DataSource = stock.ds.Tables[0];
        }

        private void Catalogo()
        {
            BaseDatos catalogo = new BaseDatos();
            string sql = "SELECT * FROM Productos" + filtrar;
            catalogo.buscar(sql);
            dgvProductos.DataSource = catalogo.ds.Tables[0];
            dgvProductos.Columns["id"].Visible = false;
        }

        private void Editar()
        {
            ProductosEditar editar = null;
            editar = ProductosEditar.Instancia();
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
