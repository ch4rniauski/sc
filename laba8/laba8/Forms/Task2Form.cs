using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba8.Forms
{
    public partial class Task2Form : Form
    {
        public Task2Form()
        {
            InitializeComponent();
            label2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainForm form = new MainForm();
            form.ShowDialog();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RemoveSpaces(textBox1.Text) == "")
            {
                ErrorWarning();
                textBox1.Clear();
            }

            else
            {
                button1.Hide();
                textBox1.Hide();

                RemoveABCBeforNumber(textBox1.Text);
            }
        }

        private void RemoveABCBeforNumber(string str)
        {
            string strLower = str.ToLower();

            for (int i = 0; i < str.Length; i++)
            {
                if (strLower[i] == 'a' && strLower[i + 1] == 'b' && strLower[i + 2] == 'c')
                    if ((int)strLower[i + 3] >= 48 && (int)strLower[i + 3] <= 57)
                        str = str.Remove(i, 3);
            }

            label1.Text = str;
        }

        private async void ErrorWarning()
        {
            textBox1.Clear();
            label2.Show();
            await Task.Delay(2000);
            label2.Hide();
        }

        private string RemoveSpaces(string str)
        {
            if (str.Contains(" "))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        str = str.Remove(i, 1);
                        i--;
                    }
                }
            }

            return str;
        }
    }
}
