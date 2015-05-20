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
    public partial class ProduccionPedidos : Form
    {
        public ProduccionPedidos()
        {
            InitializeComponent();
            rdbPedidos.Select();
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.RowHeadersVisible = false;
        }

        string filtrar;
        BaseDatos datos = new BaseDatos();
        private static ProduccionPedidos frmInst = null;

        public static ProduccionPedidos Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new ProduccionPedidos();
            frmInst.BringToFront();
            return frmInst;
        }

        private void ProduccionPedidos_Load(object sender, EventArgs e)
        {
            Pedidos();
        }

        private void Pedidos()
        {
            BaseDatos pedidos = new BaseDatos();
            string sql = "SELECT * FROM pedidos " + filtrar;
            pedidos.buscar(sql);
            dgvProductos.DataSource = pedidos.ds.Tables[0];
        }

        private void Produccion()
        {
            BaseDatos produccion = new BaseDatos();
            string sql = "SELECT * FROM produccion " + filtrar;
            produccion.buscar(sql);
            dgvProductos.DataSource = produccion.ds.Tables[0];
            dgvProductos.Columns["id"].Visible = false;
        }

        private void rdbPedidos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPedidos.Checked)
            {
                Pedidos();
                lblTitulo.Text = "Listado de pedidos";
            }
        }

        private void rdbProduccion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProduccion.Checked)
            {
                Produccion();
                lblTitulo.Text = "Catálogo de productos en Producción";
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txbFiltrar.Text.Trim();
            if (rdbPedidos.Checked)
            {
                filtrar = "";
                Pedidos();
            }

            if (rdbProduccion.Checked)
            {
                filtrar = "";
                Produccion();
            }
        }

    }
}
