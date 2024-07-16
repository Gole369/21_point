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
    public partial class Form2 : Form
    {
        Form1 form1;
        Form3 form3;
        int bid = 10;
        int bank = 1000;
        int points = 100;
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
            form3 = new Form3(this.bid, this.bank, this.points);
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form1.ShowInTaskbar = true;
            form1.Opacity = 100;
            form1.Enabled = true;
            form1.BringToFront();

            var screen = Screen.FromControl(form1);
            form1.Top = screen.Bounds.Height / 2 - form1.Height / 2;
            form1.Left = screen.Bounds.Width / 2 - form1.Width / 2;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Ваши очки " + (points - bid).ToString();
            label2.Text = "Ваши очки " + (bank - bid).ToString();
            label3.Text = "Ваши очки " + (bid*2).ToString();
        }
    }
}
