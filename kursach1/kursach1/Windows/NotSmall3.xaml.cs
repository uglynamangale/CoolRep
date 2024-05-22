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
    /// Логика взаимодействия для NotSmall3.xaml
    /// </summary>
    public partial class NotSmall3 : Window
    {
        int secretId = 1;
        String[] s1 = new String[20];
        int i = 0;
        public NotSmall3()
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
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            secretId++;
           
            if (secretId > 3)
                secretId = 0;
            switch (secretId)
            {
                case 0:
                    S3.IsEnabled = false;
                    S3.Visibility = Visibility.Hidden;
                    S1.IsEnabled = false;
                    S1.Visibility = Visibility.Hidden;
                    S2.IsEnabled = false;
                    S2.Visibility = Visibility.Hidden;
                    S3.IsEnabled = false;
                    S3.Visibility = Visibility.Hidden;
                    namem.Content = "Шаблоны";
                    S0.IsEnabled = true;
                    S0.Visibility = Visibility.Visible;
                    break;
                case 1:
                    S0.IsEnabled = false;
                    S0.Visibility = Visibility.Hidden;
                    S3.IsEnabled = false;
                    S3.Visibility = Visibility.Hidden;
                    S2.IsEnabled = false;
                    S2.Visibility = Visibility.Hidden;
                    namem.Content = "Заявки";
                    S1.IsEnabled = true;
                    S1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    S3.IsEnabled = false;
                    S3.Visibility = Visibility.Hidden;
                    S0.IsEnabled = false;
                    S0.Visibility = Visibility.Hidden;
                    S1.IsEnabled = false;
                    S1.Visibility = Visibility.Hidden;
                    namem.Content = "Клиенты";
                    S2.IsEnabled = true;
                    S2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    S0.IsEnabled = false;
                    S0.Visibility = Visibility.Hidden;
                    S1.IsEnabled = false;
                    S1.Visibility = Visibility.Hidden;
                    S2.IsEnabled = false;
                    S2.Visibility = Visibility.Hidden;
                    namem.Content = "Сотрудники";
                    S3.IsEnabled = true;
                    S3.Visibility = Visibility.Visible;
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
                    S3.IsEnabled = false;
                    S3.Visibility = Visibility.Hidden;
                    S1.IsEnabled = false;
                    S1.Visibility = Visibility.Hidden;
                    S2.IsEnabled = false;
                    S2.Visibility = Visibility.Hidden;
                    S3.IsEnabled = false;
                    S3.Visibility = Visibility.Hidden;
                    namem.Content = "Шаблоны";
                    S0.IsEnabled = true;
                    S0.Visibility = Visibility.Visible;
                    break;
                case 1:
                    S0.IsEnabled = false;
                    S0.Visibility = Visibility.Hidden;
                    S3.IsEnabled = false;
                    S3.Visibility = Visibility.Hidden;
                    S2.IsEnabled = false;
                    S2.Visibility = Visibility.Hidden;
                    namem.Content = "Заявки";
                    S1.IsEnabled = true;
                    S1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    S3.IsEnabled = false;
                    S3.Visibility = Visibility.Hidden;
                    S0.IsEnabled = false;
                    S0.Visibility = Visibility.Hidden;
                    S1.IsEnabled = false;
                    S1.Visibility = Visibility.Hidden;
                    namem.Content = "Клиенты";
                    S2.IsEnabled = true;
                    S2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    S0.IsEnabled = false;
                    S0.Visibility = Visibility.Hidden;
                    S1.IsEnabled = false;
                    S1.Visibility = Visibility.Hidden;
                    S2.IsEnabled = false;
                    S2.Visibility = Visibility.Hidden;
                    namem.Content = "Сотрудники";
                    S3.IsEnabled = true;
                    S3.Visibility = Visibility.Visible;
                    break;
            }
        }

        

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Ad.IsEnabled = false;
            if(Sot.IsChecked == false)
                Ad.IsEnabled = true;
        }

        private void Ad_Checked(object sender, RoutedEventArgs e)
        {
            Sot.IsEnabled = false;
            if (Ad.IsChecked == false)
                Sot.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int dn = rnd.Next(5, 4829247);
            switch (secretId)
            {
                case 0:
                    int a = 0;
                    App.Connection.Open();
                    SqlCommand cmd = new SqlCommand("select max(TicketRespID) from Шаблоны_ответов ", App.Connection);
                    SqlDataReader DR1 = cmd.ExecuteReader();
                    while (DR1.Read())
                    {
                        a = DR1.GetInt32(0);
                    }
                    App.Connection.Close();
                    a = a + 1;
                    App.Connection.Open();
                    SqlCommand cmd5 = new SqlCommand("Insert into Шаблоны_ответов values (" + a + ",'" + ShabName.Text + "','" + Opis.Text + "')", App.Connection);
                    cmd5.ExecuteNonQuery();
                    App.Connection.Close();
                    this.Close();
                    break;
                case 1:
                   
                    int h = 0;
                    int j = 0;
                    MailAddress from = new MailAddress("van913614@gmail.com", "Поддержка");
                    MailAddress to = new MailAddress(s1[Chc.SelectedIndex]);
                    MailMessage m = new MailMessage(from, to);
                    //  m.Attachments.Add(new Attachment("E:\\photo\\owner\\мемы\\4.jpg"));
                    m.Subject = "Ответ на заявку";
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
                    break;
                case 2:
                    int f = 0;
                    App.Connection.Open();
                    SqlCommand cmd22 = new SqlCommand("select max(ClientID) from Клиент ", App.Connection);
                    SqlDataReader DR22 = cmd22.ExecuteReader();
                    while (DR22.Read())
                    {
                        f = DR22.GetInt32(0);
                    }
                    App.Connection.Close();
                    f = f + 1;
                    App.Connection.Open();
                    SqlCommand cmd4 = new SqlCommand("Insert into Клиент values (" + f + ",'" + MailComp.Text + "','" + NameComp.Text + "')", App.Connection);
                    cmd4.ExecuteNonQuery();
                    App.Connection.Close();
                    this.Close();
                    break;
                case 3:
                    if(Sot.IsChecked == true & Ad.IsChecked == false)
                    App.Connection.Open();
                    SqlCommand cmd15 = new SqlCommand("Insert into Сотрудник values (" + dn + ",'" + Login.Text + "','" + Password.Text + "','0')", App.Connection);
                    cmd15.ExecuteNonQuery();
                    App.Connection.Close();
                    this.Close();
                    break;
                    if(Ad.IsChecked == true & Sot.IsChecked ==false)
                    App.Connection.Open();
                    SqlCommand cmd14 = new SqlCommand("Insert into Сотрудник values (" + dn + ",'" + Login.Text + "','" + Password.Text + "','1')", App.Connection);
                    cmd14.ExecuteNonQuery();
                    App.Connection.Close();
                    this.Close();
                    break;
            }
        }
    }
}
