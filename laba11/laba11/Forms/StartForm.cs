namespace laba11.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
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
