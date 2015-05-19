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
            dgvDetalle.Columns.Add("id", "id");
            dgvDetalle.Columns.Add("articulo", "Artículo");
            dgvDetalle.Columns.Add("cantidad", "Cantidad");
            dgvDetalle.Columns.Add("subtotal", "Sub Total");
            dgvDetalle.Columns["id"].Visible = false;
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
            double total = 0;
            double cantidad = Convert.ToInt16(txbCantidad.Text);
            int existencia = Existencia();
            int sel = Convert.ToInt16(cmbArticulo.SelectedValue);

            if (txbCantidad.Text.Trim() == string.Empty || txbCantidad.Text.Trim() == "0")
            {
                MessageBox.Show("Ingresa una cantidad", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbCantidad.Focus();
            }
            else
            {
                if (existencia < 1)
                {
                    MessageBox.Show("No hay articulos en existencia", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (existencia < cantidad)
                    {
                        MessageBox.Show("No hay articulos suficientes, quedan " + existencia + " productos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (sel == 1 && cantidad < 6) precio = 1500;
                        if (sel == 2 && cantidad < 6) precio = 1000;
                        if (sel == 3 && cantidad < 6) precio = 850;
                        if (sel == 1 && cantidad > 5) precio = 1300;
                        if (sel == 2 && cantidad > 5) precio = 900;
                        if (sel == 3 && cantidad > 5) precio = 700;
                        double subtotal = Math.Round(precio * cantidad);
                        dgvDetalle.Rows.Add(cmbArticulo.SelectedValue, cmbArticulo.Text, txbCantidad.Text, subtotal);
                        foreach (DataGridViewRow row in dgvDetalle.Rows)
                        {
                            total += Convert.ToDouble(row.Cells["subtotal"].Value);
                        }
                        txbTotal.Text = String.Format("{0:0,0.00}", total);
                    }
                }
            }
        }

        private int Existencia()
        {
            BaseDatos con = new BaseDatos();
            con.buscar("SELECT * FROM stock_productos WHERE producto_id = " + cmbArticulo.SelectedValue);
            int existencia = Convert.ToInt16(con.ds.Tables[0].Rows[0]["cantidad"]);
            return existencia;
        }

        private void cmbArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Existencia() < 6)
            {
                MessageBox.Show("Quedan en existencia " + Existencia() + " productos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
