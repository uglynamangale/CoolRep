﻿using System;
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
    /// Логика взаимодействия для Vod.xaml
    /// </summary>
    public partial class Vod : Page
    {
        public Vod()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string c = "";
            App.Connection.Open();
            SqlCommand cmd = new SqlCommand($"select password from Driver where Driving_License like '{Numero.Text}'", App.Connection);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                c += rdr.GetString(0);
            }
            App.Connection.Close();
            MessageBox.Show("Ваш пароль был " + c + " пожалуйста не забывайте его впредь!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            App.Framer.Navigate(new Welcome());
        }
    }
}
