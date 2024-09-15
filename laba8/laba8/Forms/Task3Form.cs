using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba8.Forms
{
    public partial class Task3Form : Form
    {
        public Task3Form()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;

            if (str.Contains(" ") || IsNumber(ref str))
            {
                ErrorWarning();
                textBox1.Clear();
            }

            else
            {
                button1.Hide();
                textBox1.Hide();
                label1.Text = "";

                ConvertToRomanNumeralSystem(str);
            }
        }

        private void ConvertToRomanNumeralSystem(string str)
        {
            double number = Convert.ToDouble(str);

            while (number >= 1000)
            {
                number -= 1000;
                label1.Text += "M";
            }

            while (number >= 500)
            {
                number -= 500;
                label1.Text += "D";
            }

            while (number >= 100)
            {
                number -= 100;
                label1.Text += "C";
            }

            while (number >= 50)
            {
                number -= 50;
                label1.Text += "L";
            }

            while (number >= 10)
            {
                number -= 10;
                label1.Text += "X";
            }

            while (number >= 5)
            {
                number -= 5;
                label1.Text += "V";
            }

            while (number >= 1)
            {
                number -= 1;
                label1.Text += "I";
            }

            if (number != 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '.')
                        str = str.Remove(0, i + 1);
                }

                label1.Text += ".";

                ConvertToRomanNumeralSystem(str);
            }
        }

        private bool IsNumber(ref string str)
        {
            byte dotCounter = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (((int)str[i] < 48 || (int)str[i] > 57) && (str[i] != ',' && str[i] != '.'))
                    return true;

                if (str[i] == '.' || str[i] == ',')
                {
                    dotCounter++;

                    if (dotCounter > 1)
                        return true;

                    if (str[i] == ',')
                        str = str.Replace(',', '.');
                }
            }

            return false;
        }
    }
}
