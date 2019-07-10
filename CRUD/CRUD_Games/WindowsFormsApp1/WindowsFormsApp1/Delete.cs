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

namespace WindowsFormsApp1
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            DialogResult confirmar = MessageBox.Show("Deseja excluir registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            Fluxo novoItem = new Fluxo();
            foreach (Fluxo p in novoItem.listar())
            {
                contador++;
                if (p.id == Convert.ToInt16(txtID.Text))
                {
                    if (confirmar.ToString().ToUpper() == "YES")
                    {
                        try
                        {
                            Fluxo apagar = new Fluxo();
                            apagar.id = Convert.ToInt16(txtID.Text);

                            apagar.delete();

                            MessageBox.Show("Operação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao tentar apagar. " + ex.Message,
                                "Falha na operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                }else if(contador.Equals(p.listar().Count))
                {
                    MessageBox.Show("Id não encontrado", "Falha na opreação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
