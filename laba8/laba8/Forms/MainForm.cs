using laba8.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
