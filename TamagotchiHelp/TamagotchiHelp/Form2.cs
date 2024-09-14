using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TamagotchiHelp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            Program.f2 = this;
            InitializeComponent();
        }

        Stopwatch sWatch = new Stopwatch();
        bool btn1 = false;
        SaveFileDialog sfd = new SaveFileDialog();

        Котик Котик = new Котик();

        int eatCount = 0;
        int playCount = 0;
        int sleepCount = 0;

        List<String> lifeTimeOfKittys = new List<string>();

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Количество игр с котиком: " + playCount.ToString() + Environment.NewLine + "Количество приятных сновидений котика: " + sleepCount.ToString() + Environment.NewLine + "Количество кормежек котика: " + eatCount.ToString();
            if (Form1.flag == true)
            {
                timer1.Start();
                sWatch.Start();
                pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.всё_ок_2;
                Form1.flag = false;
            }
            else
            {
                timer1.Start();
                sWatch.Start();
                pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.всё_ок_1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = Котик.checkstate();
            progressBar3.Value = Котик.zСчастье();
            progressBar1.Value = Котик.zБодрость();
            progressBar2.Value = Котик.zСытость();

            if (label4.Text == "Грустный" && label4.Text != "Не смог(")
            {
                if (Form1.flag == true)
                {
                    pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.играть_2;
                    return;
                    Form1.flag = false;
                }
                else
                {
                    pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.играть_1;
                    return;
                }
            }
            if (label4.Text == "Голоден" && label4.Text != "Не смог(")
            {
                if (Form1.flag == true)
                {
                    pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.грустно_2;
                    return;
                    Form1.flag = false;
                }
                else
                {
                    pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.грустно_1;
                    return;
                }
            }
            if (label4.Text == "Сонный" && label4.Text != "Не смог(")
            {
                if (Form1.flag == true)
                {
                    pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.спать_2;
                    return;
                    Form1.flag = false;
                }
                else
                {
                    pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.спать_1;
                    return;
                }
            }
            if (label4.Text == "Не смог(")
            {
                button4.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = true;

                pictureBox1.BackgroundImage = TamagotchiHelp.Properties.Resources.типо_умер;

                sWatch.Stop();
                timer1.Stop();

                lifeTimeOfKittys.Add(
                    "Общее время игры " + sWatch.Elapsed.ToString() + " " +

                    "Количество игр с котёнком " + playCount.ToString() + " " +
                    "Количествоство сноведений  " + sleepCount.ToString() + " " +
                    "Количество кормежек любимчика " + eatCount.ToString() + " ");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e) //кормить
        {
            label4.Text = "Котик сыт";
            eatCount++;
            if (Котик.zСытость() < 300)
            {
                Котик.kormit();
                progressBar2.Value = Котик.zСытость();
            }
            textBox1.Text = "Количество игр с котиком: " + playCount.ToString() + Environment.NewLine + "Количество приятных сновидений котика: " + sleepCount.ToString() + Environment.NewLine + "Количество кормежек котика: " + eatCount.ToString();
        }

        private void button4_Click(object sender, EventArgs e) //играть
        {
            label4.Text = "Котик счастлив";
            playCount++;
            if (Котик.zСчастье() < 300)
            {
                Котик.igrat();
                progressBar3.Value = Котик.zСчастье();
            }
            textBox1.Text = "Количество игр с котиком: " + playCount.ToString() + Environment.NewLine + "Количество приятных сновидений котика: " + sleepCount.ToString() + Environment.NewLine + "Количество кормежек котика: " + eatCount.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //уложить спать
        {
            label4.Text = "Котик бодр";
            sleepCount++;
            if (Котик.zБодрость() < 300)
            {
                Котик.ulozhit();
                progressBar1.Value = Котик.zБодрость();
            }
            textBox1.Text = "Количество игр с котиком: " + playCount.ToString() + Environment.NewLine + "Количество приятных сновидений котика: " + sleepCount.ToString() + Environment.NewLine + "Количество кормежек котика: " + eatCount.ToString();
        }

        
        
        private void button1_Click(object sender, EventArgs e) //выйти + отчет
        {
            if (playCount == 0 && eatCount == 0 && sleepCount == 0)
            {
                this.Close();
            }
            else
            {
                DialogResult DR2 = MessageBox.Show("Хотите вывести отчет о жизни Вашего котика?", "Отчёт", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == DR2)
                {
                    btn1 = true;
                    SaveFileDialog saveFile1 = new SaveFileDialog();
                    saveFile1.DefaultExt = "*.txt";
                    saveFile1.Filter = "Text files|*.txt";
                    if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
                    {
                        using (StreamWriter sw = new StreamWriter(saveFile1.FileName, true))
                        {
                            sw.WriteLine(textBox1.Text);
                            sw.Close();
                            Application.Exit();
                            btn1 = true;
                        }
                    }
                    else
                    {
                        btn1 = true;
                        Application.Exit();
                    }
                }
                else Close();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            label5.Text = "Скорость времени " + trackBar1.Value.ToString() + "ms";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (playCount == 0 && eatCount == 0 && sleepCount == 0)
            {
                Application.Exit();
            }
            else
            {
                if (btn1 == true)
                {
                    Application.Exit();
                    btn1 = false;
                }
                else
                {
                    DialogResult DR2 = MessageBox.Show("Хотите вывести отчет о жизни Вашего котика?", "Отчёт", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == DR2)
                    {
                        button1_Click(sender, e);
                        Application.Exit();
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Text = "Котик воскрешен";
            Котик.voskresit();
            timer1.Start();
            sWatch.Start();
            button4.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = false;
            playCount = 0;
            eatCount = 0;
            sleepCount = 0;
            textBox1.Refresh();
        }
    }
}
