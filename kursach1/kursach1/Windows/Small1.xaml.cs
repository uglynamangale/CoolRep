using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
        String[] s1 = new String[20];
        int i = 0;
        public Small1()
        {
            InitializeComponent();
            App.Connection.Open();
            SqlCommand cmd1 = new SqlCommand("Select CompanyName,Mail from Клиент", App.Connection);
            SqlDataReader DR = cmd1.ExecuteReader();
            while (DR.Read())
            {
                Chc.Items.Add(DR[0]);
                s1[i] = DR.GetValue(1).ToString();
                i++;
            }
            App.Connection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int h = 0;
            int j = 0;
            MailAddress from = new MailAddress("van913614@gmail.com", "Поддержка");
            MailAddress to = new MailAddress(s1[Chc.SelectedIndex]);
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
            SqlCommand cmd1 = new SqlCommand("select ClientId from Клиент where Mail = '" + s1[Chc.SelectedIndex] + "'", App.Connection);
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
            SqlCommand cmd3 = new SqlCommand("Insert into Заявка values (" + h + "," + j + "," + App.waytogo + ",'" + Theme.Text + "','" + Op.Text + "',1)", App.Connection);
            cmd3.ExecuteNonQuery();
            App.Connection.Close();
            this.Close();
        }
    }
}
