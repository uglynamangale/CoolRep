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
            SqlCommand cmd = new SqlCommand($"Select RequestID, CompanyName,Theme,Status from Клиент join Заявка on Клиент.ClientId = Заявка.ClientId Group by RequestID,CompanyName, Theme,Status", App.Connection);
            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                 Res.Zav f = new Res.Zav(r.GetInt32(0), r.GetValue(1).ToString(), r.GetValue(2).ToString(), r.GetBoolean(3));
                 F.Items.Add(f);
            }
            App.Connection.Close();
            App.Connection.Open();
            SqlCommand cmd1 = new SqlCommand($"select WorkerID,Login, Password, Role from Сотрудник where Role = 'False'", App.Connection);
            var r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                Res.Employee f1 = new Res.Employee(r1.GetInt32(0), r1.GetValue(1).ToString(), r1.GetValue(2).ToString(),r1.GetBoolean(3));
                F2.Items.Add(f1);
            }
            App.Connection.Close();
            App.Connection.Open();
            SqlCommand cmd2 = new SqlCommand($"select TicketRespID,TemplateName, Content from Шаблоны_ответов", App.Connection);
            var r2 = cmd2.ExecuteReader();
            while (r2.Read())
            {
                Res.Shablon f2 = new Res.Shablon(r2.GetInt32(0), r2.GetValue(1).ToString(), r2.GetValue(2).ToString());
                F3.Items.Add(f2);

            }
            App.Connection.Close();
            App.Connection.Open();
            SqlCommand cmd3 = new SqlCommand($"select ClientId,Mail, CompanyName from Клиент", App.Connection);
            var r3 = cmd3.ExecuteReader();
            while (r3.Read())
            {
                Res.Client f3 = new Res.Client(r3.GetInt32(0), r3.GetValue(1).ToString(), r3.GetValue(2).ToString());
                F4.Items.Add(f3);
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
                    Res.Shablon b = (Res.Shablon)F3.SelectedItem;
                    App.Connection.Open();
                    SqlCommand cmd3 = new SqlCommand($"Delete from Шаблоны_ответов where TicketRespID = '{b.TicketRespID}'", App.Connection);
                    cmd3.ExecuteNonQuery();
                    App.Connection.Close();
                    b = null;
                    F3.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd2 = new SqlCommand($"select TicketRespID,TemplateName, Content from Шаблоны_ответов", App.Connection);
                    var r2 = cmd2.ExecuteReader();
                    while (r2.Read())
                    {
                        Res.Shablon f2 = new Res.Shablon(r2.GetInt32(0), r2.GetValue(1).ToString(), r2.GetValue(2).ToString());
                        F3.Items.Add(f2);

                    }
                    App.Connection.Close();
                    break;
                case 1:
                    if (F.SelectedIndex == -1)
                        return;
                    Res.Zav f = (Res.Zav)F.SelectedItem;
                    App.Connection.Open();
                    SqlCommand cmd = new SqlCommand($"Delete from Заявка where RequestID = '{f.ID}'", App.Connection);
                    cmd.ExecuteNonQuery();
                    App.Connection.Close();
                    f = null;
                    F.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd0 = new SqlCommand($"Select RequestID, CompanyName,Theme,Status from Клиент join Заявка on Клиент.ClientId = Заявка.ClientId Group by RequestID,CompanyName, Theme,Status", App.Connection);
                    var r = cmd0.ExecuteReader();
                    while (r.Read())
                    {
                        Res.Zav f2 = new Res.Zav(r.GetInt32(0), r.GetValue(1).ToString(), r.GetValue(2).ToString(), r.GetBoolean(3));
                        F.Items.Add(f2);
                    }
                    App.Connection.Close();
                    break;
                case 2:
                    if (F4.SelectedIndex == -1)
                        return;
                    Res.Client m = (Res.Client)F4.SelectedItem;
                    App.Connection.Open();
                    SqlCommand cmd32 = new SqlCommand($"Delete from Клиент where ClientId = '{m.ClientId}'", App.Connection);
                    cmd32.ExecuteNonQuery();
                    App.Connection.Close();
                    m = null;
                    F4.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd51 = new SqlCommand($"select ClientId,Mail, CompanyName from Клиент", App.Connection);
                    var r51 = cmd51.ExecuteReader();
                    while (r51.Read())
                    {
                        m = new Res.Client(r51.GetInt32(0), r51.GetValue(1).ToString(), r51.GetValue(2).ToString());
                        F4.Items.Add(m);

                    }
                    App.Connection.Close();
                    break;
                case 3:
                    if (F2.SelectedIndex == -1)
                        return;
                    Res.Employee n = (Res.Employee)F2.SelectedItem;
                    App.Connection.Open();
                    SqlCommand cmd22 = new SqlCommand($"Delete from Сотрудник where WorkerID = '{n.WorkerID}'", App.Connection);
                    cmd22.ExecuteNonQuery();
                    App.Connection.Close();
                    n = null;
                    F2.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd5 = new SqlCommand($"select WorkerID,Login, Password, Role from Сотрудник where Role = 'False'", App.Connection);
                    var r5 = cmd5.ExecuteReader();
                    while (r5.Read())
                    {
                        n = new Res.Employee(r5.GetInt32(0), r5.GetValue(1).ToString(), r5.GetValue(2).ToString(), r5.GetBoolean(3));
                        F2.Items.Add(n);

                    }
                    App.Connection.Close();
                    break;
                
            }
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            secretId++;
            if (secretId > 3)
                secretId = 0;
            switch (secretId)
            {
                case 0:
                    F2.IsEnabled = false;
                    F2.Visibility = Visibility.Hidden;
                    namem.Content = "Шаблоны";
                    F3.IsEnabled = true;
                    F3.Visibility = Visibility.Visible;
                    break;
                case 1:
                    F3.IsEnabled = false;
                    F3.Visibility = Visibility.Hidden;
                    namem.Content = "Заявки";
                    F.IsEnabled = true;
                    F.Visibility = Visibility.Visible;
                    break;
                case 2:
                    F.IsEnabled = false;
                    F.Visibility = Visibility.Hidden;
                    namem.Content = "Клиенты";
                    F4.IsEnabled = true;
                    F4.Visibility = Visibility.Visible;
                    break;
                case 3:
                    F3.IsEnabled = false;
                    F3.Visibility = Visibility.Hidden;
                    F.IsEnabled = false;
                    F.Visibility = Visibility.Hidden;
                    F4.IsEnabled = false;
                    F4.Visibility = Visibility.Hidden;
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
                secretId = 3;
            switch (secretId)
            {
                case 0:
                    F2.IsEnabled = false;
                    F2.Visibility = Visibility.Hidden;
                    namem.Content = "Шаблоны";
                    F3.IsEnabled = true;
                    F3.Visibility = Visibility.Visible;
                    break;
                case 1:
                    F2.IsEnabled = false;
                    F2.Visibility = Visibility.Hidden;
                    F3.IsEnabled = false;
                    F3.Visibility = Visibility.Hidden;
                    namem.Content = "Заявки";
                    F4.IsEnabled = false;
                    F4.Visibility = Visibility.Hidden;
                    F.IsEnabled = true;
                    F.Visibility = Visibility.Visible;
                    break;
                case 2:
                    F.IsEnabled = false;
                    F.Visibility = Visibility.Hidden;
                    namem.Content = "Клиенты";
                    F4.IsEnabled = true;
                    F4.Visibility = Visibility.Visible;
                    break;
                case 3:
                    F3.IsEnabled = false;
                    F3.Visibility = Visibility.Hidden;
                    F.IsEnabled = false;
                    F.Visibility = Visibility.Hidden;
                    F4.IsEnabled = false;
                    F4.Visibility = Visibility.Hidden;
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
                    SqlCommand cmd2 = new SqlCommand($"select TicketRespID,TemplateName, Content from Шаблоны_ответов", App.Connection);
                    var r2 = cmd2.ExecuteReader();
                    while (r2.Read())
                    {
                        Res.Shablon f2 = new Res.Shablon(r2.GetInt32(0), r2.GetValue(1).ToString(), r2.GetValue(2).ToString());
                        F3.Items.Add(f2);

                    }
                    App.Connection.Close();
                    break;
                case 1:
                    F.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd = new SqlCommand($"Select RequestID, CompanyName,Theme,Status from Клиент join Заявка on Клиент.ClientId = Заявка.ClientId Group by RequestID,CompanyName, Theme,Status", App.Connection);
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        Res.Zav f = new Res.Zav(r.GetInt32(0), r.GetValue(1).ToString(), r.GetValue(2).ToString(), r.GetBoolean(3));
                        F.Items.Add(f);
                    }
                    App.Connection.Close();
                    break;
                case 2:
                    F4.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd3 = new SqlCommand($"select ClientId,Mail, CompanyName from Клиент", App.Connection);
                    var r3 = cmd3.ExecuteReader();
                    while (r3.Read())
                    {
                        Res.Client f3 = new Res.Client(r3.GetInt32(0), r3.GetValue(1).ToString(), r3.GetValue(2).ToString());
                        F4.Items.Add(f3);
                    }
                    App.Connection.Close();
                    break;
                case 3:
                    F2.Items.Clear();
                    App.Connection.Open();
                    SqlCommand cmd1 = new SqlCommand($"select WorkerID,Login, Password, Role from Сотрудник where Role = 'False'", App.Connection);
                    var r1 = cmd1.ExecuteReader();
                    while (r1.Read())
                    {
                        Res.Employee f1 = new Res.Employee(r1.GetInt32(0), r1.GetValue(1).ToString(), r1.GetValue(2).ToString(), r1.GetBoolean(3));
                        F2.Items.Add(f1);
                    }
                    App.Connection.Close();
                    break;
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            App.Framer.GoBack();
        }

        private void GoBack_Click2(object sender, RoutedEventArgs e)
        {
            App.Framer.Navigate(new Pages.Main());
        }
    }
}
