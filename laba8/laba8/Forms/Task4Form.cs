using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba8.Forms
{
    public partial class Task4Form : Form
    {
        private int _i = 0;
        private int _numberofWords;
        private string[] _wordsToCheck;
        public Task4Form()
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
            if (IsNumber(textBox1.Text))
                ErrorWarning();

            else
            {
                button1.Hide();

                _numberofWords = Convert.ToInt32(textBox1.Text);
                _wordsToCheck = new string[_numberofWords];

                textBox1.Clear();
                label1.Text = "Введите 1 слово";
            }
        }

        private bool IsNumber(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if ((int)str[i] < 48 || (int)str[i] > 57)
                    return true;
            }

            return false;
        }

        private async void ErrorWarning()
        {
            textBox1.Clear();
            label2.Show();
            await Task.Delay(2000);
            label2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text.Contains(" "))
                ErrorWarning();

            else
            {
                _wordsToCheck[_i] = textBox1.Text;

                if (_i == _numberofWords - 1)
                {
                    button3.Hide();
                    label1.Text = "Введите текст";
                }

                else
                {
                    _i++;
                    label1.Text = $"Введите {_i + 1} слово";
                }

                textBox1.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                ErrorWarning();

            else
            {
                string text = textBox1.Text;
                string[] textSplit = text.Split(' ');

                label1.Text = $"Изначальынй текст: \"{text}\"\n";

                textBox1.Hide();
                button4.Hide();
                FindDifferences(ref textSplit);

                label1.Text += $"Список слов: ";

                for (int i = 0; i < _wordsToCheck.Length; i++)
                    label1.Text += $"{_wordsToCheck[i]}";

                label1.Text += $"\nИзмененный текст: ";

                for (int i = 0; i < textSplit.Length; i++)
                    label1.Text += $"{textSplit[i]} ";
            }
        }

        private void FindDifferences(ref string[] textSplit)
        {
            for (int i = 0; i < textSplit.Length; i++)
            {
                for (int j = 0; j < _wordsToCheck.Length; j++)
                {
                    if (textSplit[i].Length == _wordsToCheck[j].Length || textSplit[i].Length == _wordsToCheck[j].Length + 1 || textSplit[i].Length == _wordsToCheck[j].Length - 1)
                    {
                        byte differences = 0;

                        for  (int k = 0; k < (textSplit[i].Length + _wordsToCheck[j].Length) / 2; k++)
                        {
                            if (textSplit[i].ToLower()[k] != _wordsToCheck[j].ToLower()[k])
                                differences++;

                            if (differences > 1)
                                break;
                        }

                        if (differences == 0 && (textSplit[i].Length == _wordsToCheck[j].Length + 1 || textSplit[i].Length == _wordsToCheck[j].Length - 1))
                            textSplit[i] = _wordsToCheck[j];

                        else if (differences == 1 && textSplit[i].Length == _wordsToCheck[j].Length)
                            textSplit[i] = _wordsToCheck[j];
                    }
                }
            }
        }
    }
}
