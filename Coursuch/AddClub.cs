using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursuch
{
    public partial class AddClub : Form
    {
        public AddClub()
        {
            InitializeComponent();
        }

        private void TB_rezInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                Data.Name = "-999";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataFootballClub.NameFC = textBox1.Text;
            DataFootballClub.Country = textBox2.Text;
            DataFootballClub.Stadion = textBox3.Text;
            DataFootballClub.RatingUEFA = textBox4.Text;
            DataFootballClub.CountPlayer = "0";
            this.Close();
        }
    }
}
