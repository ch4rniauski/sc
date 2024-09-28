using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace laba10.Forms
{
    public partial class Task2Form : Form
    {
        public Task2Form()
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

            using (StreamReader textReader = new StreamReader("FileWithTextTask12.txt"))
            {
                List<string> lines = new List<string>();

                while (!textReader.EndOfStream)
                    lines.Add(textReader.ReadLine());

                for (int i = 0; i < lines.Count; i++)
                {
                    List<string> wordsFromLine = lines[i].Split(' ').ToList();
                    int suitableWords = 0;

                    foreach (string w in wordsFromLine)
                    {
                        if (w.Length >= 3 && w.Length <= 5)
                            suitableWords++;
                    }

                    if (suitableWords % 2 == 0)
                    {
                        for (int j = 0; j < wordsFromLine.Count; j++)
                        {
                            if (wordsFromLine[j].Length >= 3 && wordsFromLine[j].Length <= 5)
                            {
                                wordsFromLine.Remove(wordsFromLine[j]);
                                j--;
                            }
                        }

                        string tempLine = "";

                        foreach (string w in wordsFromLine)
                            tempLine += $"{w} ";

                        lines[i] = tempLine;
                    }
                }

                using (StreamWriter textWriter = new StreamWriter("FileWithEditedLinesTask12.txt"))
                {
                    foreach (string l in lines)
                        textWriter.WriteLine(l);
                }
            }

            label1.Text = "Готово\nПроверьте файл \"FileWithEditedLinesTask12.txt\"";
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = this.Height / 2 - 2 * label1.Height;
        }
    }
}
