using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioAvaliacao
{
    public partial class ContasReceber : Form
    {
        public ContasReceber()
        {
            InitializeComponent();
            Mostra();
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }
        string continua = "sim";
        private void ContasReceber_Load(object sender, EventArgs e)
        {

        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            VerificaVazio();
            pegaData();
            if (continua == "sim")
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = Globals.conexao;
                        cnn.Open();
                        MessageBox.Show("Inserido com sucesso!");
                        string sql = "insert into contas (nome, descricao, valor, dataVencimento, tipo) values ('" + txtNome.Text + "','" + txtDescricao.Text + "','" + txtValor.Text + "','" + Globals.DataNova + "', 0)";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            Mostra();
            Limpa();
        }
        private void dgwContasReceber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwContasReceber.CurrentRow.Index != -1)
            {
                txtIdContasReceber.Text = dgwContasReceber.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContasReceber.CurrentRow.Cells[1].Value.ToString();
                txtDescricao.Text = dgwContasReceber.CurrentRow.Cells[2].Value.ToString();
                txtValor.Text = dgwContasReceber.CurrentRow.Cells[3].Value.ToString();
                dtpDataVencimento.Value = Convert.ToDateTime(dgwContasReceber.CurrentRow.Cells[4].Value.ToString());
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "Novo";
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            pegaData();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = Globals.conexao;
                    cnn.Open();
                    string sql = "Update contas set nome='" + txtNome.Text + "', descricao='" + txtDescricao.Text + "', valor='" + txtValor.Text + "', dataVencimento='" + Globals.DataNova + "' where idContas=" + txtIdContasReceber.Text + "";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Mostra();
        }
        private void cbRecebido_CheckedChanged(object sender, EventArgs e)
        {
            pegaData();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = Globals.conexao;
                    cnn.Open();
                    string sql = "Update contas set tipo='" + 1 + "' where idContas=" + txtIdContasReceber.Text + "";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Mostra();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir", "Confirmação", MessageBoxButtons.YesNo))
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = Globals.conexao;
                        cnn.Open();
                        string sql = "Delete from contas where idContas = '" + txtIdContasReceber.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Deletado com sucesso! ");
                    }
                    Limpa();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            Mostra();
        }
        void Mostra()
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = Globals.conexao;
                    cnn.Open();
                    string sql = "Select * from contas where tipo=0";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwContasReceber.DataSource = table;
                    dgwContasReceber.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void pegaData()
        {
            Globals.Data = dtpDataVencimento.Value;
            string dataCurta = Globals.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            Globals.DataNova = vetData[2] + "-" + vetData[1] + "-" + vetData[0];
        }
        void VerificaVazio()
        {
            if (txtNome.Text == "" || txtDescricao.Text == "" || txtValor.Text == "")
            {
                continua = "nao";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "sim";
            }
        }
        void Limpa()
        {
            txtIdContasReceber.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtValor.Clear();
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }
        private void dtpDataVencimento_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
