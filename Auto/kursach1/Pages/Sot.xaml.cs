using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Sot.xaml
    /// </summary>
    public partial class Sot : Page
    {
        public Sot()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string c = "";
            bool b = false;
            App.Connection.Open();
            SqlCommand cmd = new SqlCommand($"select password, Role from Employee where Employee_ID like '{Numero.Text}'", App.Connection);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                c += rdr.GetString(0);
                b = rdr.GetBoolean(1);
            }
            App.Connection.Close();
            if(b == true)
            {
                MessageBox.Show("Господин Администратор как вы посмели забыть свой пароль!\n Назад вы его не получите :)", "Хи-хи-ха", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            MessageBox.Show("Ваш пароль был " + c + " пожалуйста не забывайте его впредь!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            App.Framer.Navigate(new Welcome());
        }
    }
}
