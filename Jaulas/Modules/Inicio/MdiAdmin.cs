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
    public partial class MdiAdmin : Form
    {
        public MdiAdmin()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
            MateriasIndex index = null;
            index = MateriasIndex.Instancia();
            index.MdiParent = this;
            index.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UsuariosIndex index = null;
            index = UsuariosIndex.Instncia();
            index.MdiParent = this;
            index.Show();
            Form frm = this.MdiChildren.FirstOrDefault(x => x is UsuarioEditar || x is UsuariosNuevo);
            if (frm != null) frm.Close();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadoIndex index = null;
            index = EmpleadoIndex.Instancia();
            index.MdiParent = this;
            index.Show();
            Form frm = this.MdiChildren.FirstOrDefault(x => x is EmpleadoEditar || x is EmpleadoNuevo);
            if (frm != null) frm.Close();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductosIndex index = null;
            index = ProductosIndex.Instancia();
            index.MdiParent = this;
            index.Show();
        }

        private void puntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PuntoVenta punto = null;
            punto = PuntoVenta.Instancia();
            punto.MdiParent = this;
            punto.Show();
        }

        private void productosEnProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProduccionPedidos produccion = null;
            produccion = ProduccionPedidos.Instancia();
            produccion.MdiParent = this;
            produccion.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidos produccion = null;
            produccion = Pedidos.Instancia();
            produccion.MdiParent = this;
            produccion.Show();
        }
    }
}
