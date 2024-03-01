// calculadora part |


using System;
using System.Windows.Forms;

namespace calculadoraSimples
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // verifica se os campos de entrada são vazios
            if (string.IsNullOrWhiteSpace(txtNumero1.Text) || string.IsNullOrWhiteSpace(txtNumero2.Text))
            {
                MessageBox.Show("Por favor, insira números válidos em ambos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // converte os valores das caixas de texto para números
            if (!double.TryParse(txtNumero1.Text, out double numero1) || !double.TryParse(txtNumero2.Text, out double numero2))
            {
                MessageBox.Show("Por favor, insira números válidos em ambos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // operação de adição
            double resultado = numero1 + numero2;

            // resultado em uma MessageBox
            MessageBox.Show($"O resultado da soma é: {resultado}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
