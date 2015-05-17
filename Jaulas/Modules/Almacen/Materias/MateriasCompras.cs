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
    public partial class MateriasCompras : Form
    {
        public MateriasCompras()
        {
            InitializeComponent();
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "yyyy-MM-dd";
        }

        BaseDatos bd = new BaseDatos();
        private static MateriasCompras frmInst = null;
        public static MateriasCompras Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new MateriasCompras();
            frmInst.BringToFront();
            return frmInst;
        }

        private void MateriasCompras_Load(object sender, EventArgs e)
        {
            bd.buscar("SELECT id, (nombre +' '+ modelo) AS nombre FROM materias");
            cmbMateria.DisplayMember = "nombre";
            cmbMateria.ValueMember = "id";
            cmbMateria.DataSource = bd.ds.Tables[0].DefaultView;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (Vacio.txb(this))
            {
                if (Validar.decimales(txbCosto.Text))
                {
                    string sql = "INSERT INTO compras(materia_id,cantidad,costo,fecha)VALUES('"+cmbMateria.SelectedValue+"','"+txbCantidad.Text+"','"+txbCosto.Text+"','"+dtpFecha.Text+"')";
                    if (bd.insertar(sql))
                    {
                        MessageBox.Show("Se agrego el registro", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Index();
                    }
                }
                else
                {
                    MessageBox.Show("El formato delcosto no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else
            {
                MessageBox.Show("Debes llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Numeros(e);
        }

        private void txbCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.NumerosPunto(e);
        }
    }
}
