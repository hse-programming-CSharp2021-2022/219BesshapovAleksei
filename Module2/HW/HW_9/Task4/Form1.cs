using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ListBox";
            listBox1.Visible = false;
            buttonDelete.Visible = false;
        }
        string[] lines = new string[] { "один", "два", "три", "четыре", "пять", "шесть", "семь" };
        string[] newLines;
        private void buttonInit_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lines);
            newLines = lines;
            buttonDelete.Visible = true;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int n = listBox1.SelectedIndex;
            if (n == -1)
            {
                MessageBox.Show("Нет выбранного элемента");
                return;
            }
            string[] tempLines = new string[newLines.Length - 1];
            for (int k = 0, i = 0; i < newLines.Length; i++)
            {
                if (i != n)
                {
                    tempLines[k++] = newLines[i];
                }
            }
            newLines = tempLines;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(newLines);
        }
    }
}