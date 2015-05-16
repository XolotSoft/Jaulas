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
    public partial class StockIndex : Form
    {
        public StockIndex()
        {
            InitializeComponent();
        }
        private static StockIndex frmInst = null;
        public static StockIndex Instancia()
        {
            if (frmInst == null || frmInst.IsDisposed == true) frmInst = new StockIndex();
            frmInst.BringToFront();
            return frmInst;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            StockNuevo nuevo = null;
            nuevo = StockNuevo.Instancia();
            nuevo.MdiParent = MDI.ActiveForm;
            nuevo.Show();
            this.Close();
        }
    }
}
