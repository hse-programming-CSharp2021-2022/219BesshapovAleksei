using System;
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
    /// <summary>
    /// на самом деле, это задача 3
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int p1 = 1;
        int p2 = 2;

        private void button1_Click(object sender, EventArgs e)
        {
            if (p1 + 2 * p2 < 0)
            {
                MessageBox.Show("Переполнение! Идем с начала");
                (p1, p2) = (1, 2);
            }
            this.label1.Text = "Следующий член ряда Пелла: " + (p1 + 2 * p2).ToString();
            (p1, p2) = (p2, p1 + 2 * p2);
        }
    }
}
