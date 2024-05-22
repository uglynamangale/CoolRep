using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace kursach1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Small2.xaml
    /// </summary>
    public partial class Small2 : Window
    {
        public Small2()
        {
            InitializeComponent();
            string[] k = new string[20];
            int i = 0;
            App.Connection.Open();
            SqlCommand cmd = new SqlCommand($"select Car_Number from Car ", App.Connection);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                k[i] = rdr.GetString(0);
                i++;
            }
            App.Connection.Close();
            int j = 0;
            string[] a = new string[i];
            foreach (string s in k)
                if (s != null)
                {
                    a[j] = s;
                    j++;
                }
                Mach.ItemsSource = a;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (no.IsChecked == true)
            {
                App.Connection.Open();
                SqlCommand cmd2 = new SqlCommand($"update Car_parts \r\nset Wear = {Data_Copy.Text},\r\n    TO_amount = {Data.Text}\r\nwhere Car_Number = '{Mach.Text}' and Name = '{Det.Text}' ", App.Connection);
                cmd2.ExecuteNonQuery();
                App.Connection.Close();
                this.Close();
            }
            if(yeah.IsChecked == true)
            {
                App.Connection.Open();
                SqlCommand cmd3 = new SqlCommand($"update Car_parts \r\nset Wear = 100,\r\n    TO_amount = 0\r\nwhere Car_Number = '{Mach.Text}' and Name = '{Det.Text}' ", App.Connection);
                cmd3.ExecuteNonQuery();
                App.Connection.Close();
                this.Close();
            }
        }

        private void Mach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] k = new string[20];
            int i = 0;
            App.Connection.Open();
            SqlCommand cmd1 = new SqlCommand($"select Name from Car_parts where Car_Number like '{Mach.Text}' ", App.Connection);
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                k[i] = rdr1.GetString(0);
                i++;
            }
            App.Connection.Close();
            int j = 0;
            string[] a = new string[i];
            foreach (string s in k)
                if (s != null)
                {
                    a[j] = s;
                    j++;
                }
            Det.ItemsSource = a;
        }

        private void yeah_Checked(object sender, RoutedEventArgs e)
        {
            if (no.IsChecked == false)
            {
                Data_Copy.IsEnabled = false;
                Data.IsEnabled = false;
            }
        }

        private void no_Checked(object sender, RoutedEventArgs e)
        {
            if (yeah.IsChecked == false)
            {
                Data_Copy.IsEnabled = true;
                Data.IsEnabled = true;
            }
        }
    }
}
