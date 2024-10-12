namespace laba11.Forms
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
            StartForm startForm = new StartForm();
            startForm.ShowDialog();
            this.Close();
        }
    }
}
