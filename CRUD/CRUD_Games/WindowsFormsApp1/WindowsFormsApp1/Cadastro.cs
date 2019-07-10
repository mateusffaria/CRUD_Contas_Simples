using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.modelo;
using WindowsFormsApp1.util;

namespace WindowsFormsApp1
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
            cbES.Items.Add("Entrada");
            cbES.Items.Add("Saida");
            cbES.Text = "Entrada";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double caixa = 0;
            Fluxo novoItem = new Fluxo();
            foreach (Fluxo p in novoItem.listar())
            {
                caixa = caixa + p.valor;
            }
            txtCaixa.Text = caixa.ToString();
        }

        private void btnLancar_Click(object sender, EventArgs e)
        {

            try
            {
                if(cbES.SelectedItem.ToString() == "Entrada" || cbES.SelectedItem.ToString() == "Saida")
                {
                  double caixa = 0;
                  string descricao = txtDescricao.Text;
                  string entradaSaida = cbES.Text;
                  double valor = Convert.ToDouble(txtValor.Text);

                  Fluxo lancamento = new Fluxo();

                  lancamento.descricao = descricao;
                  lancamento.entradaSaida = entradaSaida;
                  lancamento.valor = valor;

                  lancamento.cadastrar();

                  Fluxo novoItem = new Fluxo();
                  foreach (Fluxo p in novoItem.listar())
                  {
                    caixa = caixa + p.valor;
                  }
                  txtCaixa.Text = caixa.ToString();

                    MessageBox.Show("Operação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar. " + ex.Message, 
                    "Falha na operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            Histórico abrirHistorico = new Histórico();

            abrirHistorico.ShowDialog();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            double caixa = 0;
            Fluxo novoItem = new Fluxo();
            foreach (Fluxo p in novoItem.listar())
            {
                caixa = caixa + p.valor;
            }
            txtCaixa.Text = caixa.ToString();
        }
    }
}
