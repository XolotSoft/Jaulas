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
    public partial class UsuariosNuevo : Form
    {
        public UsuariosNuevo()
        {
            InitializeComponent();
        }

        private BaseDatos bd = new BaseDatos();
        private BaseDatos roles = new BaseDatos();
        private static UsuariosNuevo frmInst = null;
        string salt = ConfigurationManager.AppSettings["salt"];

        public static UsuariosNuevo Instancia()
        {
            if (frmInst == null ||  frmInst.IsDisposed == true) frmInst = new UsuariosNuevo();
            frmInst.BringToFront();
            return frmInst;
        }

        private void UsuariosNuevo_Load(object sender, EventArgs e)
        {   
            roles.buscar("SELECT * FROM catalogo WHERE metacatalogo_id = 1");
            cmbTipo.ValueMember = "id";
            cmbTipo.DisplayMember = "nombre";
            cmbTipo.DataSource = roles.ds.Tables[0];
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (Vacio.txb(this))
            {
                if (txbPass.Text == txbConfirmar.Text)
                {
                    string sql1 = "SELECT * FROM usuarios WHERE username = '" + txbUsuario.Text + "'";
                    bd.buscar(sql1);
                    if (bd.ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Ya eexiste un usuario registrado con este Usuario", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string pass = Hash.sha1(Hash.md5(txbPass.Text.Trim() + salt));
                        string sql2 = "INSERT INTO usuarios(nombre,username,password,rol_id) VALUES ('" + 
                            txbNombre.Text.Trim() + "','" + txbUsuario.Text.Trim() + "','" + pass + 
                            "','" + cmbTipo.SelectedValue + "')";
                        if (bd.insertar(sql2))
                        {
                            MessageBox.Show("Usuario creado correctamente", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Index();
                        }
                        else
                        {
                            MessageBox.Show("No se guardo el usuario", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Las Contraseñas no coinciden", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes de llenar todos los campos", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
