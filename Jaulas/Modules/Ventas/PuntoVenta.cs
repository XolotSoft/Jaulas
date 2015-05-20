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
    public partial class PuntoVenta : Form
    {
        public PuntoVenta()
        {
            InitializeComponent();
            dgvDetalle.Columns.Add("Articulo", "Articulo");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("Total", "Total");
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.RowHeadersVisible = false;
        }

        BaseDatos productos = new BaseDatos();
        private static PuntoVenta frmInst = null;

        public static PuntoVenta Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new PuntoVenta();
            frmInst.BringToFront();
            return frmInst;
        }

        private void PuntoVenta_Load(object sender, EventArgs e)
        {
            productos.buscar("SELECT * FROM productos");
            cmbArticulo.DisplayMember = "modelo";
            cmbArticulo.ValueMember = "id";
            cmbArticulo.DataSource = productos.ds.Tables[0].DefaultView;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double precio = 0;
            double cantidad = Convert.ToInt16(txbCantidad.Text);
            int sel = Convert.ToInt16(cmbArticulo.SelectedValue);
            if (sel == 1) precio = 1500;
            if (sel == 2) precio = 1000;
            if (sel == 3) precio = 850;
            double total = Math.Round( precio * cantidad );
            dgvDetalle.Rows.Add(cmbArticulo.Text, txbCantidad.Text,total);
        }
    }
}
