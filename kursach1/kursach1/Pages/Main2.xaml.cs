using kursach1.Windows;
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
    /// Логика взаимодействия для Main2.xaml
    /// </summary>
    public partial class Main2 : Page
    {
        public Main2()
        {
            InitializeComponent();
            App.Connection.Open();
            SqlCommand cmd = new SqlCommand($"select Auto_brand, Model,Car.Car_Number,Probeg, avg(wear) as avgwear from \r\nCar join Car_parts on Car.Car_Number = Car_parts.Car_Number\r\nGroup by Auto_brand, Model,Car.Car_Number,Probeg", App.Connection);
            var r = cmd.ExecuteReader();
            while (r.Read())
            {
     //           Res.Zav f = new Res.Zav(r.GetValue(0).ToString(), r.GetValue(1).ToString(), r.GetValue(2).ToString(), r.GetInt32(3), r.GetInt32(4));
     //           Vrooms.Items.Add(f);
            }
            App.Connection.Close();
        }

        private void btn2(object sender, RoutedEventArgs e)
        {
            Small2 d = new Small2();
            d.Show();
        }

        private void btn3(object sender, RoutedEventArgs e)
        {
            Vrooms.Items.Clear();
            App.Connection.Open();
            SqlCommand cmd10 = new SqlCommand($"select Auto_brand, Model,Car.Car_Number,Probeg, avg(wear) as avgwear from \r\nCar join Car_parts on Car.Car_Number = Car_parts.Car_Number\r\nGroup by Auto_brand, Model,Car.Car_Number,Probeg", App.Connection);
            var r = cmd10.ExecuteReader();
            while (r.Read())
            {
       //         Res.Zav f = new Res.Zav(r.GetValue(0).ToString(), r.GetValue(1).ToString(), r.GetValue(2).ToString(), r.GetInt32(3), r.GetInt32(4));
       //         Vrooms.Items.Add(f);
            }
            App.Connection.Close();
        }

       

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            App.Framer.GoBack();
        }
    }
}
