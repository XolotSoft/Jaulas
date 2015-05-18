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
    public partial class ProductosEditar : Form
    {
        public ProductosEditar()
        {
            InitializeComponent();
        }

        BaseDatos bd = new BaseDatos();
        private static ProductosEditar frmInst = null;

        public static ProductosEditar Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new ProductosEditar();
            frmInst.BringToFront();
            return frmInst;
        }

        private void ProductosEditar_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM productos WHERE id = " + Variables.productoId;
            bd.buscar(sql);
            txbSerie.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["serie"]);
            txbCodigo.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["codigo"]);
            txbModelo.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["modelo"]);
            txbDescripcion.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["descripcion"]);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE productos SET serie = '" + txbSerie.Text.Trim() + "', codigo = '" + txbCodigo.Text.Trim() + "', modelo = '" + txbModelo.Text.Trim() + "', descripcion = '" + txbDescripcion.Text.Trim() + "' WHERE id = " + Variables.productoId;
            if (Vacio.txb(this))
            {
                if (bd.insertar(sql))
                {
                    MessageBox.Show("Se actualizaron los datos", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Index();
                }
            }
            else
            {
                MessageBox.Show("No puedes dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }  
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM productos WHERE id = " + Variables.productoId;
            DialogResult dialogo = MessageBox.Show("Realmente deseas eliminar el registro", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogo == DialogResult.OK)
            {
                if (bd.insertar(sql))
                {
                    MessageBox.Show("Se eliminaron los datos", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Index();
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Index();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Index()
        {
            ProductosIndex editar = null;
            editar = ProductosIndex.Instancia();
            editar.MdiParent = MdiAdmin.ActiveForm;
            editar.Show();
            this.Close();
        }

        private void txbSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Numeros(e);
        }

        private void txbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Letras(e);
        }
    }
}
