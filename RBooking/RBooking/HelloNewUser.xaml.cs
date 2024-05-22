using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Логика взаимодействия для HelloNewUser.xaml
    /// </summary>
    public partial class HelloNewUser : Window
    {
        string passport;
        List<RadioButton> rbtns;
        public HelloNewUser(string passport)
        {
            InitializeComponent();
            this.passport = passport;
            Psp.Text = $"Ваши серия и номер паспорта:\n{this.passport}";
            MessageBox.Show("Вы попали на окно регистрации, пожалуйста, введите данные для продолжения");
        }
        private void ContinueTB_Click(object sender, RoutedEventArgs e)
        {
            bool f = false;
            bool n = false;
            bool o = false;
            bool t = false;
            if(F.Text.All(x=>Char.IsLetter(x))
                && Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(F.Text) == F.Text)
            {
                f=true;
            }
            if (N.Text.All(x => Char.IsLetter(x))
                && Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(N.Text) == N.Text)
            {
                n = true;
            }
            if (O.Text.All(x => Char.IsLetter(x))
                && Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(O.Text) == O.Text)
            {
                o = true;
            }
            if (new Regex(@"^\+[7]-[9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]$").IsMatch(T.Text))
            {
                t = true;
            }
            if (f && n && o && t )
            {
                ContinueTB.IsEnabled = false;
                App.Connection.Open();
                SqlCommand cmd = new SqlCommand($"insert into Клиент values " +
                    $"((select max(Код_клиента)+1 from Клиент),'{F.Text}','{N.Text}','{O.Text}','{T.Text}',ENCRYPTBYASYMKEY( ASYMKEY_ID('Passport_Info'), N'{passport}'))", App.Connection);

                cmd.ExecuteNonQuery();


                cmd = new SqlCommand($"select dbo.Check_Client('{passport}')", App.Connection);

                var r = cmd.ExecuteReader();
                r.Read();
                App.User = r.GetValue(0).ToString();


                App.Connection.Close();

                new Chooser().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введённых данных");
            }
        }
    }
}
