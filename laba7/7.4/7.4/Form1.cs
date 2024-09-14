using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7._4
{
    public partial class Form1 : Form
    {
        double[,] array;
        byte button1ClickCounter = 0;
        byte arrayLines;
        byte arrayColums;
        byte arrayLinesCounter = 0;
        byte arrayColumsCounter = 0;
        public Form1()
        {
            InitializeComponent();
            label2.Hide();
        }

        private async void ErrorWarning()
        {
            label2.Show();
            await Task.Delay(2000);
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
                button1ClickCounter++;

                if (button1ClickCounter == 1)
                {
                    arrayLines = Convert.ToByte(textBox1.Text);
                    label1.Text = "Введите количество столбцов в данном массиве";
                    textBox1.Clear();
                }

                if (button1ClickCounter == 2)
                {
                    arrayColums = Convert.ToByte(textBox1.Text);
                    array = new double[arrayLines, arrayColums];
                    button1.Hide();
                    feelArray();
                }
            }

            else
                ErrorWarning();
        }

        private void feelArray()
        {
            textBox1.Clear();

            if (arrayColumsCounter == array.GetLength(1))
            {
                arrayLinesCounter++;
                arrayColumsCounter = 0;
            }

            if (arrayLinesCounter == array.GetLength(0))
            {
                button2.Hide();
                textBox1.Hide();
                label1.Text = "";
                FindMinElement();
            }

            else
                label1.Text = $"Введите значение {arrayColumsCounter + 1} элемента в {arrayLinesCounter + 1} строке: ";
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
                array[arrayLinesCounter, arrayColumsCounter] = Convert.ToDouble(textBox1.Text.Replace(',', '.'));
                arrayColumsCounter++;
                feelArray();
            }

            else
            {
                ErrorWarning();
                textBox1.Clear();
            }
        }

        private void FindMinElement()
        {
            double minElement = array[0, 0];
            byte iMinElement = 0;
            byte jMinElement = 0;

            for (byte i = 0; i < array.GetLength(0); i++)
            {
                for (byte j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < minElement)
                    {
                        minElement = array[i, j];
                        iMinElement = i;
                        jMinElement = j;
                    }
                }
            }

            label1.Text = $"Строка = {Convert.ToString(iMinElement + 1)}\nСтолбец = {Convert.ToString(jMinElement + 1)}";
        }
    }
}
