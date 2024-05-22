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

namespace RBooking
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Chooser : Window
    {
        public Chooser()
        {
            InitializeComponent();
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            new Booking().Show();
            this.Close();
        }

        private void CheckBook_Click(object sender, RoutedEventArgs e)
        {
            new UserBooks().Show();
            this.Close();
        }
    }
}
