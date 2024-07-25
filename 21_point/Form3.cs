using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_point
{
    public partial class Form3 : Form
    {
        Form2 form2;
        private int bid;
        private int bank;
        private int points;
        int n;
        public Form3(Form2 form2, int bid, int bank, int points)
        {
            InitializeComponent();
            this.form2 = form2;
            this.bid = bid;
            this.bank = bank;
            this.points = points;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            if (n > bank)
            {
                MessageBox.Show("Ставка не должна превышать банк");
            }
            else if (n < 10)
            {
                MessageBox.Show("Минимальная ставка: 10 очков");
            }
            else if (n > points)
            {
                MessageBox.Show("У вас недостаточно очков");
            }
            else
            {
                Data.Number = n;
                this.Dispose();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(bank);
            label5.Text = Convert.ToString(points);
        }
    }
}
