using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для MainEXT.xaml
    /// </summary>
    public partial class MainEXT : Page
    {
        public MainEXT()
        {
            
            InitializeComponent();
            Vosk.Opacity = 0;
            Str.Opacity = 0;
            List<string> list = new List<string>();
            List<int> wear = new List<int>();
            App.Connection.Open();
            SqlCommand cmd = new SqlCommand($"select wear,Name from \r\nCar_parts where Car_number = '{App.AHAHAHAHAHAH}'", App.Connection);
            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                wear.Add(r.GetInt32(0));
                list.Add(r.GetString(1));
            }
            App.Connection.Close();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "Двигатель")
                {
                    if (wear[i] >= 75 & wear[i] < 100)
                    {
                        Vosk.Opacity = 0;
                        Str.Opacity = 0;
                    }
                    if (wear[i] >= 50 & wear[i] < 75)
                    {
                        Vosk.Opacity = 65;
                        Str.Opacity = 65;
                        Vosk.Fill = new SolidColorBrush(Colors.YellowGreen);
                        Str.Fill = new SolidColorBrush(Colors.YellowGreen);
                    }
                    if (wear[i] >= 25 & wear[i] < 50)
                    {
                        Vosk.Opacity = 100;
                        Str.Opacity = 100;
                        Vosk.Fill = new SolidColorBrush(Colors.Orange);
                        Str.Fill = new SolidColorBrush(Colors.Orange);
                    }
                    if (wear[i] < 25)
                    {
                        Vosk.Opacity = 100;
                        Str.Opacity = 100;
                        Vosk.Fill = new SolidColorBrush(Colors.Red);
                        Str.Fill = new SolidColorBrush(Colors.Red);
                    }
                }
                else if (list[i] == "Стекло")
                {
                    if (wear[i] >= 75 & wear[i] < 100)
                    {
                        Glass.Stroke = new SolidColorBrush(Colors.Green);
                    }
                    if (wear[i] >= 50 & wear[i] < 75)
                    {
                        Glass.Stroke = new SolidColorBrush(Colors.YellowGreen);
                    }
                    if (wear[i] >= 25 & wear[i] < 50)
                    {
                        Glass.Stroke = new SolidColorBrush(Colors.Orange);
                    }
                    if (wear[i] < 25)
                    {
                        Glass.Stroke = new SolidColorBrush(Colors.Red);
                    }
                }
                else if (list[i] == "Колеса")
                {
                    if (wear[i] >= 75 & wear[i] < 100)
                    {
                        el1.Stroke = new SolidColorBrush(Colors.Green);
                        el2.Stroke = new SolidColorBrush(Colors.Green);
                    }
                    if (wear[i] >= 50 & wear[i] < 75)
                    {
                        el1.Stroke = new SolidColorBrush(Colors.YellowGreen);
                        el2.Stroke = new SolidColorBrush(Colors.YellowGreen);
                    }
                    if (wear[i] >= 25 & wear[i] < 50)
                    {
                        el1.Stroke = new SolidColorBrush(Colors.Orange);
                        el2.Stroke = new SolidColorBrush(Colors.Orange);
                    }
                    if (wear[i] < 25)
                    {
                        el1.Stroke = new SolidColorBrush(Colors.Red);
                        el2.Stroke = new SolidColorBrush(Colors.Red);
                    }
                }
                else if (list[i] == "Корпус")
                {
                    if (wear[i] >= 75 & wear[i] < 100)
                    {
                        Storage.Stroke = new SolidColorBrush(Colors.Green);
                    }
                    if (wear[i] >= 50 & wear[i] < 75)
                    {
                        Storage.Stroke = new SolidColorBrush(Colors.YellowGreen);
                    }
                    if (wear[i] >= 25 & wear[i] < 50)
                    {
                        Storage.Stroke = new SolidColorBrush(Colors.Orange);
                    }
                    if (wear[i] < 25)
                    {
                        Storage.Stroke = new SolidColorBrush(Colors.Red);
                    }
                }
                else if (list[i] == "Кабина")
                {
                    if (wear[i] >= 75 & wear[i] < 100)
                    {
                        Cab.Stroke = new SolidColorBrush(Colors.Green);
                        Cab1.Stroke = new SolidColorBrush(Colors.Green);
                        Cab2.Stroke = new SolidColorBrush(Colors.Green);
                    }
                    if (wear[i] >= 50 & wear[i] < 75)
                    {
                        Cab.Stroke = new SolidColorBrush(Colors.YellowGreen);
                        Cab1.Stroke = new SolidColorBrush(Colors.YellowGreen);
                        Cab2.Stroke = new SolidColorBrush(Colors.YellowGreen);
                    }
                    if (wear[i] >= 25 & wear[i] < 50)
                    {
                        Cab.Stroke = new SolidColorBrush(Colors.Orange);
                        Cab1.Stroke = new SolidColorBrush(Colors.Orange);
                        Cab2.Stroke = new SolidColorBrush(Colors.Orange);
                    }
                    if (wear[i] < 25)
                    {
                        Cab.Stroke = new SolidColorBrush(Colors.Red);
                        Cab1.Stroke = new SolidColorBrush(Colors.Red);
                        Cab2.Stroke = new SolidColorBrush(Colors.Red);
                    }
                }

            }
            List<string> inf = new List<string>();
            int j = 0;
            App.Connection.Open();
            SqlCommand cmd1 = new SqlCommand($"select Auto_brand, Model ,Car_Number, Probeg from \r\nCar where Car_number = '{App.AHAHAHAHAHAH}'", App.Connection);
            var r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                inf.Add(r1.GetString(0));
                inf.Add(r1.GetString(1));
                inf.Add(r1.GetString(2));
                j = r1.GetInt32(3);
            }
            App.Connection.Close();
            j = j % 20000;
            Info_1.Content = $"Машина {inf[0]} модели {inf[1]} с номером {inf[2]} имеет \n среднее состояние {App.last} по всем своим состовляющим \n и проходила ТО {j} километров назад";
            Parts.Content = $" \t Состояние деталей: \n{list[0]}-{wear[0]}% {list[1]}-{wear[1]}% {list[2]}-{wear[2]}%\n {list[3]}-{wear[3]}% {list[4]}-{wear[4]}% ";
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            App.Framer.GoBack();
        }
    }
}
