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
    public partial class UsuariosNuevo : Form
    {
        public UsuariosNuevo()
        {
            InitializeComponent();
        }
        private BaseDatos bd = new BaseDatos();
        private static UsuariosNuevo frmInst = null;
        public static UsuariosNuevo Instancia()
        {
            if (frmInst == null ||  frmInst.IsDisposed == true) frmInst = new UsuariosNuevo();
            frmInst.BringToFront();
            return frmInst;
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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO usuarios(nombre,username,password,tipo) VALUES ('" + txbNombre.Text.Trim() + "','" + txbUsuario.Text.Trim() + "','" + txbPass.Text.Trim() + "','" + cmbTipo.Text + "')";
            if (Vacio.txb(this))
            {
                if (Vacio.cbx(this))
                {
                    if (txbPass.Text == txbConfirmar.Text)
                    {
                        string sq = "SELECT * FROM usuarios WHERE username = '" + txbUsuario.Text + "'";
                        bd.buscar(sq);
                        if (bd.ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Ya eexiste un usuario registrado con este Usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (bd.insertar(sql))
                            {
                                MessageBox.Show("Usario creado correctamente", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Index();
                            }
                            else
                            {
                                MessageBox.Show("No se guardo el usuario", "Atencio",
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
                    MessageBox.Show("Debes seleccionar una opción", "Atecion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes de llenar todos los campos","Atención",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
