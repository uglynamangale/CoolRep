﻿using kursach1.Windows;
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
    /// Логика взаимодействия для Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {

        public Welcome()
        {
                InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                bool b = false;
                List<string> Binds = new List<string>();
                List<string> Binds1 = new List<string>();
                App.Connection.Open();
                SqlCommand cmd = new SqlCommand($"select Name, password from Driver where name like '{Log.Text}'", App.Connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    App.Needed = rdr.GetString(0);
                    Binds.Add(rdr.GetString(0));
                    Binds.Add(rdr.GetString(1));
                }
                App.Connection.Close();
                if (Binds.Count == 0)
                {
                    Binds.Add("1");
                    Binds.Add("1");
                }
                if (Binds[0] == Log.Text & Binds[1] == Pas.Password)
                {
                    MessageBox.Show("Добро пожаловать в систему " + Binds[0] + "!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                   App.Framer.Navigate(new Pages.Main());
                }
                else if (Binds[0] == "1" & Binds[1] == "1")
                {
                    App.Connection.Open();
                    SqlCommand cmd1 = new SqlCommand($"select Name, password, Role from Employee where Name like '{Log.Text}'", App.Connection);
                    SqlDataReader rdr1 = cmd1.ExecuteReader();
                    while (rdr1.Read())
                    {
                        App.Needed = rdr1.GetString(0);
                        Binds1.Add(rdr1.GetString(0));
                        Binds1.Add(rdr1.GetString(1));
                        b = rdr1.GetBoolean(2);
                    }
                    App.Connection.Close();
                    if (Binds1[0] == Log.Text & Binds1[1] == Pas.Password & b == false)
                    {
                        MessageBox.Show("Добро пожаловать в систему " + Binds1[0] + "!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                       App.Framer.Navigate(new Pages.Main2());
                    }
                    else if (Binds1[0] == Log.Text & Binds1[1] == Pas.Password & b == true)
                    {
                        MessageBox.Show("Добро пожаловать в систему " + Binds1[0] + "!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                       App.Framer.Navigate(new Pages.PageAdminSecret());
                    }
                    else
                    {
                        MessageBox.Show("Не верные данные, повторите попытку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Не верные данные, повторите попытку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
           
           
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) 
        {
           App.Framer.Navigate(new Who());
        }
    }
}
