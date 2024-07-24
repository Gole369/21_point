using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _21_point
{
    public partial class Form2 : Form
    {
        Form1 form1;
        Form3 form3;
        public int bid = 10;
        public int bank = 300;
        public int points = 100;
        public int player_points = 0;
        public int bank_points = 0;
        public int card = 0;

        public int k = 0;
        public int p = 0;

        public bool flag = false;


        public List<int> rating = new List<int>();

        //public string path_data = "D:\\Documents\\практика\\21_point\\data";
        //public string path_data = "C:\\Users\\Георгий\\Documents\\практика\\21_point\\21_point\\data\\";

        public string path_data = AppDomain.CurrentDomain.BaseDirectory.ToString() + "data\\";
        public string path_rules = AppDomain.CurrentDomain.BaseDirectory.ToString() + "game_rules.txt";
        public string path_rating = AppDomain.CurrentDomain.BaseDirectory.ToString() + "rating.txt";


        public Dictionary<int, int> value_card = new Dictionary<int, int>();
        public Dictionary<int, string> path_card = new Dictionary<int, string>();
        public List<int> deck = new List<int>();

        private List<int> deck_game()
        {
            List<int> deck = new List<int>();
            for (int i = 0; i < 36; i++)
            {
                deck.Add(i);
            }
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(deck));
            k = 0;
            p = 0;
            return deck;

        }

        private void creat_deck()
        {
            int k = -1;
            for (int i = 0; i < 36; i++)
            {
                if (i % 4 == 0)
                {
                    k++;
                }
                value_card[i] = 6 + k;
                if (value_card[i] > 11)
                {
                    value_card[i] -= 10;
                }
            }
        }

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            form1.Opacity = 0;
            form1.Enabled = false;
            form1.ShowInTaskbar = false;

            var screen = Screen.FromControl(this);
            this.Top = screen.Bounds.Height / 2 - this.Height / 2;
            this.Left = screen.Bounds.Width / 2 - this.Width / 2;

            new_game();
        }

        private void new_game()
        {

            form3 = new Form3(this, this.bid, this.bank, this.points);
            form3.ShowDialog();

            bid = Data.Number;

            creat_deck();

            deck = deck_game();

            bank_points = 0;
            player_points = 0;

            bank -= bid;
            points -= bid;
            draw();

            if (pictureBox1.Image != null)

            {
                pictureBox1.Image.Dispose();

                pictureBox1.Image = null;

            }
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose(); pictureBox2.Image = null;

            }
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose(); pictureBox3.Image = null;

            }
            if (pictureBox4.Image != null)
            {
                pictureBox4.Image.Dispose(); pictureBox4.Image = null;
            }
            if (pictureBox5.Image != null) { pictureBox5.Image.Dispose(); pictureBox5.Image = null; }
            if (pictureBox6.Image != null) { pictureBox6.Image.Dispose(); pictureBox6.Image = null; }
            if (pictureBox7.Image != null) { pictureBox7.Image.Dispose(); pictureBox7.Image = null; }
            if (pictureBox8.Image != null) { pictureBox8.Image.Dispose(); pictureBox8.Image = null; }
            if (pictureBox9.Image != null) { pictureBox9.Image.Dispose(); pictureBox9.Image = null; }
            if (pictureBox10.Image != null) { pictureBox10.Image.Dispose(); pictureBox10.Image = null; }

            label4.Text = "0";
            label5.Text = "0";



            button5.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы хотите сохранить очки?", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                form1.ShowInTaskbar = true;
                form1.Opacity = 100;
                form1.Enabled = true;
                form1.BringToFront();

                update_rating();

                var screen = Screen.FromControl(form1);
                form1.Top = screen.Bounds.Height / 2 - form1.Height / 2;
                form1.Left = screen.Bounds.Width / 2 - form1.Width / 2;
                this.Close();
            }
        }

        private async void update_rating()
        {
            rating.Clear();
            using (StreamReader reader = new StreamReader(path_rating))
            {
                int num;
                for (int i = 0; i < 10; i++)
                {
                    num = Convert.ToInt32(reader.ReadLine());
                    rating.Add(num);
                }
            }
            rating.Add(points);
            rating.Sort();

            rating.Reverse();
            using (StreamWriter writer = new StreamWriter(path_rating, false))
            {
                for (int i = 0; i < 10; i++)
                {
                    await writer.WriteLineAsync(rating[i].ToString());
                }
            }
        }
        private void draw()
        {
            label1.Text = "Ваши очки " + (points).ToString();
            label2.Text = "Банк " + (bank).ToString();
            label3.Text = "Выйгрыш " + (bid * 2).ToString();
            label3.BackColor = Color.LightYellow;
        }
        private void lose()
        {
            bank += bid * 2;
            draw();
            label3.BackColor = Color.Red;
            label3.Text = "LOSE";

            button1.Enabled = false;
            button2.Enabled = false;

            if (points > 10)
            {
                button5.Enabled = true;
            }
        }
        private void win()
        {
            points += bid * 2;
            draw();
            label3.BackColor = Color.Green;
            label3.Text = "WIN";


            button1.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = true;
        }
        private void time_()
        {
            flag = true;
            timer1.Enabled = true;
            while (flag) Application.DoEvents();
            timer1.Enabled = false;
        }
        private bool versus()
        {
            return player_points < bank_points;
        }

        private int cnd()
        {
            if (versus())
            {
                return -1;
            }
            else if (bank_points < 17 && p < 4)
            {
                return 0;
            }
            else if (bank_points >= 17)
            {
                return 1;
            }
            return 0;
        }

        private void logic()
        {
            int w = 0;
            while (w == 0)
            {
                card = deck[0];
                deck.Remove(card);
                bank_points += value_card[card];

                label4.Text = bank_points.ToString();

                switch (p)
                {
                    case 0:
                        pictureBox6.Image = Image.FromFile(path_data + card.ToString() + ".png");
                        break;
                    case 1:
                        pictureBox7.Image = Image.FromFile(path_data + card.ToString() + ".png");
                        break;
                    case 2:
                        pictureBox8.Image = Image.FromFile(path_data + card.ToString() + ".png");
                        break;
                    case 3:
                        pictureBox9.Image = Image.FromFile(path_data + card.ToString() + ".png");
                        break;
                    case 4:
                        pictureBox10.Image = Image.FromFile(path_data + card.ToString() + ".png");
                        break;
                }
                p++;

                w = cnd();

                time_();
            }

            if (bank_points > 21)
            {
                win();
            }
            else if (bank_points == player_points)
            {
                lose();
            }
            else if (versus())
            {
                lose();
            }
            else
            {
                win();
            }

            /*
            if (p1 > 21) { lose(); }
            else if (p1 <= 21) { win(); }
            */
        }
        private void button1_Click(object sender, EventArgs e)
        {
            card = deck[0];
            deck.Remove(card);
            player_points += value_card[card];

            label5.Text = player_points.ToString();

            switch (k)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile(path_data + card.ToString() + ".png");
                    break;
                case 1:
                    pictureBox2.Image = Image.FromFile(path_data + card.ToString() + ".png");
                    break;
                case 2:
                    pictureBox3.Image = Image.FromFile(path_data + card.ToString() + ".png");
                    break;
                case 3:
                    pictureBox4.Image = Image.FromFile(path_data + card.ToString() + ".png");
                    break;
                case 4:
                    pictureBox5.Image = Image.FromFile(path_data + card.ToString() + ".png");
                    break;
            }
            k++;
            if (k == 5) { button1.Enabled = false; }
            if (player_points > 21) { lose(); }
            else if (player_points == 21) { win(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logic();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flag = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new_game();

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            using (StreamReader reader =  new StreamReader(path_rules))
            {
                string text = await reader.ReadToEndAsync();
                MessageBox.Show(text);
                reader.ReadToEnd();
            }
        }
    }
}
