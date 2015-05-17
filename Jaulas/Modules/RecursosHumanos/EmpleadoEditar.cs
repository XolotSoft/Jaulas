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
    public partial class EmpleadoEditar : Form
    {
        public EmpleadoEditar()
        {
            InitializeComponent();
            dtpIngreso.Format = DateTimePickerFormat.Custom;
            dtpIngreso.CustomFormat = "yyyy-MM-dd";
        }

        BaseDatos areas = new BaseDatos();
        BaseDatos bd = new BaseDatos();
        private static EmpleadoEditar frmInst = null;

        public static EmpleadoEditar Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new EmpleadoEditar();
            frmInst.BringToFront();
            return frmInst;
        }

        private void EmpleadoEditar_Load(object sender, EventArgs e)
        {
            areas.buscar("SELECT * FROM catalogo WHERE metacatalogo_id = 2");
            cmbArea.DisplayMember = "nombre";
            cmbArea.ValueMember = "id";
            cmbArea.DataSource = areas.ds.Tables[0].DefaultView;

            string sql = "SELECT * FROM empleados WHERE id = " + Variables.empleadoId;
            bd.buscar(sql);
            txbNombre.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["nombre"]);
            txbPaterno.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["paterno"]);
            txbMaterno.Text = Convert.ToString(bd.ds.Tables[0].Rows[0]["materno"]);
            dtpIngreso.Value = Convert.ToDateTime(bd.ds.Tables[0].Rows[0]["ingreso"]);
            cmbArea.SelectedValue = Convert.ToInt16(bd.ds.Tables[0].Rows[0]["area_id"]);
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE empleados SET nombre = '" + txbNombre.Text.Trim() + "', paterno = '" + txbPaterno.Text.Trim() + "', materno = '" + txbMaterno.Text.Trim() + "', ingreso = '" + dtpIngreso.Text + "', area_id = '" + cmbArea.SelectedValue + "' WHERE id = " + Variables.empleadoId;
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
            string sql = "DELETE FROM empleados WHERE id = " + Variables.empleadoId;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Index();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Index()
        {
            EmpleadoIndex editar = null;
            editar = EmpleadoIndex.Instancia();
            editar.MdiParent = MdiAdmin.ActiveForm;
            editar.Show();
            this.Close();
        }
    }
}
