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
        }

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
            string sql = "SELECT * FROM productos";
            datos.buscar(sql);
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.DataSource = datos.ds.Tables[0];
            dgvProductos.Columns["id"].Visible = false;

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
    }
}
