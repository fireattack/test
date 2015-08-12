using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int b = 0;

        private void work()
        {
            b = 1;
            string a = "";
            Regex myre = new Regex(@"^(.+)\r\n(\[?.*\r?\n?)(\r\n)+(\S(.|\n)+\S)\s*");
            Regex myre2 = new Regex(@"\[(.+) (.+)]");
            // textBox1.Text = myre.Replace(textBox1.Text, "[color=blue]$1[/color]\r\n$2\r\n[quote]$4[/quote]");
            textBox2.Text = myre.Replace(textBox1.Text, "$1");
            a = myre.Replace(textBox1.Text, "$2");
            if (a != "")
            {
                textBox3.Text = myre2.Replace(a, "$1");
                textBox4.Text = myre2.Replace(a, "$2");
            }
            textBox1.Text = myre.Replace(textBox1.Text, "$4");
            //if (checkBox2.Checked)
            //{
            //    Clipboard.SetText(textBox1.Text);
            //}
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text = Clipboard.GetText();
            }
            work();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            textBox1.Width = Width - 32;
            textBox1.Height = Height - 119;
            button2.Top = Height - 98;
            button3.Top = Height - 98;
            button1.Top = Height - 98;
            checkBox1.Top = Height - 69;
            checkBox2.Top = Height - 69;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (b == 0)
            {
                work();
            }
        }


        private void selectall(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 1)
                ((TextBox)sender).SelectAll();

        }



    }
}