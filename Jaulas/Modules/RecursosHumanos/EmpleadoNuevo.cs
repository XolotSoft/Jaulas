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
    public partial class EmpleadoNuevo : Form
    {
        public EmpleadoNuevo()
        {
            InitializeComponent();
            dtpIngreso.Format = DateTimePickerFormat.Custom;
            dtpIngreso.CustomFormat = "yyyy-MM-dd";
        }

        BaseDatos bd = new BaseDatos();
        private static EmpleadoNuevo frmInst = null;

        public static EmpleadoNuevo Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new EmpleadoNuevo();
            frmInst.BringToFront();
            return frmInst;
        }

        private void EmpleadoNuevo_Load(object sender, EventArgs e)
        {
            bd.buscar("SELECT * FROM catalogo WHERE metacatalogo_id = 2");
            cmbArea.DisplayMember = "nombre";
            cmbArea.ValueMember = "id";
            cmbArea.DataSource = bd.ds.Tables[0].DefaultView;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO empleados(nombre,paterno,materno,ingreso,area_id)VALUES('" + txbNombre.Text.Trim() + "','" + txbPaterno.Text.Trim() + "','" + txbMaterno.Text.Trim() + "','" + dtpIngreso.Text + "','" + cmbArea.SelectedValue + "')";
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
            EmpleadoIndex index = null;
            index = EmpleadoIndex.Instancia();
            index.MdiParent = MdiAdmin.ActiveForm;
            index.Show();
            this.Close();
        }

        private void txbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasEspacios(e);
        }

        private void txbPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasEspacios(e);
        }

        private void txbMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasEspacios(e);
        }
    }
}
