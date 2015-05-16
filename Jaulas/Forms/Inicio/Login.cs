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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string userInput, passInput;
        MdiAdmin mdiAdmin = new MdiAdmin();
        MdiUser mdiUser = new MdiUser();
        BaseDatos bd = new BaseDatos();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            userInput = txbUser.Text;
            passInput = txbPass.Text;
            if (Vacio.txb(this))
            {
                bd.buscar("SELECT * FROM ususarios WHERE username = '"+ userInput +"' && password = '"+ passInput +"'");
                if (bd.ds.Tables[0].Rows.Count > 0)
                {
                    if (bd.ds.Tables[0].Rows[0]["tipo"] == "Administrador")
                    {
                        this.Hide();
                        mdiAdmin.Show();
                    }
                    if (bd.ds.Tables[0].Rows[0]["tipo"] == "Usuario")
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
                MessageBox.Show("Debes de llenar ambos campos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
