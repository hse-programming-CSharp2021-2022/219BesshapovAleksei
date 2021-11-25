using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double opacity_difference;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.label1.ForeColor = Color.DeepPink;
            opacity_difference = 0.1;
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (opacity_difference > 0)
            {
                if (label1.Text.Length > 0)
                {
                    label1.Text = label1.Text[..^1];
                }
                else
                {
                    if (this.Opacity > 0)
                    {
                        this.Opacity -= opacity_difference;
                    }
                    else
                    {
                        label1.Text = "А нет его";
                        opacity_difference *= -1;
                    }
                }
            }
            else
            {
                this.Opacity -= opacity_difference;
            }
        }
    }
}
