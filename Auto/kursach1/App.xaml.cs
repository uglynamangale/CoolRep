using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace kursach1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Frame Framer;
        public static string Needed;
        public static int last;
        public static string AHAHAHAHAHAH;
        public static SqlConnection Connection = new SqlConnection("server=SKELETAL-COMPUT;database=ACM;trusted_connection=true");
    }
}
