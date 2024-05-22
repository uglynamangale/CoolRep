using kursach1.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace kursach1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        String[] s1 = new String[20];
        String[] s2 = new String[20];
        String[] s3 = new String[20];
        String[] s4 = new String[20];
        public Main()
        {
            
            InitializeComponent();
            if (App.Role == false)
            {
                GoBack_Copy.Visibility = Visibility.Hidden;
                GoBack_Copy.IsEnabled = false;
            }
            if (App.Role == true)
            {
                GoBack_Copy.Visibility = Visibility.Visible;
                GoBack_Copy.IsEnabled = true;
            }
            Boot_up();
        }

        private void btn1(object sender, RoutedEventArgs e)
        {
            if (Vrooms.SelectedIndex == -1)
                return;
            Res.Zav n = (Res.Zav)Vrooms.SelectedItem;
            App.AHAHAHAHAHAH = n.ID;
            App.Needed = n.CompanyName;
            App.Needed2 = s4[n.ID-2];
            App.Needed3 = s2[n.ID-2];//3 9-2≠1, следовательно я дебил что такое разработал 
            App.Needed4 = s3[n.ID-2];
            App.Framer.Navigate(new Pages.MainEXT());
        }

        private void btn2(object sender, RoutedEventArgs e)
        {
            Small1 d = new Small1();
            d.Show();
        }
        async Task Boot_up()
        {
            try
            {
                const string emailAddress = "van913614@gmail.com";
                const string appPassword = "uhfb qzig mnav uqxs";

                int i = 0;
                int j = 0;
                int g = 0;
                int y = 0;
                string response;
                string name;
                string email;
                string title;
                string summary;
                XmlDocument xmlDocument = new XmlDocument();
                HttpClient httpClient = new HttpClient();
                
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{emailAddress}:{appPassword}")));
                
                response = await httpClient.GetStringAsync(@"https://mail.google.com/mail/feed/atom");
               
                response = response.Replace(@"<feed version=""0.3"" xmlns=""http://purl.org/atom/ns#"">", @"<feed>");
                
                xmlDocument.LoadXml(response);
               
                string nr = xmlDocument.SelectSingleNode(@"/feed/fullcount").InnerText;
                
                foreach (XmlNode node in xmlDocument.SelectNodes(@"/feed/entry/author"))
                {
                    name = node.SelectSingleNode("name").InnerText;
                   
                    s1[i] = name;
                    i++;
                    email = node.SelectSingleNode("email").InnerText;
                   
                    s2[j] = email;
                    j++;

                }
                i = 0;
                j = 0;
                App.Connection.Open();
                y = 2;
                App.Connection.Close();
                foreach (XmlNode node in xmlDocument.SelectNodes(@"/feed/entry"))
                {

                    title = node.SelectSingleNode("title").InnerText;
                    
                    s3[i] = title;
                    i++;
                    summary = node.SelectSingleNode("summary").InnerText;
                   
                    s4[j] = summary;
                    j++;

                }
                foreach (string a in s1)
                {
                    Res.Zav f = new Res.Zav(y, s1[g], s3[g], false);
                    g++;
                    y++;
                    Vrooms.Items.Add(f);
                }
                
            }
            catch
            {
                MessageBox.Show("Непредвиденная ошибка!");
            }
        }
        private void btn3(object sender, RoutedEventArgs e)
        {
            try
            {
                Vrooms.Items.Clear();
                Boot_up();
            }   
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            App.Framer.Navigate(new Pages.Welcome());
        }

        private void GoBack_Click2(object sender, RoutedEventArgs e)
        {
            App.Framer.Navigate(new Pages.PageAdminSecret());
        }
    }
}
