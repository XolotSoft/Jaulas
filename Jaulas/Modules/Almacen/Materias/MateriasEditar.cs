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
    public partial class MateriasEditar : Form
    {
        public MateriasEditar()
        {
            InitializeComponent();
        }

        private BaseDatos bd = new BaseDatos();
        private static MateriasEditar frmInst = null;
        public static MateriasEditar Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasEditar();
            frmInst.BringToFront();
            return frmInst;
        }

        private void MateriasEditar_Load(object sender, EventArgs e)
        {
            string sql ="SELECT * FROM materias WHERE id = "+ Variables.materiaId;
            bd.buscar(sql);
            txbNombre.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["nombre"]);
            txbModelo.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["modelo"]);
            txbDescripcion.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["descripcion"]);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE materias SET nombre = '" + txbNombre.Text.Trim() + "', modelo = '" + txbModelo.Text.Trim() + "', descripcion = '" + txbDescripcion.Text.Trim() + "' WHERE id = " + Variables.materiaId;
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
            string sql = "DELETE FROM materias WHERE id = " + Variables.materiaId;
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
            MateriasIndex editar = null;
            editar = MateriasIndex.Instancia();
            editar.MdiParent = MdiAdmin.ActiveForm;
            editar.Show();
            this.Close();
        }

        private void txbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasNumerosEspacios(e);
        }
    }
}
