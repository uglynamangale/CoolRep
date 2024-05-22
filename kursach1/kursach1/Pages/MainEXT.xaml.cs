using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using kursach1.Res;

namespace kursach1.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainEXT.xaml
    /// </summary>
    public partial class MainEXT : Page
    {
        String[] s1 = new String[20];
        public MainEXT()
        {

            InitializeComponent();
            int i = 0;
            Answer.IsEnabled = false;
            Send.IsEnabled = false;
            //App.Connection.Open();
            //SqlCommand cmd = new SqlCommand($"Select CompanyName,Mail,Description from Клиент join Заявка on Клиент.ClientId = Заявка.ClientId where RequestID = '"+ App.AHAHAHAHAHAH +"' Group by CompanyName,Mail, Description", App.Connection);
            //var r = cmd.ExecuteReader();
            //while (r.Read())
            //{
                Infomain.Content = App.Needed;
                Infomain.Content += " ";
                Infomain.Content += App.Needed3;
                Info_1.Text = App.Needed2;
            //}
            //App.Connection.Close();
            App.Connection.Open();
            SqlCommand cmd1 = new SqlCommand("Select TemplateName,Content from Шаблоны_ответов",App.Connection);
            SqlDataReader DR = cmd1.ExecuteReader();
            while (DR.Read())
            {
                Chc.Items.Add(DR[0]);
                s1[i] = DR.GetValue(1).ToString();
                i++;
            }
            App.Connection.Close();
            
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            App.Framer.GoBack();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            int h = 0;
            int j = 0;
            MailAddress from = new MailAddress("van913614@gmail.com", "Поддержка");
            MailAddress to = new MailAddress(App.Needed3);
            MailMessage m = new MailMessage(from, to);
          //  m.Attachments.Add(new Attachment("E:\\photo\\owner\\мемы\\4.jpg"));
            m.Subject = Theme.Text;
            m.Body = Answer.Text;
            m.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("van913614@gmail.com", "uhfb qzig mnav uqxs");
            smtp.EnableSsl = true;
            smtp.Send(m);
            App.Connection.Open();
            SqlCommand cmd1 = new SqlCommand("select ClientId from Клиент where Mail = '" + App.Needed3 + "'", App.Connection);
            SqlDataReader DR = cmd1.ExecuteReader();
            while (DR.Read())
            {
                h = DR.GetInt32(0);
            }
            App.Connection.Close();
            App.Connection.Open();
            SqlCommand cmd2 = new SqlCommand("select max(RequestID) from Заявка ", App.Connection);
            SqlDataReader DR2 = cmd2.ExecuteReader();
            while (DR2.Read())
            {
               j = DR2.GetInt32(0);
            }
            App.Connection.Close();
            j = j + 1;
            App.Connection.Open();
            SqlCommand cmd3 = new SqlCommand("Insert into Заявка values ("+h+","+j+","+App.waytogo+",'"+App.Needed4+"','"+App.Needed4+"',1)", App.Connection);
            cmd3.ExecuteNonQuery();
            App.Connection.Close();
            App.Framer.GoBack();
        }

        private void Chc_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Answer.IsEnabled = true;
            Send.IsEnabled = true;
            Answer.Text = s1[Chc.SelectedIndex];
        }
    }
}
