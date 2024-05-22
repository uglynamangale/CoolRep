using kursach1.Windows;
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

namespace kursach1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Who.xaml
    /// </summary>
    public partial class Who : Page
    {
        public Who()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           App.Framer.Navigate(new Pages.Vod());
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
           App.Framer.Navigate(new Pages.Sot());
        }
    }
}
