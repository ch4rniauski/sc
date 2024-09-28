using System;
using System.IO;
using System.Windows.Forms;

namespace laba10.Forms
{
    public partial class Task1Form : Form
    {
        public Task1Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();

            using (StreamReader textReader = new StreamReader("FileWithTextTask9.txt"))
            {
                string text = textReader.ReadToEnd();
                int lines = 1;

                for (; lines <= text.Length / lines; lines++) { }
                lines--;

                int colums = (text.Length + lines - 1) / lines;
                char[,] encriptionMatrix = new char[lines, colums];
                int numberOfCharOnText = 0;

                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < colums; j++)
                    {
                        encriptionMatrix[i, j] = text[numberOfCharOnText];

                        if (text.Length <= numberOfCharOnText + 1)
                            break;

                        numberOfCharOnText++;
                    }

                    if (text.Length <= numberOfCharOnText + 1)
                        break;
                }

                using (StreamWriter textWriter = new StreamWriter("encriptionMatrix.txt"))
                {
                    for (int j = 0; j < colums; j++)
                    {
                        for (int i = 0; i < lines; i++)
                        {
                            if (encriptionMatrix[i, j] == '\0')
                                break;

                            textWriter.Write($"{encriptionMatrix[i, j]} ");
                        }

                        textWriter.Write('\n');
                    }
                }

                label1.Text = "Готово\nПроверьте файл \"encriptionMatrix.txt\"";

                label1.Left = (this.Width - label1.Width) / 2;
                label1.Top = this.Height / 2 - 2 * label1.Height;
            }
        }
    }
}
