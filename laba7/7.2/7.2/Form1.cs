using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7._2
{
    public partial class Form1 : Form
    {
        private int feelArrayCounter = 0;
        private double[] array;
        public Form1()
        {
            InitializeComponent();
            label2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte errorCounter = 0;

            foreach (char ch in textBox1.Text)
            {
                if (ch != '0' && ch != '1' && ch != '2' && ch != '3' && ch != '4' && ch != '5' && ch != '6' && ch != '7' && ch != '8' && ch != '9' && ch != '0')
                {
                    errorCounter++;
                    textBox1.Clear();
                    break;
                }
            }

            if (errorCounter == 0 && textBox1.Text.Length > 0)
            {
                button1.Hide();
                array = new double[Convert.ToInt32(textBox1.Text)];
                feelArray();
            }

            else
                ErrorWarning();
        }

        private void feelArray()
        {
            label1.Text = $"Введите значение {feelArrayCounter + 1}-ого элемента массива";
            feelArrayCounter++;
            textBox1.Clear();

            if (feelArrayCounter == array.Length + 1)
            {
                button1.Hide();
                button2.Hide();
                textBox1.Hide();
                label1.Text = "";
                numbersOutput();
            }
        }

        private async void ErrorWarning()
        {
            label2.Show();
            await Task.Delay(2000);
            label2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte minusCounter = 0;
            byte dotCounter = 0;
            byte errorCounter = 0;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == '.' || textBox1.Text[i] == ',')
                    dotCounter++;
                if (textBox1.Text[i] == '-')
                    minusCounter++;
                if ((textBox1.Text[i] != '0' && textBox1.Text[i] != '1' && textBox1.Text[i] != '2' && textBox1.Text[i] != '3' && textBox1.Text[i] != '4' && textBox1.Text[i] != '5' && textBox1.Text[i] != '6' && textBox1.Text[i] != '7' && textBox1.Text[i] != '8' && textBox1.Text[i] != '9' && textBox1.Text[i] != '0' && textBox1.Text[i] != '.' && textBox1.Text[i] != ',' && textBox1.Text[i] != '-') || dotCounter > 1 || minusCounter > 1 || (textBox1.Text[i] == '-' && i > 0))
                {
                    errorCounter++;
                    textBox1.Clear();
                    break;
                }
            }

            if (errorCounter == 0 && textBox1.Text.Length > 0 && textBox1.Text != "." && textBox1.Text != ",")
            {
                array[feelArrayCounter - 1] = Convert.ToDouble(textBox1.Text.Replace(',', '.'));
                feelArray();
            }

            else
            {
                ErrorWarning();
                textBox1.Clear();
            }
        }

        private void numbersOutput()
        {
            foreach (double i in array)
            {
                if (i > 0)
                    label1.Text += i + " ";
            }

            foreach (int i in array)
            {
                if (i < 0)
                    label1.Text += i + " ";
            }
        }
    }
}
