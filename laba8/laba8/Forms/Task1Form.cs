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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba8
{
    public partial class Task1Form : Form
    {
        public Task1Form()
        {
            InitializeComponent();
            label2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            textBox1.Hide();

            if (textBox1.Text.Length > 5)
            {
                label1.Text = "";
                label1.Text += $"Первые 3 символа: {textBox1.Text[0]}{textBox1.Text[1]}{textBox1.Text[2]}\n";
                label1.Text += $"Последние 3 символа: {textBox1.Text[textBox1.Text.Length - 3]}{textBox1.Text[textBox1.Text.Length - 2]}{textBox1.Text[textBox1.Text.Length - 1]}";
            }

            else
            {
                label1.Text = "";

                for (int i = 0; i < textBox1.Text.Length; i++)
                    label1.Text += textBox1.Text[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form = new MainForm();
            form.ShowDialog();
            this.Close();
        }

        //private async void ErrorWarning()
        //{
        //    textBox1.Clear();
        //    label2.Show();
        //    await Task.Delay(2000);
        //    label2.Hide();
        //}

        //private string RemoveSpaces(string str)
        //{
        //    if (str.Contains(" "))
        //    {
        //        for (int i = 0; i < str.Length; i++)
        //        {
        //            if (str[i] == ' ')
        //            {
        //                str = str.Remove(i, 1);
        //                i--;
        //            }
        //        }
        //    }

        //    return str;
        //}
    }
}
