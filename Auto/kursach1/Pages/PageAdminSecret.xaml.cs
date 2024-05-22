using kursach1.Windows;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursach1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdminSecret.xaml
    /// </summary>
    public partial class PageAdminSecret : Page
    {
        int secretId = 1;
        public PageAdminSecret()
        {
            InitializeComponent();
            App.Connection.Open();
            SqlCommand cmd = new SqlCommand($"select Auto_brand, Model,Car.Car_Number,Probeg, avg(wear) as avgwear from \r\nCar join Car_parts on Car.Car_Number = Car_parts.Car_Number\r\nGroup by Auto_brand, Model,Car.Car_Number,Probeg", App.Connection);
            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                Res.Car f = new Res.Car(r.GetValue(0).ToString(), r.GetValue(1).ToString(), r.GetValue(2).ToString(), r.GetInt32(3), r.GetInt32(4));
                F.Items.Add(f);
            }
            App.Connection.Close();
            App.Connection.Open();
            SqlCommand cmd1 = new SqlCommand($"select Employee_ID,Name, Surname, job_Title, Phone_number from Employee", App.Connection);
            var r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                Res.Employee f1 = new Res.Employee(r1.GetInt32(0), r1.GetValue(1).ToString(), r1.GetValue(2).ToString(), r1.GetValue(3).ToString(), r1.GetValue(4).ToString());
                F2.Items.Add(f1);
            }
            App.Connection.Close();
            App.Connection.Open();
            SqlCommand cmd2 = new SqlCommand($"select Driver_ID,Name, Surname, Driving_License, Phone_number from Driver", App.Connection);
            var r2 = cmd2.ExecuteReader();
            while (r2.Read())
            {
                Res.Voditel f2 = new Res.Voditel(r2.GetInt32(0), r2.GetValue(1).ToString(), r2.GetValue(2).ToString(), r2.GetValue(3).ToString(), r2.GetValue(4).ToString());
                F3.Items.Add(f2);
               
            }
            App.Connection.Close();
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NotSmall3 w = new NotSmall3();
            w.Show();
        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            switch (secretId)
            {
                case 0:
                    if (F3.SelectedIndex == -1)
                        return;
                    Res.Voditel b = (Res.Voditel)F3.SelectedItem;
                    App.Connection.Open();
                    SqlCommand cmd3 = new SqlCommand($"Delete from Driver where Driver_ID = {b.Driver_ID}", App.Connection);
                    cmd3.ExecuteNonQuery();
                    App.Connection.Close();
                    b = null;
                    F3.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd7 = new SqlCommand($"select Driver_ID,Name, Surname, Driving_License, Phone_number from Driver", App.Connection);
                    var r2 = cmd7.ExecuteReader();
                    while (r2.Read())
                    {
                        b = new Res.Voditel(r2.GetInt32(0), r2.GetValue(1).ToString(), r2.GetValue(2).ToString(), r2.GetValue(3).ToString(), r2.GetValue(4).ToString());
                        F3.Items.Add(b);

                    }
                    App.Connection.Close();
                    break;
                case 1:
                    if (F.SelectedIndex == -1)
                        return;
                    Res.Car f = (Res.Car)F.SelectedItem;
                    App.Connection.Open();
                    SqlCommand cmd = new SqlCommand($"Delete from Employee where Car_Number = '{f.Car_Number}'", App.Connection);
                    cmd.ExecuteNonQuery();
                    App.Connection.Close();
                    f = null;
                    F.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd6 = new SqlCommand($"select Auto_brand, Model,Car.Car_Number,Probeg, avg(wear) as avgwear from \r\nCar join Car_parts on Car.Car_Number = Car_parts.Car_Number\r\nGroup by Auto_brand, Model,Car.Car_Number,Probeg", App.Connection);
                    var r6 = cmd6.ExecuteReader();
                    while (r6.Read())
                    {
                        f = new Res.Car(r6.GetValue(0).ToString(), r6.GetValue(1).ToString(), r6.GetValue(2).ToString(), r6.GetInt32(3), r6.GetInt32(4));
                        F.Items.Add(f);

                    }
                    App.Connection.Close();
                    break;
                case 2:
                    if (F2.SelectedIndex == -1)
                        return;
                    Res.Employee n = (Res.Employee)F2.SelectedItem;
                    App.Connection.Open();
                    SqlCommand cmd2 = new SqlCommand($"Delete from Employee where Employee_ID = {n.Employee_ID}", App.Connection);
                    cmd2.ExecuteNonQuery();
                    App.Connection.Close();
                    n = null;
                    F3.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd5 = new SqlCommand($"select Employee_ID,Name, Surname, job_Title, Phone_number from Employee", App.Connection);
                    var r5 = cmd5.ExecuteReader();
                    while (r5.Read())
                    {
                        n = new Res.Employee(r5.GetInt32(0), r5.GetValue(1).ToString(), r5.GetValue(2).ToString(), r5.GetValue(3).ToString(), r5.GetValue(4).ToString());
                        F2.Items.Add(n);

                    }
                    App.Connection.Close();
                    break;
            }
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            secretId++;
            if (secretId > 2)
                secretId = 0;
            switch (secretId)
            {
                case 0:
                    F2.IsEnabled = false;
                    F2.Visibility = Visibility.Hidden;
                    namem.Content = "Водители";
                    F3.IsEnabled = true;
                    F3.Visibility = Visibility.Visible;
                    break;
                case 1:
                    F3.IsEnabled = false;
                    F3.Visibility = Visibility.Hidden;
                    namem.Content = "Машины";
                    F.IsEnabled = true;
                    F.Visibility = Visibility.Visible;
                    break;
                case 2:
                    F3.IsEnabled = false;
                    F3.Visibility = Visibility.Hidden;
                    F.IsEnabled = false;
                    F.Visibility = Visibility.Hidden;
                    namem.Content = "Сотрудники";
                    F2.IsEnabled = true;
                    F2.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void LEft_Click(object sender, RoutedEventArgs e)
        {
            secretId--;
            if (secretId < 0)
                secretId = 2;
            switch (secretId)
            {
                case 0:
                    F2.IsEnabled = false;
                    F2.Visibility = Visibility.Hidden;
                    namem.Content = "Водители";
                    F3.IsEnabled = true;
                    F3.Visibility = Visibility.Visible;
                    break;
                case 1:
                    F2.IsEnabled = false;
                    F2.Visibility = Visibility.Hidden;
                    F3.IsEnabled = false;
                    F3.Visibility = Visibility.Hidden;
                    namem.Content = "Машины";
                    F.IsEnabled = true;
                    F.Visibility = Visibility.Visible;
                    break;
                case 2:
                    F3.IsEnabled = false;
                    F3.Visibility = Visibility.Hidden;
                    F.IsEnabled = false;
                    F.Visibility = Visibility.Hidden;
                    namem.Content = "Сотрудники";
                    F2.IsEnabled = true;
                    F2.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void namem_Click(object sender, RoutedEventArgs e)
        {
            switch (secretId)
            {
                case 0:
                    F3.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd7 = new SqlCommand($"select Driver_ID,Name, Surname, Driving_License, Phone_number from Driver", App.Connection);
                    var r2 = cmd7.ExecuteReader();
                    while (r2.Read())
                    {
                        Res.Voditel b = new Res.Voditel(r2.GetInt32(0), r2.GetValue(1).ToString(), r2.GetValue(2).ToString(), r2.GetValue(3).ToString(), r2.GetValue(4).ToString());
                        F3.Items.Add(b);

                    }
                    App.Connection.Close();
                    break;
                case 1:
                    F.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd6 = new SqlCommand($"select Auto_brand, Model,Car.Car_Number,Probeg, avg(wear) as avgwear from \r\nCar join Car_parts on Car.Car_Number = Car_parts.Car_Number\r\nGroup by Auto_brand, Model,Car.Car_Number,Probeg", App.Connection);
                    var r6 = cmd6.ExecuteReader();
                    while (r6.Read())
                    {
                        Res.Car f = new Res.Car(r6.GetValue(0).ToString(), r6.GetValue(1).ToString(), r6.GetValue(2).ToString(), r6.GetInt32(3), r6.GetInt32(4));
                        F.Items.Add(f);

                    }
                    App.Connection.Close();
                    break;
                case 2:
                     F3.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd5 = new SqlCommand($"select Employee_ID,Name, Surname, job_Title, Phone_number from Employee", App.Connection);
                    var r5 = cmd5.ExecuteReader();
                    while (r5.Read())
                    {
                        Res.Employee n = new Res.Employee(r5.GetInt32(0), r5.GetValue(1).ToString(), r5.GetValue(2).ToString(), r5.GetValue(3).ToString(), r5.GetValue(4).ToString());
                        F2.Items.Add(n);

                    }
                    App.Connection.Close();
                    break;
            }
        }
    }
}
