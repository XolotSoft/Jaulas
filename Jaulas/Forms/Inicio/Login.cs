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
        string userStored = "admin";
        string passStored = "admin";

        MDI mdi = new MDI();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            userInput = txbUser.Text;
            passInput = txbPass.Text;
            if (Vacio.txb(this))
            {
                if (userInput == userStored && passInput == passStored)
                {
                    this.Hide();
                    MDI mdi = new MDI();
                    mdi.Show();
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
