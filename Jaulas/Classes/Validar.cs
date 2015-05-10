using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Jaulas
{
    class Validar
    {
        public static void LetrasNumeros(KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se permiten letras y números", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void LetrasNumerosEspacios(KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsWhiteSpace(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Solo se permiten letras y numeros", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public static void LetrasEspacios(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsWhiteSpace(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Solo se permiten letras", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public static void Letras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se permiten letras", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void Numeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se permiten números", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static bool Email(string smail)
        {
            return Regex.IsMatch(smail, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$");
        }

        public static void NumerosPunto(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (e.KeyChar == '.')
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show("Solo se permiten números y un punto decimal", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
