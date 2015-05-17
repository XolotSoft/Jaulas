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
    public partial class MateriasNuevo : Form
    {
        public MateriasNuevo()
        {
            InitializeComponent();
        }

        BaseDatos bd = new BaseDatos();
        private static MateriasNuevo frmInst = null;

        public static MateriasNuevo Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasNuevo();
            frmInst.BringToFront();
            return frmInst;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO materias(nombre,modelo,descripcion)VALUES('"+txbNombre.Text.Trim()+"','"+txbModelo.Text.Trim()+"','"+txbDescripción.Text.Trim()+"')";
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

        private void Index()
        {
            MateriasIndex editar = null;
            editar = MateriasIndex.Instancia();
            editar.MdiParent = MdiAdmin.ActiveForm;
            editar.Show();
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Index();
        }
    }
}
