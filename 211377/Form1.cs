using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211377
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int count= 1;

        private void btnInserir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirmar a venda?", "Confirmação!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                count++;
                txtVenda.Text = count.ToString();
                dataGridView.Rows.Add(txtDesc.Text, txtQnt.Text, txtUnit.Text);

                txtDesc.Clear();
                txtQnt.Clear();
                txtUnit.Clear();

                MessageBox.Show("Venda Concluida com Sucesso", "Sucesso!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
            lblGrade.Text = dataGridView.RowCount.ToString();

            //FAZER A FUNÇÂO DE MOSTRAR TOTAL
            //dataGridView.SelectAll();
            //double total = Convert.ToDouble(lblTotal.Text) + (Convert.ToDouble(dataGridView.CurrentRow.Cells["Quantidade"].Value) * Convert.ToDouble(dataGridView.CurrentRow.Cells["valor_unit"].Value));

            //lblTotal.Text = total.ToString();
            txtSelecionados.Text = dataGridView.SelectedRows.Count.ToString();
            
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
                if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Item Selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja remover??", "Remover!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);

                    lblGrade.Text = dataGridView.RowCount.ToString();

                    //dataGridView.SelectAll();
                    //double total = Convert.ToDouble(lblTotal.Text) + (Convert.ToDouble(dataGridView.CurrentRow.Cells["Quantidade"].Value) * Convert.ToDouble(dataGridView.CurrentRow.Cells["valor_unit"].Value));

                    //lblTotal.Text = total.ToString();

                    txtSelecionados.Text = dataGridView.SelectedRows.Count.ToString();
                    

                    MessageBox.Show("Venda Removida com Sucesso", "Sucesso!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSelecionados.Text = dataGridView.SelectedRows.Count.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDesc.Clear();
            txtQnt.Clear();
            txtUnit.Clear();
        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            txtDesc.Clear();
            txtQnt.Clear();
            txtUnit.Clear();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Item Selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtVenda.Clear();
                txtDesc.Text = dataGridView.CurrentRow.Cells["Descricao"].Value.ToString();
                txtQnt.Text = dataGridView.CurrentRow.Cells["Quantidade"].Value.ToString();
                txtUnit.Text = dataGridView.CurrentRow.Cells["valor_unit"].Value.ToString();

                btnAtt.Visible = true;
            }
        }

        private void btnAtt_Click(object sender, EventArgs e)
        {
            dataGridView.CurrentRow.Cells["Descricao"].Value = txtDesc.Text;
            dataGridView.CurrentRow.Cells["Quantidade"].Value = txtDesc.Text;
            dataGridView.CurrentRow.Cells["valor_unit"].Value = txtDesc.Text;

            txtDesc.Clear();
            txtQnt.Clear();
            txtUnit.Clear();
            txtVenda.Text = count.ToString();

            btnAtt.Visible = false;
        }
    }
}
