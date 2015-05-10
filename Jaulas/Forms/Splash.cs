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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            tiempo.Enabled = true;
        }
        int i;
        Login login = new Login();

        private void tiempo_Tick(object sender, EventArgs e)
        {
            i += 2;
            if(i==50)
            {
                login.Show();
                this.Hide();
            }
        }
    }
}
