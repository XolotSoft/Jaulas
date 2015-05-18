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
    public partial class ProductosNuevo : Form
    {
        public ProductosNuevo()
        {
            InitializeComponent();
        }

        BaseDatos bd = new BaseDatos();
        private static ProductosNuevo frmInst = null;

        public static ProductosNuevo Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new ProductosNuevo();
            frmInst.BringToFront();
            return frmInst;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO productos(serie,codigo,modelo,descripcion)VALUES('" + txbSerie.Text.Trim() + "','" + txbCodigo.Text.Trim() + "','" + txbModelo.Text.Trim() + "','" + txbDescripcion.Text.Trim() + "')";
            if (Vacio.txb(this))
            {
                if (bd.insertar(sql))
                {
                    MessageBox.Show("Se agrego el registro", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Index();
                }
            }
            else
            {
                MessageBox.Show("No puedes dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
