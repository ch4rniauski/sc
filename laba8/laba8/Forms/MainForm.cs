using laba8.Forms;
using System;
using System.Windows.Forms;

namespace laba8
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Task1Form task1 = new Task1Form();
            task1.ShowDialog();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Task2Form task2 = new Task2Form();
            task2.ShowDialog();

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Task4Form task4 = new Task4Form();
            task4.ShowDialog();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Task3Form task3 = new Task3Form();
            task3.ShowDialog();

            this.Close();
        }
    }
}
