using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Jaulas
{
    public partial class UsuarioEditar : Form
    {
        public UsuarioEditar()
        {
            InitializeComponent();
        }
        private BaseDatos roles = new BaseDatos();
        private BaseDatos datos = new BaseDatos();
        private static UsuarioEditar frmInst = null;
        string salt = ConfigurationManager.AppSettings["salt"];

        public static UsuarioEditar Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new UsuarioEditar();
            frmInst.BringToFront();
            return frmInst;
        }

        private void UsuarioEditar_Load(object sender, EventArgs e)
        {
            roles.buscar("SELECT * FROM catalogo WHERE metacatalogo_id = 1");
            cmbTipo.ValueMember = "id";
            cmbTipo.DisplayMember = "nombre";
            cmbTipo.DataSource = roles.ds.Tables[0];

            datos.buscar("SELECT * FROM usuarios WHERE id = "+ Variables.usuarioId);
            txbNombre.Text = Convert.ToString(datos.ds.Tables[0].Rows[0]["nombre"]);
            txbUsuario.Text = Convert.ToString(datos.ds.Tables[0].Rows[0]["username"]);
            cmbTipo.SelectedValue = Convert.ToInt16(datos.ds.Tables[0].Rows[0]["rol_id"]);
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (Vacio.txb(this))
            {
                if (txbPass.Text == txbConfirmar.Text)
                {
                    string pass = Hash.sha1(Hash.md5(txbPass.Text.Trim() + salt));
                    string sql = "UPDATE usuarios SET nombre = '" + txbNombre.Text.Trim() + "', username = '" + txbUsuario.Text.Trim() + "', password = '" + pass + "', rol_id = " + cmbTipo.SelectedValue + "WHERE id = " + Variables.usuarioId;
                    if (datos.insertar(sql))
                    {
                        MessageBox.Show("Se ha actualizado el usuario", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Index();
                    }
                    else
                    {
                        MessageBox.Show("No se actualizo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }  
            }
            else
            {
                MessageBox.Show("No puedes dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Realmente deseas eliminar al usuario?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dialogo == DialogResult.OK)
            {
                string sql = "DELETE FROM usuarios WHERE id = "+ Variables.usuarioId;
                if (datos.insertar(sql))
                {
                    MessageBox.Show("Se ha eliminado el usuario", "Correcto", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Index();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            UsuariosIndex index = null;
            index = UsuariosIndex.Instncia();
            index.MdiParent = MdiAdmin.ActiveForm;
            index.Show();
            this.Close();
        }

        private void txbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasEspacios(e);
        }

        private void txbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasNumeros(e);
        }

        private void txbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasNumeros(e);
        }

        private void txbConfirmar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasNumeros(e);
        }
    }
}
