using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.canvas.Background = Brushes.White;
            this.grid.Background = Brushes.Aqua;
        }
        int color_theme = 0;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (color_theme == 0)
            {
                this.canvas.Background = Brushes.Aqua;
                this.grid.Background = Brushes.White;
                color_theme = 1;
            }
            else
            {
                this.canvas.Background = Brushes.White;
                this.grid.Background = Brushes.Aqua;
                color_theme = 0;
            }
        }
    }
}
