using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TamagotchiHelp
{
    public partial class Form5 : Form

    {
        bool IsFirstClick = true;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            //if (label1.Text == "Наш котик остался один дома и ему очень грустно(")
            //{
            //    label1.Text == "Н";
            //}
            if (IsFirstClick) //IsFirstClick = true
            {
                label1.Text = "Как хорошо, что вышло новое приложение, с помощью которого можно удаленно следить за котиком!";
                // ваш код на первое нажатие
                IsFirstClick = false;
            }
            else // IsFirstClick = false
            {
                Form1 newForm = new Form1();
                newForm.Show();
                // ваш код на второе нажатие
                IsFirstClick = true;
                Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form1 newForm = new Form1();
            //newForm.Show();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
