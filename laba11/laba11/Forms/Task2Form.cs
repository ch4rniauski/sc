namespace laba11.Forms
{
    public partial class Task2Form : Form
    {
        private Node? _list = null;

        public Task2Form()
        {
            InitializeComponent();
            label2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm startForm = new StartForm();
            startForm.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (RemoveSpaces(textBox1.Text) == " ")
                ErrorWarning();
            else
            {
                _list = new(textBox1.Text[0]);
                _list.Next = _list;

                for (int i = 1; i < textBox1.Text.Length; i++)
                    FeelList(textBox1.Text[i], i);

                button2.Hide();
                textBox1.Hide();
                
                ReverseCircularList();

                label1.Text = $"Изначальная строка: {textBox1.Text}";
                label1.Text += "\nПеревернутая строка: ";

                while (_list != null)
                {
                    label1.Text += _list.Element;
                    _list = _list.Next;
                }
            }
        }

        private void FeelList(char element, int i)
        {
            for (; i > 1; i--)
                _list = _list!.Next;

            _list!.Next = new(element, _list.Next);

            _list = _list.Next.Next;
        }

        private void ReverseCircularList()
        {
            Node? current = _list;
            Node? previous = null;
            Node? originalList = _list;

            while (current.Next != originalList)
            {
                Node next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            current.Next = previous;
            _list = current;
        }

        private class Node
        {
            public char Element { get; set; }
            public Node? Next { get; set; }

            public Node(char element, Node? next = null)
            {
                Element = element;
                Next = next;
            }
        }
    }
}
