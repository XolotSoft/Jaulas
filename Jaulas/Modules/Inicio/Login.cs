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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txbUser.Focus();
        }

        string userInput, passInput, tipo;
        string salt = ConfigurationManager.AppSettings["salt"];
        MdiAdmin mdiAdmin = new MdiAdmin();
        MdiUser mdiUser = new MdiUser();
        BaseDatos bd = new BaseDatos();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            userInput = txbUser.Text;
            passInput = Hash.sha1(Hash.md5(txbPass.Text + salt));
            if (Vacio.txb(this))
            {
                bd.buscar("SELECT * FROM usuarios WHERE username = '"+ userInput +"' AND password = '"+ passInput +"'");
                if (bd.ds.Tables[0].Rows.Count > 0)
                {
                    tipo = Convert.ToString(bd.ds.Tables[0].Rows[0]["rol_id"]);
                    if (tipo == "1")
                    {
                        this.Hide();
                        mdiAdmin.Show();
                    }
                    if (tipo == "2")
                    {
                        this.Hide();
                        mdiUser.Show();
                    }                   
                }
                else
                {
                    MessageBox.Show("Datos incorrectos", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar.Textbox(this);
                    txbUser.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debes de llenar ambos campos", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnIngresar.PerformClick();
            }
        }

        private void txbUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.LetrasNumeros(e);
        }
    }
}
