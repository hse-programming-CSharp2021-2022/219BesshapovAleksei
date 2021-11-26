using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int minwidth = 220;
        int minheight = 100;
        int maxwidth = 1000;
        int maxheight = 700;
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Уменьшить")
            {
                this.Size /= 2;
                if (this.Width <= minwidth || this.Height <= minheight)
                {
                    this.button1.Text = "Увеличить";
                }
            }
            else
            {
                this.Size *= 2;
                if (this.Width >= maxwidth || this.Height >= maxheight)
                {
                    this.button1.Text = "Уменьшить";
                }
            }
            this.button1.Location = new Point(0, 0);
            this.button1.Size = new Size(this.Width, this.Height);
        }
    }
}
