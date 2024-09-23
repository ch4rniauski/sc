using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Hide();
        }

        private int _i = 0;
        private PRICE[] SPISOK = new PRICE[8];

        private struct PRICE
        {
            public string TOVAR { get; set; }
            public string MAG { get; set; }
            public decimal STOIM { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RemoveSpaces(textBox1.Text) == "")
                ErrorWarning();

            else
            {
                if (label1.Text.Contains("Введите название товара"))
                {
                    SPISOK[_i].TOVAR = textBox1.Text;

                    label1.Text = "Введите название магазина, в котором продается товар";
                    label1.Left = 211;

                    textBox1.Clear();
                }

                else if (label1.Text.Contains("Введите название магазина, в котором продается товар"))
                {
                    SPISOK[_i].MAG = textBox1.Text;

                    label1.Text = "Введите стоимость товара в руб.";
                    label1.Left = 290;

                    textBox1.Clear();
                }

                else if (label1.Text.Contains("Введите стоимость товара в руб."))
                {
                    string strNumber = textBox1.Text;

                    if (IsNumber(ref strNumber))
                    {
                        SPISOK[_i].STOIM = Convert.ToDecimal(strNumber);

                        if (_i == 7)
                        {
                            label3.Hide();
                            button1.Hide();
                            textBox1.Clear();
                            label1.Text = "Введите название товара, информацию о котором хотите найти";
                            label1.Left = 187;
                        }

                        else
                        {
                            _i++;

                            label1.Text = "Введите название товара";
                            label1.Left = 312;

                            label3.Text = $"Для {_i + 1}-го товара";

                            textBox1.Clear();
                        }
                    }

                    else
                        ErrorWarning();
                }
            }
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

        private bool IsNumber(ref string str)
        {
            byte dotCounter = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (((int)str[i] < 48 || (int)str[i] > 57) && (str[i] != ',' && str[i] != '.'))
                    return false;

                if (str[i] == '.' || str[i] == ',')
                {
                    dotCounter++;

                    if (dotCounter > 1)
                        return false;

                    if (str[i] == '.')
                        str = str.Replace('.', ',');
                }
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Продолжить")
            {
                label1.Text = "Введите название товара, информацию о котором хотите найти";
                label1.Top = 135;
                label1.Left = 187;

                textBox1.Clear();
                textBox1.Show();

                button2.Text = "Ввести";
                
            }

            else
            {
                if (RemoveSpaces(textBox1.Text) == "")
                    ErrorWarning();

                else
                {
                    string productName = textBox1.Text;
                    byte coincidences = 0;

                    label1.Text = "";

                    foreach (PRICE item in SPISOK)
                    {
                        if (item.TOVAR == productName)
                        {
                            coincidences++;

                            if (coincidences > 1)
                                label1.Text += "\n";

                            label1.Text += $"Название товара: {item.TOVAR}\n";
                            label1.Text += $"Название магазина, в котором продается товар: {item.MAG}\n";
                            label1.Text += $"стоимость товара в руб.: {item.STOIM}\n";
                        }
                    }

                    button2.Text = "Продолжить";
                    textBox1.Hide();

                    if (coincidences == 0)
                        label1.Text = "Товара с данным названием не найдено\n";

                    label1.Left = (this.Width - label1.Width) / 2;
                    label1.Top = (this.Height - label1.Height) / 2;
                }
            }
        }
    }
}
