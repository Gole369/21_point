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
        public string path_theme = AppDomain.CurrentDomain.BaseDirectory.ToString() + "theme.txt";

        public bool theme = false;

        private void theme_read()
        {
            using (StreamReader reader = new StreamReader(path_theme))
            {
                theme = Convert.ToBoolean(reader.ReadLine());
            }
        }

        private void theme_write()
        {
            using (StreamWriter writer = new StreamWriter(path_theme, false))
            {
                if (theme==true)
                {
                    writer.WriteLine("true");
                }
                else { writer.WriteLine("false"); }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            theme_read();
            if(theme==true)
            {
                this.BackColor = Color.FromArgb(255, 255, 192);
                button5.Text = "—¬≈“À¿ﬂ\n“≈Ã¿";
            }
            else
            {
                this.BackColor = Color.FromArgb(70, 50, 160);
                button5.Text = "“®ÃÕ¿ﬂ\n“≈Ã¿";
            }
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
            Form2 f2 = new Form2(this, theme);
            f2.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (theme == true)
            {
                theme = false;
                this.BackColor = Color.FromArgb(70, 50, 160);
                button5.Text = "“®ÃÕ¿ﬂ\n“≈Ã¿";
                theme_write();
            }
            else
            {
                theme = true;
                this.BackColor = Color.FromArgb(255, 255, 192);
                button5.Text = "—¬≈“À¿ﬂ\n“≈Ã¿";
                theme_write();
            }
        }
    }
}
