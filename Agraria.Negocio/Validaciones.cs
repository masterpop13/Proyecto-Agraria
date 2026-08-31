using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio
{
    public static class Validaciones
    {
        // Método para validar solo letras (y permitir espacios)
        public static void SoloTexto(KeyPressEventArgs e)
        {
            // Solo permite letras y el espacio
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // Método para validar solo números
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control (backspace, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Método para evitar copiar y pegar (Ctrl + C, Ctrl + V, Ctrl + X)
        public static void DeshabilitarCopiarPegar(KeyEventArgs e)
        {
            // Verifica si se presiona Ctrl+C, Ctrl+V o Ctrl+X
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true; // Evita que se ejecute el comando
            }
        }
        public static void TextoYNumero(KeyPressEventArgs e)
        {
            // Solo permite letras, números y teclas de control (como backspace)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void SoloTextoNumeroEspacio(KeyPressEventArgs e)
        {
            // Permite solo letras, números, espacios y teclas de control (como retroceso)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }


        // Método para validar solo números y puntos decimales con ErrorProvider
        public static void SoloNumerosYPunto(TextBox textBox, KeyPressEventArgs e, ErrorProvider errorProvider)
        {
            // Verificar si el primer carácter es un punto
            if (textBox.Text.Length == 0 && e.KeyChar == '.')
            {
                e.Handled = true;
                errorProvider.SetError(textBox, "El número no puede comenzar con un punto.");
                return;
            }

            // Limpiar el error si se escribe un carácter válido
            errorProvider.SetError(textBox, "");

            // Permitir solo números, teclas de control y un punto
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // Validar formato de moneda: hasta 4 números antes del punto decimal y hasta 2 después del punto
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                string[] partes = textBox.Text.Split('.');

                if (partes.Length == 1 && partes[0].Length >= 6 && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                else if (partes.Length == 2 && partes[1].Length >= 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        public static bool ValidarCero(TextBox textBox, ErrorProvider errorProvider)
        {
            // Eliminar el signo de moneda y espacios en blanco
            string text = textBox.Text.Replace("$", "").Trim();

            if (decimal.TryParse(text, out decimal value) && value == 0)
            {
                errorProvider.SetError(textBox, ""); // Limpia el error si el valor es exactamente 0
                return true;
            }
            else
            {
                errorProvider.SetError(textBox, "El valor en Total Deuda debe ser de 0.00");
                return false;
            }
        }

        public static bool ValidarValorNoNegativo(TextBox textBox, ErrorProvider errorProvider)
        {
            if (decimal.TryParse(textBox.Text, out decimal value) && value < 0)
            {
                errorProvider.SetError(textBox, "No se puede aceptar una transacción con valor negativo.");
                return false;
            }
            else
            {
                errorProvider.SetError(textBox, ""); // Limpia el error si el valor es válido
                return true;
            }
        }

        public static void SoloNumerosYComa(TextBox textBox, KeyPressEventArgs e, ErrorProvider errorProvider)
        {
            // No permitir que el primer carácter sea una coma
            if (textBox.Text.Length == 0 && e.KeyChar == ',')
            {
                e.Handled = true;
                errorProvider.SetError(textBox, "El número no puede comenzar con una coma.");
                return;
            }

            // Limpiar el error si se escribe un carácter válido
            errorProvider.SetError(textBox, "");

            // Permitir solo números, teclas de control y una coma
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            // Permitir solo una coma decimal
            if (e.KeyChar == ',' && textBox.Text.Contains(","))
            {
                e.Handled = true;
                return;
            }

            // Validar formato: hasta 6 dígitos antes de la coma y hasta 2 después
            if (char.IsDigit(e.KeyChar) || e.KeyChar == ',')
            {
                string[] partes = textBox.Text.Split(',');

                if (partes.Length == 1 && partes[0].Length >= 6 && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
                else if (partes.Length == 2 && partes[1].Length >= 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

    }
}


