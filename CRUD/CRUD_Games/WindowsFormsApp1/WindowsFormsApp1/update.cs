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
namespace WindowsFormsApp1.util
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
            cbES.Items.Add("Entrada");
            cbES.Items.Add("Saida");
            cbES.Text = "Entrada";
        }

        private void btnLancar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            Fluxo novoItem = new Fluxo();
            foreach (Fluxo p in novoItem.listar())
            {
                contador++;
                if(p.id == Convert.ToInt16(txtId.Text))
                {
                    try
                    {
                        string descricao = txtDescricao.Text;
                        string entradaSaida = cbES.Text;
                        double valor = Convert.ToDouble(txtValor.Text);
                        int id = Convert.ToInt16(txtId.Text);

                        Fluxo lancamento = new Fluxo();

                        lancamento.descricao = descricao;
                        lancamento.entradaSaida = entradaSaida;
                        lancamento.valor = valor;
                        lancamento.id = id;

                        lancamento.Update();

                        MessageBox.Show("Operação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao tentar alterar. " + ex.Message,
                         "Falha na operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                }
                else if (contador.Equals(p.listar().Count))
                {
                    MessageBox.Show("Id não encontrado", "Falha na opreação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
