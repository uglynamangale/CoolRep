using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RBooking
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SqlConnection Connection = new SqlConnection("server=DAUN;database=Кристина;trusted_connection=true");
        public static Frame MainFrame;
        public static string User;
        public static string Date;
        public static string StartTime;
        public static string Time;

        public static double FullPrice;

        public static List<Table> All_Tables = new List<Table>();
        public static List<string> All_Dishes = new List<string>();
        public static List<string> All_Services = new List<string>();

        public static void Book()
        {
            Connection.Open();

            SqlCommand cmd = new SqlCommand($"insert into Бронь values ('{Date}','{StartTime}','{Time}','{User}')", Connection);
            cmd.ExecuteNonQuery();

            foreach(var r in All_Tables)
            {
                cmd = new SqlCommand($"insert into Выбранный_стол values ('{r.Table_Num}','{r.Hall_Num}','{Date}','{User}')", Connection);
                cmd.ExecuteNonQuery();
            }

            for(int i = 0;i < All_Dishes.Count;i++)
            {
                cmd = new SqlCommand($"insert into Подача values ('{All_Dishes[i]}','{i+1}','{Date}','{User}')", Connection);
                cmd.ExecuteNonQuery();
            }

            foreach (var r in All_Services)
            {
                cmd = new SqlCommand($"insert into Дополнительная_услуга values ('{Date}','{r}','{User}')", Connection);
                cmd.ExecuteNonQuery();
            }

            Connection.Close();
        }
    }
}
