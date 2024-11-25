using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicioTelegrama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcularPrecio_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = 'o'; // 'o' para ordinario, 'u' para urgente
            int numPalabras = 0;
            double coste = 0;

            // Leo el telegrama
            textoTelegrama = txtTelegrama.Text;

            // Verifico qué RadioButton está seleccionado
            if (rbUrgente.Checked)
            {
                tipoTelegrama = 'u';
            }

            // Obtengo el número de palabras que forma el telegrama
            numPalabras = Regex.Matches(textoTelegrama.Trim(), @"\b\w+\b").Count;

            // Si el telegrama es ordinario
            if (tipoTelegrama == 'o')
            {
                if (numPalabras <= 10)
                {
                    coste = 3;
                }
                else
                {
                    coste = 2.5 + 0.5 * (numPalabras - 10);
                }
            }
            else // Si el telegrama es urgente
            {
                if (numPalabras <= 10)
                {
                    coste = 6;
                }
                else
                {
                    coste = 5 + 0.75 * (numPalabras - 10);
                }
            }

            // Muestro el coste
            txtPrecio.Text = coste.ToString() + " euros";
        }
    }
}