using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_IMC
{
    public partial class CalculadoraIMC : Form
    {
        public CalculadoraIMC()
        {
            InitializeComponent();
        }

        private void MudarCorBotao(Button botaoclicado) 
        {
            foreach ( Control botao  in this.Controls)
            {
                if (botao is Button btn) {
                    if (btn == btnLimpar || btn == btnSair || btn == btnCalcular) 
                    {
                        continue;
                    }
                    btn.BackColor = SystemColors.Control;   
                }
            }
            botaoclicado.BackColor = Color.Green;  
        }

        private void btnMulher_Click(object sender, EventArgs e)
        {
            MudarCorBotao((Button)sender);
        }

        private void btnHomem_Click(object sender, EventArgs e)
        {
            MudarCorBotao((Button)sender);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja fechar a calculadora?", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.Yes) 
            {
                this.Close();   
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!(btnHomem.BackColor == Color.Green) && !(btnMulher.BackColor == Color.Green)) 
            {
                MessageBox.Show("Por favor, selecione o seu sexo", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idade = Convert.ToInt32(txtIdade.Text);
                double peso = Convert.ToDouble(txtPeso.Text);
                double altura = Convert.ToDouble(txtAltura.Text);

                // Calculando o IMC
                double calc = peso / Math.Pow(altura, 2);

                if (idade > 20)
                {
                    string classificacao = "", riscoSaude = "";

                    if (calc < 18.5)
                    {
                        classificacao = "Abaixo do peso";
                        riscoSaude = "Aumento do risco";
                    }
                    else if (calc >= 18.5 && calc <= 24.9) 
                    {
                        classificacao = "Peso normal";
                        riscoSaude = "Baixo risco";
                    }
                    else if (calc >= 25 && calc <= 29.9) 
                    {
                        classificacao = "Sobrepeso";
                        riscoSaude = "Aumento do risco";
                    }
                    else if (calc >= 30 && calc <= 34.9)
                    {
                        classificacao = "Obesidade Grau 1";
                        riscoSaude = "Alto risco";
                    }
                    else if (calc >= 35 && calc <= 39.9)
                    {
                        classificacao = "Obesidade Grau 2";
                        riscoSaude = "Risco muito alto";
                    }
                    else 
                    {
                        classificacao = "Obesidade Grau 3";
                        riscoSaude = "Risco muito extremo";
                    }

                    MessageBox.Show($"Idade: {idade} anos\nClassificação: {classificacao}\nRisco para a saúde: {riscoSaude}","Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception) 
            {
                MessageBox.Show("Preencha todos os campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }
    }
}
