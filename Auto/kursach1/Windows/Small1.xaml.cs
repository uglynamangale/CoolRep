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
using System.Windows.Shapes;

namespace kursach1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Small1.xaml
    /// </summary>
    public partial class Small1 : Window
    {
        int d;
        public Small1()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
           
            if (Convert.ToInt32(Koms.Text) < 450)
            {
                int broke = 0;
                App.Connection.Open();
                SqlCommand cmd = new SqlCommand($"select Max(Path_ID) from Path ", App.Connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    d = rdr.GetInt32(0);
                }
                App.Connection.Close();
                d++;
                App.Connection.Open();
                SqlCommand cmd1 = new SqlCommand($"insert into dbo.Path values({d},'{Start.Text}','{End.Text}',{Koms.Text},'{Data.SelectedDate}') ", App.Connection);
                cmd1.ExecuteNonQuery();
                App.Connection.Close();
                App.Connection.Open();
                SqlCommand cmd2 = new SqlCommand($"insert into dbo.Entity1 values({App.Needed},'{App.AHAHAHAHAHAH}',{d})", App.Connection);
                cmd2.ExecuteNonQuery();
                App.Connection.Close();
                App.Connection.Open();
                SqlCommand cmd3 = new SqlCommand($"Update Car set Probeg = Probeg + {Koms.Text} where Car_Number = '{App.AHAHAHAHAHAH}'", App.Connection);
                cmd3.ExecuteNonQuery();
                App.Connection.Close();
                App.Connection.Open();
                if (Convert.ToInt32(Koms.Text) >= 350 & Convert.ToInt32(Koms.Text) < 450)
                {
                     broke = rnd.Next(1, 7);
                }
                else if (Convert.ToInt32(Koms.Text) >= 250 & (Convert.ToInt32(Koms.Text) < 350))
                {
                     broke = rnd.Next(1, 6);
                }
                else if (Convert.ToInt32(Koms.Text) >= 150 & (Convert.ToInt32(Koms.Text) < 250))
                {
                     broke = rnd.Next(0, 4);
                }
                else
                     broke = rnd.Next(0, 3);
                SqlCommand cmd4 = new SqlCommand($"Update Car_Parts set wear = wear - {broke} where Car_Number = '{App.AHAHAHAHAHAH}' and Name = 'Двигатель'", App.Connection);
                cmd4.ExecuteNonQuery();
                App.Connection.Close();
                this.Close();
            }

        }

        private void Data_CalendarOpened(object sender, RoutedEventArgs e)
        {
            Data.DisplayDateStart = DateTime.Now;
            Data.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(6);

            var minDate = Data.DisplayDateStart ?? DateTime.MinValue;
            var maxDate = Data.DisplayDateEnd ?? DateTime.MaxValue;

            for (var d = minDate; d <= maxDate && DateTime.MaxValue > d; d = d.AddDays(1))
            {
                if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)
                {
                    Data.BlackoutDates.Add(new CalendarDateRange(d));
                }
            }
        }
    }
}
