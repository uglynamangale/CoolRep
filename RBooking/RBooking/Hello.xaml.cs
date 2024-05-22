using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RBooking
{
    /// <summary>
    /// Логика взаимодействия для Hello.xaml
    /// </summary>
    public partial class Hello : Window
    {
        public Hello()
        {
            InitializeComponent();
        }

        private void ContinueTB_Click(object sender, RoutedEventArgs e)
        {
            if(
                PassportTB1.Text.Length == 2 && PassportTB1.Text.All(x => Char.IsDigit(x))&&
                PassportTB2.Text.Length == 2 && PassportTB1.Text.All(x => Char.IsDigit(x))&&
                PassportTB3.Text.Length == 6 && PassportTB1.Text.All(x => Char.IsDigit(x))
                )
            {
                App.Connection.Open();
                SqlCommand cmd = new SqlCommand($"select dbo.Check_Client('{PassportTB1.Text}{PassportTB2.Text}{PassportTB3.Text}')", App.Connection);

                var r = cmd.ExecuteReader();
                r.Read();
                if(r.GetValue(0).ToString() == "0")
                {
                    new HelloNewUser($"{PassportTB1.Text}{PassportTB2.Text}{PassportTB3.Text}").Show();
                }
                else
                {
                    App.User = r.GetValue(0).ToString();
                    new Chooser().Show();
                }
                App.Connection.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введённых данных");
            }
        }
    }
}
