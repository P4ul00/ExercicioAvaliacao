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
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
            Mostra();          
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }
        string continua = "sim";
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
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        MessageBox.Show("Inserido com sucesso!");
                        string sql = "insert into agenda (titulo, hora, data,descricao) values ('"+ txtTitulo.Text + "','" + cmbHora.Text + "','" + Globals.DataNova + "','" + rtbDescricao.Text + "')";
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

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir", "Confirmação", MessageBoxButtons.YesNo))
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "Delete from agenda where idAgenda = '" + txtIdAgenda.Text + "'";
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
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            pegaData();   
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = Globals.conexao;
                    cnn.Open();
                    string sql = "Update agenda set titulo='" + txtTitulo.Text + "', hora='" + cmbHora.Text + "',data='" + Globals.DataNova + "', descricao='" + rtbDescricao.Text + "' where idAgenda='" + txtIdAgenda.Text + "'";
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
        void pegaData()
        {
            Globals.Data = dtpData.Value;
            string dataCurta = Globals.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
           Globals.DataNova = vetData[2] + "-" + vetData[1] + "-" + vetData[0];
        }   
        void Mostra()
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                    cnn.Open();
                    string sql = "Select * from agenda";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwAgenda.DataSource = table;
                    dgwAgenda.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void VerificaVazio()
        {
            if (txtTitulo.Text == "" || rtbDescricao.Text == "")
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
            txtIdAgenda.Text = "";
            txtTitulo.Clear();
            rtbDescricao.Text = "";
            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }
        private void dgwAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwAgenda.CurrentRow.Index != -1)
            {
                txtIdAgenda.Text = dgwAgenda.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgwAgenda.CurrentRow.Cells[1].Value.ToString();
                cmbHora.Text = dgwAgenda.CurrentRow.Cells[2].Value.ToString();
                dtpData.Value = Convert.ToDateTime(dgwAgenda.CurrentRow.Cells[3].Value.ToString());
                rtbDescricao.Text = dgwAgenda.CurrentRow.Cells[4].Value.ToString();
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "Novo";
            }
        }
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                    cnn.Open();
                    string sql;
                    sql = "Select * from agenda where titulo Like'" + txtPesquisar.Text + "%'";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwAgenda.DataSource = table;
                    dgwAgenda.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }   
    }
}
