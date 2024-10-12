namespace laba11.Forms
{
    public partial class Task1Form : Form
    {
        private OperatorNode? _operatorsStack = null;
        private OperandsNode? _operandsStack = null;
        private string? _str;

        public Task1Form()
        {
            InitializeComponent();
            label2.Hide();
            label3.Hide();
            label4.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm startForm = new StartForm();
            startForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RemoveSpaces(textBox1.Text) == "")
                ErrorWarning();
            else
            {
                _str = textBox1.Text;
                button2.Hide();
                textBox1.Hide();
                label1.Text = $"Изначальное выражение: {textBox1.Text}";
                _str = RemoveSpaces(_str);
                _str = StringTransformation(_str);
                label1.Text += $"\n{_str}";
                label3.Show();
                label4.Show();
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
            if (str.Contains(' '))
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

        private string StringTransformation(string str)
        {
            if (str.Contains('('))
            {
                string tempStrWithout2Brackets = "";
                string tempStrWithAllBrackets = "";
                byte bracketsCounter = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '(')
                    {
                        bracketsCounter++;

                        if (bracketsCounter == 1)
                        {
                            tempStrWithAllBrackets += str[i];
                            continue;
                        }
                    }

                    else if (str[i] == ')')
                    {
                        tempStrWithAllBrackets += str[i];
                        bracketsCounter--;

                        if (bracketsCounter == 0)
                        {
                            str = str.Replace(tempStrWithAllBrackets, StringTransformation(tempStrWithout2Brackets));

                            if (str.Contains('('))
                                str = StringTransformation(str);
                            else
                                break;
                        }
                    }

                    if (bracketsCounter > 0)
                    {
                        tempStrWithout2Brackets += str[i];

                        if (str[i] != ')')
                            tempStrWithAllBrackets += str[i];
                    }
                }
            }

            if (str.Contains('*') || str.Contains('/'))
            {
                for (int i = 1; i < str.Length; i++)
                {
                    if (str[i] == '*' || str[i] == '/')
                    {
                        int j = i - 1;
                        int k = i + 1;

                        string firstNumber = "";
                        string secondNumber = "";
                        char sign = str[i];

                        for (; j > -1; j--)
                        {
                            if ((((int)str[j] < 48 || (int)str[j] > 57) && str[j] != '-') || j == 0)
                            {
                                if (j > 0)
                                    j++;

                                for (; j < i; j++)
                                    firstNumber += str[j];

                                break;
                            }
                        }

                        for (; k < str.Length; k++)
                        {
                            if ((((int)str[k] < 48 || (int)str[k] > 57) && k != i + 1) || k == str.Length - 1)
                            {
                                if (k < str.Length - 1)
                                    k--;

                                for (int y = i + 1; y < k + 1; y++)
                                    secondNumber += str[y];

                                break;
                            }
                        }

                        str = str.Replace(firstNumber + sign + secondNumber, SolveExample(firstNumber, secondNumber, sign));

                        if (str.Contains('*') || str.Contains('/'))
                        {
                            i = 0;
                            continue;
                        }

                        else
                            break;
                    }
                }
            }

            if ((str.Contains('+') || str.Contains('-')) && str[0] != '-')
            {
                for (int i = 1; i < str.Length; i++)
                {
                    if (str[i] == '+' || str[i] == '-')
                    {
                        int j = i - 1;
                        int k = i + 1;

                        string firstNumber = "";
                        string secondNumber = "";
                        char sign = str[i];

                        for (; j > -1; j--)
                        {
                            if (((int)str[j] < 48 || (int)str[j] > 57 || j == 0) && str[j] != '-')
                            {
                                if (j > 0)
                                    j++;

                                for (; j < i; j++)
                                    firstNumber += str[j];

                                break;
                            }
                        }

                        for (; k < str.Length; k++)
                        {
                            if ((int)str[k] < 48 || (int)str[k] > 57 || k == str.Length - 1)
                            {
                                if (k < str.Length - 1)
                                    k--;

                                for (int y = i + 1; y < k + 1; y++)
                                    secondNumber += str[y];

                                break;
                            }
                        }

                        str = str.Replace(firstNumber + sign + secondNumber, SolveExample(firstNumber, secondNumber, sign));

                        if ((str.Contains('+') || str.Contains('-')) && (str[0] != '-'))
                        {
                            i = 0;
                            continue;
                        }

                        else
                            break;
                    }
                }
            }
            return str;
        }

        private string SolveExample(string firstNumber, string secondNumber, char sign)
        {
            if (sign == '+')
            {
                _operandsStack = new(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber), _operandsStack);
                _operatorsStack = new(sign, _operatorsStack);
                ChangeLables();
                return Convert.ToString(Convert.ToInt32(firstNumber) + Convert.ToInt32(secondNumber));
            }
            else if (sign == '-')
            {
                _operandsStack = new(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber), _operandsStack);
                _operatorsStack = new(sign, _operatorsStack);
                ChangeLables();
                return Convert.ToString(Convert.ToInt32(firstNumber) - Convert.ToInt32(secondNumber));
            }
            else if (sign == '*')
            {
                _operandsStack = new(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber), _operandsStack);
                _operatorsStack = new(sign, _operatorsStack);
                ChangeLables();
                return Convert.ToString(Convert.ToInt32(firstNumber) * Convert.ToInt32(secondNumber));
            }
            else
            {
                _operandsStack = new(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber), _operandsStack);
                _operatorsStack = new(sign, _operatorsStack);
                ChangeLables();
                return Convert.ToString(Convert.ToInt32(firstNumber) / Convert.ToInt32(secondNumber));
            }
        }

        private void ChangeLables()
        {
            OperatorNode? tempOperatorsStack = _operatorsStack;
            OperandsNode? tempOperandsStack = _operandsStack;

            label3.Text = "Операнды:";
            while (tempOperandsStack != null)
            {
                label3.Text += $"\n{tempOperandsStack.Operands[0]}, {tempOperandsStack.Operands[1]}";
                tempOperandsStack = tempOperandsStack.Next;
            }

            label4.Text = "Операторы:";
            while (tempOperatorsStack != null)
            {
                label4.Text += $"\n{tempOperatorsStack.Operator}";
                tempOperatorsStack = tempOperatorsStack.Next;
            }
        }

        private class OperatorNode
        {
            public char Operator {  get; set; }
            public OperatorNode? Next { get; set; }

            public OperatorNode(char oparator, OperatorNode? prevOperator)
            {
                Operator = oparator;
                Next = prevOperator;
            }
        }

        private class OperandsNode
        {
            public int[] Operands = new int[2];
            public OperandsNode? Next { get; set; }

            public OperandsNode(int firstNumber, int secondNumber, OperandsNode? prevOperand)
            {
                Operands[0] = firstNumber;
                Operands[1] = secondNumber;
                Next = prevOperand;
            }
        }
    }
}
