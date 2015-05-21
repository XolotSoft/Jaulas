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
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            InitializeComponent();
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.RowHeadersVisible = false;
        }

        BaseDatos productos = new BaseDatos();
        BaseDatos pedidos = new BaseDatos();
        BaseDatos bd = new BaseDatos();
        private static Pedidos frmInst = null;

        public static Pedidos Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new Pedidos();
            frmInst.BringToFront();
            return frmInst;
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            productos.buscar("SELECT * FROM productos");
            cmbArticulo.DisplayMember = "modelo";
            cmbArticulo.ValueMember = "id";
            cmbArticulo.DataSource = productos.ds.Tables[0].DefaultView;
            BuscarPedidos();
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            MessageBox.Show(fecha);
            if (Vacio.txb(this))
            { 
                string sql = "INSERT INTO pedidos(producto_id,cantidad,fecha,estado_id)VALUES('" + cmbArticulo.SelectedValue + "','" + txbCantidad.Text + "','" + fecha + "',7)";
                if (bd.insertar(sql))
                {
                    MessageBox.Show("Se ha agregado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BuscarPedidos();
                }
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarPedidos()
        {
            pedidos.ds.Clear();
            pedidos.buscar("SELECT d.modelo AS Producto, p.cantidad AS Cantidad, p.fecha AS Fecha, c.nombre AS Etapa FROM pedidos p INNER JOIN productos d ON p.producto_id = d.id INNER JOIN catalogo c ON p.estado_id = c.id");
            dgvPedidos.DataSource = pedidos.ds.Tables[0];
        }
    }
}
