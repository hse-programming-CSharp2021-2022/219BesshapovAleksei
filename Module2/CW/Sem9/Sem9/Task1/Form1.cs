﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "Нажал";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Visible = false;
            this.button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button2.Visible = true;
            this.button3.Visible = false;
            this.button2.Text = "Оп";
        }
    }
}
