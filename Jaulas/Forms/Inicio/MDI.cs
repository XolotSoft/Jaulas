﻿using System;
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
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosIndex index = null;
            index = UsuariosIndex.Instncia();
            index.MdiParent = this;
            index.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void materiasPrimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //StockIndex index = null;
            //index = StockIndex.Intancia();
            //index.MdiParent = this;
            //index.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockIndex index = null;
            index = StockIndex.Intancia();
            index.MdiParent = this;
            index.Show();
        }
    }
}
