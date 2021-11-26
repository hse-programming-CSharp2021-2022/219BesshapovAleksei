using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.timer1.Enabled = true;
        }
        int hits = 0, misses = 0;

        private void Form1_Click(object sender, EventArgs e)
        {
            misses += 1;
            this.label1.Text = $"Промахов: {misses}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            this.button1.Location = new Point(random.Next(0, this.Height - 300), random.Next(0, this.Width - 450));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hits += 1;
            this.label2.Text = $"Попаданий: {hits}";
        }
    }
}
