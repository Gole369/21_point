namespace _21_point
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
            /*
                using (StreamWriter sw = new StreamWriter("data.txt", true))
                {
                    await sw.WriteLineAsync("1000");
            }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
