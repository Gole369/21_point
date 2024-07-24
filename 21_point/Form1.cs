using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace _21_point
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public string path_rules = AppDomain.CurrentDomain.BaseDirectory.ToString() + "game_rules.txt";
        public string path_rating = AppDomain.CurrentDomain.BaseDirectory.ToString() + "rating.txt";


        private void Form1_Load(object sender, EventArgs e)
        {
            update_table();
        }
        private void update_table()
        {
            listBox1.Items.Clear();
            using (StreamReader reader = new StreamReader(path_rating))
            {
                int num;
                for (int i = 0; i < 10; i++)
                {
                    num = Convert.ToInt32(reader.ReadLine());
                    listBox1.Items.Add(num);
                }
            }
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


        private async void button2_Click(object sender, EventArgs e)
        {

            using (StreamReader reader = new StreamReader(path_rules))
            {
                string text = await reader.ReadToEndAsync();
                MessageBox.Show(text);
                reader.ReadToEnd();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            update_table();
        }

    }
}
