using Npgsql;
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
    public partial class Histórico : Form
    {
        public Histórico()
        {
            InitializeComponent();
            Fluxo novoItem = new Fluxo();
            dgwFluxo.DataSource = novoItem.listar();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update novoUpdate = new update();
            novoUpdate.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Fluxo novoItem = new Fluxo();
            dgwFluxo.DataSource = novoItem.listar();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete apagar = new Delete();
            apagar.ShowDialog();
        }
    }
}
