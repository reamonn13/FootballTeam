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
    public partial class AddPlayer : Form
    {
        public AddPlayer()
        {
            InitializeComponent();
        }

        private void AddPlayer_Closed(object sender, EventArgs e)
        {
            Data.isEdited = false;
        }

        private void TB_rezInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                Data.Name = "-999";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
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
            this.Close();
        }
    }
}
