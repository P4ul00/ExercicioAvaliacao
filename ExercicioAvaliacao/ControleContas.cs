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
    public partial class ControleContas : Form
    {
        public ControleContas()
        {
            InitializeComponent();
        }
        private void btnContasPagar_Click(object sender, EventArgs e)
        {
            ContasPagar contasPagar=new ContasPagar();  
            contasPagar.Show(); 
        }
        private void btnContasReceber_Click(object sender, EventArgs e)
        {
            ContasReceber contasreceber=new ContasReceber();
            contasreceber.Show();   
        }
        private void ControleContas_Load(object sender, EventArgs e)
        {

        }
    }
}
