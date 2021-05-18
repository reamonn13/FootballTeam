using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Coursuch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<FootballClub> FootballClubs = new List<FootballClub>();

        int OldRow, OldCol, Col, Row = -1;
        int OldRow3, OldCol3, Col3, Row3 = -1;

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            comboBox1.SelectedIndex = 0;
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            FootballClubs.Clear();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Users\\scouser\\SecondCourse\\OOP\\new";
            openFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Бинарный файл (*.bin)|*.bin";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FilterIndex == 1)
                {
                    listView3.Items.Clear();
                    listView1.Items.Clear();
                    String s;
                    String[] s1;
                    FileStream fr = new FileStream(openFileDialog1.FileName, FileMode.Open);
                    StreamReader sfr = new StreamReader(fr);
                    s = sfr.ReadLine();
                    int N;  //Количество команд
                    s1 = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        N = Convert.ToInt32(s1[0]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sfr.Close();
                        fr.Close();
                        return;
                    }

                    FootballClubs.Clear();
                    int[] CountPlayers = new int[N]; //Количество игроков в i-той команде
                    for (int i = 0; i < N; i++)
                    {

                        try
                        {

                            CountPlayers[i] = Convert.ToInt32(s1[i + 1]);
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sfr.Close();
                            fr.Close();
                            return;
                        }
                    }

                    string p1, p2, p3;
                    int p4, p5, p6, p7;
                    double p8;

                    string NameFootballClub;
                    string CountryFootballClub;
                    string StadionFootballClub;
                    int RatingFootballClub;

                    for (int i = 0; i < N; i++)
                    {
                        s = sfr.ReadLine();
                        s1 = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            NameFootballClub = Convert.ToString(s1[0]);
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sfr.Close();
                            fr.Close();
                            return;
                        }

                        try
                        {
                            CountryFootballClub = Convert.ToString(s1[1]);
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sfr.Close();
                            fr.Close();
                            return;
                        }

                        try
                        {
                            StadionFootballClub = Convert.ToString(s1[2]);
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sfr.Close();
                            fr.Close();
                            return;
                        }

                        try
                        {
                            RatingFootballClub = Convert.ToInt32(s1[3]);
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sfr.Close();
                            fr.Close();
                            return;
                        }

                        FootballClubs.Add(new FootballClub(NameFootballClub, CountryFootballClub, StadionFootballClub, RatingFootballClub, CountPlayers[i]));
                        for (int j = 0; j < CountPlayers[i]; j++)
                        {
                            s = sfr.ReadLine();
                            s1 = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            try
                            {
                                p1 = Convert.ToString(s1[0]);
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sfr.Close();
                                fr.Close();
                                return;
                            }

                            try
                            {
                                p2 = Convert.ToString(s1[1]);
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sfr.Close();
                                fr.Close();
                                return;
                            }

                            try
                            {
                                p3 = Convert.ToString(s1[2]);
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sfr.Close();
                                fr.Close();
                                return;
                            }

                            try
                            {
                                p4 = Convert.ToInt32(s1[3]);
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sfr.Close();
                                fr.Close();
                                return;
                            }

                            try
                            {
                                p5 = Convert.ToInt32(s1[4]);
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sfr.Close();
                                fr.Close();
                                return;
                            }

                            try
                            {
                                p6 = Convert.ToInt32(s1[5]);
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sfr.Close();
                                fr.Close();
                                return;
                            }

                            try
                            {
                                p7 = Convert.ToInt32(s1[6]);
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sfr.Close();
                                fr.Close();
                                return;
                            }

                            try
                            {
                                p8 = Convert.ToDouble(s1[7]);
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sfr.Close();
                                fr.Close();
                                return;
                            }

                            FootballClubs[i].Strikers.Add(new Striker(p1, p2, p3, p4, p5, p6, p7, p8));
                        }
                    }

                    sfr.Close();
                    fr.Close();
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (j == 0)
                            {
                                listView3.Items.Add(Convert.ToString(i + 1));
                            }

                            else
                            {
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].NameFC));
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].Country));
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].Stadion));
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].RatingUEFA));
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].CountPlayer));
                            }
                        }
                    }
                }

                else
                {
                    int N;
                    listView3.Items.Clear();
                    listView1.Items.Clear();

                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream fs2;
                    fs2 = new FileStream(openFileDialog1.FileName, FileMode.Open);
                    try
                    {
                        FootballClubs = (List<FootballClub>)formatter.Deserialize(fs2);
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка чтения файла!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    N = FootballClubs.Count;
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (j == 0)
                            {
                                listView3.Items.Add(Convert.ToString(i + 1));
                            }

                            else
                            {
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].NameFC));
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].Country));
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].Stadion));
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].RatingUEFA));
                                listView3.Items[i].SubItems.Add(Convert.ToString(FootballClubs[i].CountPlayer));
                            }
                        }
                    }
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView3.Items.Count == 0)
            {
                MessageBox.Show("Данные не введены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Бинарный файл (*.bin)|*.bin";

            for (int i = 0; i < FootballClubs.Count; i++)
            {
                if (FootballClubs[i].Strikers.Count == 0)
                {
                    MessageBox.Show("Сохранение данных пустой команды!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string FileName = saveFileDialog1.FileName;
                if (saveFileDialog1.FilterIndex == 1)
                {
                    string s = Convert.ToString(FootballClubs.Count) + " ";
                    for (int i = 0; i < FootballClubs.Count; i++)
                    {
                        s += Convert.ToInt32(FootballClubs[i].Strikers.Count) + " ";
                    }

                    using (StreamWriter sfw = new StreamWriter(FileName))
                    {
                        sfw.WriteLine((s)); // первая строка
                        for (int i = 0; i < FootballClubs.Count; i++)
                        {
                            s = FootballClubs[i].NameFC + " " + FootballClubs[i].Country + " " + FootballClubs[i].Stadion + " " + Convert.ToInt32(FootballClubs[i].RatingUEFA);
                            sfw.WriteLine(s);

                            for (int j = 0; j < FootballClubs[i].CountPlayer; j++)
                            {

                                s = Convert.ToString(FootballClubs[i].Strikers[j].Name) + " " + Convert.ToString(FootballClubs[i].Strikers[j].Nationality) + " " + Convert.ToString(FootballClubs[i].Strikers[j].Amplua) + " " + Convert.ToString(FootballClubs[i].Strikers[j].GameNumber) + " " + Convert.ToString(FootballClubs[i].Strikers[j].Games) + " " + Convert.ToString(FootballClubs[i].Strikers[j].Goals) + " " + Convert.ToString(FootballClubs[i].Strikers[j].Assists + " " + Convert.ToString(FootballClubs[i].Strikers[j].RateProdActPerGame));
                                sfw.WriteLine(s);
                            }
                        }
                    }

                }

                else
                {
                    if (saveFileDialog1.FilterIndex == 2)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        FileStream fs2;
                        fs2 = new FileStream(FileName, FileMode.Create);
                        formatter.Serialize(fs2, FootballClubs);
                        fs2.Close();
                    }
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.Yes)
                Application.Exit();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView3.Items.Count == 0)
            {
                MessageBox.Show("Данные не введены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Search quest = new Search();
            quest.Owner = this;
            quest.ShowDialog();
        }

        private string Normal(int k, int c)
        {
            string s = " (в норме)";
            string s1 = " (выше нормы)";
            string s2 = " (ниже нормы)";
            double plan = FootballClubs[Row3].Strikers[c].RateProdActPerGame;
            if (k > plan + 10)
                return s1;
            else if (k <= plan + 10 && k >= plan - 3)
                return s;
            else if (k < 45) return s2;
            return "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddClub add = new AddClub();
            add.Owner = this;
            add.ShowDialog();

            if (DataFootballClub.NameFC == "-999")
                return;
            int countList = listView3.Items.Count;
            int i = FootballClubs.Count;


            FootballClubs.Add(new FootballClub(DataFootballClub.NameFC, DataFootballClub.Country, DataFootballClub.Stadion, Convert.ToInt32(DataFootballClub.RatingUEFA), Convert.ToInt32(DataFootballClub.CountPlayer)));

            listView3.Items.Add(Convert.ToString(countList + 1));

            listView3.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[i].NameFC));
            listView3.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[i].Country));
            listView3.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[i].Stadion));
            listView3.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[i].RatingUEFA));
            listView3.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[i].CountPlayer));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listView3.Items.Count == 0)
                return;

            if (Row3 == -1)
            {
                MessageBox.Show("Сначала выберите запись!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FootballClubs.RemoveAt(Row3);
            listView3.Items[Row3].Remove();
            listView1.Items.Clear();
            listView2.Items.Clear();
            for (int i = Row3; i < listView3.Items.Count; i++)
            {
                listView3.Items[i].Text = Convert.ToString(i + 1);
            }

            label2.Text = "Список игроков: ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EditClub editclub = new EditClub();
            editclub.Owner = this;
            if (listView3.Items.Count == 0)
            {
                MessageBox.Show("Сначала добавьте команду!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataFootballClub.NameFC = listView3.Items[Row3].SubItems[1].Text;
            DataFootballClub.Country = listView3.Items[Row3].SubItems[2].Text;
            DataFootballClub.Stadion = listView3.Items[Row3].SubItems[3].Text;
            DataFootballClub.RatingUEFA = listView3.Items[Row3].SubItems[4].Text;
            editclub.ShowDialog();

            if (DataFootballClub.NameFC == "-999")
                return;

            listView3.Items[Row3].SubItems[1].Text = DataFootballClub.NameFC;
            listView3.Items[Row3].SubItems[2].Text = DataFootballClub.Country;
            listView3.Items[Row3].SubItems[3].Text = DataFootballClub.Stadion;
            listView3.Items[Row3].SubItems[4].Text = DataFootballClub.RatingUEFA;
            listView3.Items[Row3].SubItems[5].Text = Convert.ToString(FootballClubs[Row3].Strikers.Count);
            FootballClubs[Row3].NameFC = DataFootballClub.NameFC;
            FootballClubs[Row3].Country = DataFootballClub.Country;
            FootballClubs[Row3].Stadion = DataFootballClub.Stadion;
            FootballClubs[Row3].RatingUEFA = Convert.ToInt32(DataFootballClub.RatingUEFA);
            label2.Text = "Список игроков '" + FootballClubs[Row3].NameFC + "'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView3.Items.Count == 0)
            {
                MessageBox.Show("Сначала добавьте команду!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddPlayer addpl = new AddPlayer();
            addpl.Owner = this;
            addpl.ShowDialog();

            if (Data.Name == "-999")
                return;

            Random rand = new Random();
            double r = rand.NextDouble() * 5;
            FootballClubs[Row3].Strikers.Add(new Striker(Data.Name, Data.Nationality, Data.Amplua, Convert.ToInt32(Data.GameNumber), Convert.ToInt32(Data.Games), Convert.ToInt32(Data.Goals), Convert.ToInt32(Data.Assists), r));
            int countList = listView1.Items.Count;
            int i = FootballClubs[Row3].Strikers.Count - 1;
            listView1.Items.Add(Convert.ToString(countList + 1));
            listView1.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Name));
            listView1.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Nationality));
            listView1.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Amplua));
            listView1.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].GameNumber));
            listView1.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Games));
            listView1.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Goals));
            listView1.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Assists));
            listView1.Items[countList].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].RateProdActPerGame));
            FootballClubs[Row3].CountPlayer++;
            listView3.Items[Row3].SubItems[5].Text = Convert.ToString(FootballClubs[Row3].Strikers.Count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
                return;

            if (Row == -1)
            {
                MessageBox.Show("Сначала выберите запись!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FootballClubs[Row3].Strikers.RemoveAt(Row);
            listView1.Items[Row].Remove();
            for (int i = Row; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Text = Convert.ToString(i + 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditPlayer edit = new EditPlayer();
            edit.Owner = this;
            if (listView1.Items.Count == 0 || Row == -1)
                return;

            Data.Name = listView1.Items[Row].SubItems[1].Text;
            Data.Nationality = listView1.Items[Row].SubItems[2].Text;
            Data.Amplua = listView1.Items[Row].SubItems[3].Text;
            Data.GameNumber = listView1.Items[Row].SubItems[4].Text;
            Data.Games = listView1.Items[Row].SubItems[5].Text;
            Data.Goals = listView1.Items[Row].SubItems[6].Text;
            Data.Assists = listView1.Items[Row].SubItems[7].Text;
            Data.RateProdActPerGame = listView1.Items[Row].SubItems[8].Text;
            edit.ShowDialog();

            if (Data.Name == "-999")
                return;

            listView1.Items[Row].SubItems[1].Text = Data.Name;
            listView1.Items[Row].SubItems[2].Text = Data.Nationality;
            listView1.Items[Row].SubItems[3].Text = Data.Amplua;
            listView1.Items[Row].SubItems[4].Text = Data.GameNumber;
            listView1.Items[Row].SubItems[5].Text = Data.Games;
            listView1.Items[Row].SubItems[6].Text = Data.Goals;
            listView1.Items[Row].SubItems[7].Text = Data.Assists;
            listView1.Items[Row].SubItems[8].Text = Data.RateProdActPerGame;
            FootballClubs[Row3].Strikers[Row] = new Striker(Data.Name, Data.Nationality, Data.Amplua, Convert.ToInt32(Data.GameNumber), Convert.ToInt32(Data.Games), Convert.ToInt32(Data.Goals), Convert.ToInt32(Data.Assists), Convert.ToDouble(Data.RateProdActPerGame));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0 || listView3.Items.Count == 0)
                return;

            listView1.Items.Clear();

            if (comboBox1.SelectedIndex == 0)
            {
                if (radioButton2.Checked == true)
                    FootballClubs[Row3].Strikers.Sort((a, b) => a.Name.CompareTo(b.Name));
                else
                {
                    FootballClubs[Row3].Strikers.Sort((b, a) => a.Name.CompareTo(b.Name));
                }
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                if (radioButton2.Checked == true)
                    FootballClubs[Row3].Strikers.Sort((a, b) => a.Nationality.CompareTo(b.Nationality));
                else
                {
                    FootballClubs[Row3].Strikers.Sort((b, a) => a.Nationality.CompareTo(b.Nationality));
                }
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                if (radioButton2.Checked == true)
                    FootballClubs[Row3].Strikers.Sort((a, b) => a.Amplua.CompareTo(b.Amplua));
                else
                {
                    FootballClubs[Row3].Strikers.Sort((b, a) => a.Amplua.CompareTo(b.Amplua));
                }
            }

            else if (comboBox1.SelectedIndex == 3)
            {
                if (radioButton2.Checked == true)
                    FootballClubs[Row3].Strikers.Sort((a, b) => a.GameNumber.CompareTo(b.GameNumber));
                else
                {
                    FootballClubs[Row3].Strikers.Sort((b, a) => a.GameNumber.CompareTo(b.GameNumber));
                }
            }

            else if (comboBox1.SelectedIndex == 4)
            {
                if (radioButton2.Checked == true)
                    FootballClubs[Row3].Strikers.Sort((a, b) => a.Games.CompareTo(b.Games));
                else
                {
                    FootballClubs[Row3].Strikers.Sort((b, a) => a.Games.CompareTo(b.Games));
                }
            }

            else if (comboBox1.SelectedIndex == 5)
            {
                if (radioButton2.Checked == true)
                    FootballClubs[Row3].Strikers.Sort((a, b) => a.Goals.CompareTo(b.Goals));
                else
                {
                    FootballClubs[Row3].Strikers.Sort((b, a) => a.Goals.CompareTo(b.Goals));
                }
            }

            else if (comboBox1.SelectedIndex == 6)
            {
                if (radioButton2.Checked == true)
                    FootballClubs[Row3].Strikers.Sort((a, b) => a.Assists.CompareTo(b.Assists));
                else
                {
                    FootballClubs[Row3].Strikers.Sort((b, a) => a.Assists.CompareTo(b.Assists));
                }
            }

            else
                return;

            int N = FootballClubs[Row3].Strikers.Count;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0)
                        listView1.Items.Add(Convert.ToString(i + 1));
                    else
                    {
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Name));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Nationality));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Amplua));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].GameNumber));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Games));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Goals));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Assists));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].RateProdActPerGame));
                    }
                }
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.Items.Count == 0 || OldRow3 > listView3.Items.Count - 1)
                return;

            int k;
            if (listView3.SelectedItems.Count > 0)
            {
                k = listView3.FocusedItem.Index;

                if (OldRow3 >= 0 && OldCol3 > 0 && OldRow3 < listView3.Items.Count)
                {
                    listView3.Items[OldRow3].SubItems[OldCol3].BackColor = Color.FromArgb(255, 255, 255);
                    listView3.Items[OldRow3].SubItems[OldCol3].ForeColor = Color.FromArgb(0, 0, 0);
                }

                OldRow3 = Row3;
                OldCol3 = Col3;
                Row3 = k;
                Col3 = 0;
                Row = -1;
                OldRow = -1;
            }
        }

        private void listView3_MouseUp(object sender, MouseEventArgs e)
        {
            //По координатам мыши определяет строку и столбец
            if (listView3.Items.Count == 0)
                return;

            ListViewHitTestInfo ht = listView3.HitTest(e.X, e.Y);
            if (ht.Item == null) return;
            Row3 = ht.Item.Index;

            Col3 = ht.Item.SubItems.IndexOf(ht.SubItem);


            listView1.Items.Clear();
            //Вывод игроков команды
            if (FootballClubs[Row3].Strikers.Count == 0)
                return;

            for (int i = 0; i < FootballClubs[Row3].Strikers.Count; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0)
                        listView1.Items.Add(Convert.ToString(i + 1));
                    else
                    {
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Name));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Nationality));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Amplua));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].GameNumber));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Games));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Goals));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].Assists));
                        listView1.Items[i].SubItems.Add(Convert.ToString(FootballClubs[Row3].Strikers[i].RateProdActPerGame));
                    }
                }

            if (Col3 > 0)
            {
                listView3.Items[Row3].SubItems[Col3].BackColor = Color.FromArgb(0, 150, 255);
                listView3.Items[Row3].SubItems[Col3].ForeColor = Color.FromArgb(255, 255, 255);
            }
            if (OldRow3 >= 0 && OldCol3 > 0 && OldRow3 < listView3.Items.Count)
            {
                listView3.Items[OldRow3].SubItems[OldCol3].BackColor = Color.FromArgb(255, 255, 255);
                listView3.Items[OldRow3].SubItems[OldCol3].ForeColor = Color.FromArgb(0, 0, 0);
            }
            OldRow3 = Row3;
            OldCol3 = Col3;
            Row = -1;
            OldRow = -1;
            label2.Text = "Список игроков команды " + "'" + FootballClubs[Row3].NameFC + "'";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.Items.Count == 0)
                return;

            if (listView1.Items.Count == 0)
                return;

            int k;
            if (listView1.SelectedItems.Count > 0)
            {
                k = listView1.FocusedItem.Index;
                if (OldRow >= 0 && OldCol > 0)
                {
                    listView1.Items[OldRow].SubItems[OldCol].BackColor = Color.FromArgb(255, 255, 255);
                    listView1.Items[OldRow].SubItems[OldCol].ForeColor = Color.FromArgb(0, 0, 0);
                }

                OldRow = Row;
                OldCol = Col;
                Row = k;
                Col = 0;
            }
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            //По координатам мыши определяет строку и столбец
            if (listView3.Items.Count == 0)
                return;

            if (listView1.Items.Count == 0)
                return;

            ListViewHitTestInfo ht = listView1.HitTest(e.X, e.Y);
            if (ht.Item == null) return;
            Row = ht.Item.Index;

            Col = ht.Item.SubItems.IndexOf(ht.SubItem);
            listView1.Items[Row].UseItemStyleForSubItems = false;

            listView2.Items.Clear();

            listView2.Items.Add(FootballClubs[Row3].Strikers[Row].quantityPerDay[0].Value + " :   " + Convert.ToString(FootballClubs[Row3].Strikers[Row].quantityPerDay[0].Key) + Normal(FootballClubs[Row3].Strikers[Row].quantityPerDay[0].Key, Row));
            listView2.Items.Add(FootballClubs[Row3].Strikers[Row].quantityPerDay[1].Value + " :   " + Convert.ToString(FootballClubs[Row3].Strikers[Row].quantityPerDay[1].Key) + Normal(FootballClubs[Row3].Strikers[Row].quantityPerDay[1].Key, Row));
            listView2.Items.Add(FootballClubs[Row3].Strikers[Row].quantityPerDay[2].Value + " :   " + Convert.ToString(FootballClubs[Row3].Strikers[Row].quantityPerDay[2].Key) + Normal(FootballClubs[Row3].Strikers[Row].quantityPerDay[2].Key, Row));
            listView2.Items.Add(FootballClubs[Row3].Strikers[Row].quantityPerDay[3].Value + " :   " + Convert.ToString(FootballClubs[Row3].Strikers[Row].quantityPerDay[3].Key) + Normal(FootballClubs[Row3].Strikers[Row].quantityPerDay[3].Key, Row));
            listView2.Items.Add(FootballClubs[Row3].Strikers[Row].quantityPerDay[4].Value + " :   " + Convert.ToString(FootballClubs[Row3].Strikers[Row].quantityPerDay[4].Key) + Normal(FootballClubs[Row3].Strikers[Row].quantityPerDay[4].Key, Row));

            if (Col > 0)
            {
                listView1.Items[Row].SubItems[Col].BackColor = Color.FromArgb(0, 150, 255);
                listView1.Items[Row].SubItems[Col].ForeColor = Color.FromArgb(255, 255, 255);
            }
            if (OldRow >= 0 && OldCol > 0)
            {
                listView1.Items[OldRow].SubItems[OldCol].BackColor = Color.FromArgb(255, 255, 255);
                listView1.Items[OldRow].SubItems[OldCol].ForeColor = Color.FromArgb(0, 0, 0);
            }
            OldRow = Row;
            OldCol = Col;
        }
    }
}
