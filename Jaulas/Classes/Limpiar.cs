using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jaulas
{
    class Limpiar
    {
        public static void Textbox(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = string.Empty;
            }
        }

        public static void Combobox(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndex = 0;
            }
        }

        public static void Checkbox(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is CheckBox) ((CheckBox)ctrl).Checked = false;
            }
        }

        public static void Todo(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = string.Empty;
                if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndex = -0;
                if (ctrl is CheckBox) ((CheckBox)ctrl).Checked = false;
            }
        }
    }
}
