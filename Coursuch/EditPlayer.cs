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
    public partial class EditPlayer : Form
    {
        public EditPlayer()
        {
            InitializeComponent();
        }

        private void TB_rezInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void TB_rez_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                Data.Name = "-999";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Data.Name = textBox1.Text;
            Data.Nationality = textBox2.Text;
            Data.Amplua = textBox3.Text;
            Data.GameNumber = textBox4.Text;
            Data.Games = textBox5.Text;
            Data.Goals = textBox6.Text;
            Data.Assists = textBox7.Text;
            Data.RateProdActPerGame = textBox8.Text;
            this.Close();
        }

        private void EditPlayer_Load(object sender, EventArgs e)
        {
            textBox1.Text = Data.Name;
            textBox2.Text = Data.Nationality;
            textBox3.Text = Data.Amplua;
            textBox4.Text = Data.GameNumber;
            textBox5.Text = Data.Games;
            textBox6.Text = Data.Goals;
            textBox7.Text = Data.Assists;
            textBox8.Text = Data.RateProdActPerGame;
        }
    }
}
