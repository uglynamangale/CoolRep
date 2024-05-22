using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        public NotSmall3()
        {
            InitializeComponent();
        }
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            secretId++;
            if (secretId > 2)
                secretId = 0;
            switch (secretId)
            {
                case 0:
                    LSot1.IsEnabled = false;
                    LSot2.IsEnabled = false;
                    LSot3.IsEnabled = false;
                    LSot4.IsEnabled = false;
                    LSot5.IsEnabled = false;
                    LSot1.Visibility = Visibility.Hidden;
                    LSot2.Visibility = Visibility.Hidden;
                    LSot3.Visibility = Visibility.Hidden;
                    LSot4.Visibility = Visibility.Hidden;
                    LSot5.Visibility = Visibility.Hidden;
                    PhoneSot.IsEnabled = false;
                    RoleSot.IsEnabled = false;
                    NameSot.IsEnabled = false;
                    SurSot.IsEnabled = false;
                    PassSot.IsEnabled = false;
                    PhoneSot.Visibility = Visibility.Hidden;
                    RoleSot.Visibility = Visibility.Hidden;
                    NameSot.Visibility = Visibility.Hidden;
                    SurSot.Visibility = Visibility.Hidden;
                    PassSot.Visibility = Visibility.Hidden;
                    lCar1.Visibility = Visibility.Hidden; //машины
                    lCar2.Visibility = Visibility.Hidden;
                    lCar3.Visibility = Visibility.Hidden;
                    lCar4.Visibility = Visibility.Hidden;
                    lCar5.Visibility = Visibility.Hidden;
                    lCar1.IsEnabled = false;
                    lCar2.IsEnabled = false;
                    lCar3.IsEnabled = false;
                    lCar4.IsEnabled = false;
                    lCar5.IsEnabled = false;
                    yeah.Visibility = Visibility.Hidden;
                    no.Visibility = Visibility.Hidden;
                    Mod.Visibility = Visibility.Hidden;
                    Prob.Visibility = Visibility.Hidden;
                    Brand.Visibility = Visibility.Hidden;
                    Number.Visibility = Visibility.Hidden;
                    yeah.IsEnabled = false;
                    no.IsEnabled = false;
                    Mod.IsEnabled = false;
                    Prob.IsEnabled = false;
                    Brand.IsEnabled = false;
                    Number.IsEnabled = false;
                    namem.Content = "Водители";
                    LDrive1.IsEnabled = true;
                    LDrive2.IsEnabled = true;
                    LDrive3.IsEnabled = true;
                    LDrive4.IsEnabled = true;
                    LDrive5.IsEnabled = true;
                    LDrive1.Visibility = Visibility.Visible;
                    LDrive2.Visibility = Visibility.Visible;
                    LDrive3.Visibility = Visibility.Visible;
                    LDrive4.Visibility = Visibility.Visible;
                    LDrive5.Visibility = Visibility.Visible;
                    PravaDrive.Visibility = Visibility.Visible;
                    TelDrive.Visibility = Visibility.Visible;
                    PassDrive.Visibility = Visibility.Visible;
                    NameDrive.Visibility = Visibility.Visible;
                    SurDrive.Visibility = Visibility.Visible;
                    PravaDrive.IsEnabled = true;
                    TelDrive.IsEnabled = true;
                    PassDrive.IsEnabled = true;
                    NameDrive.IsEnabled = true;
                    SurDrive.IsEnabled = true;
                    break;
                case 1:
                    LSot1.IsEnabled = false;
                    LSot2.IsEnabled = false;
                    LSot3.IsEnabled = false;
                    LSot4.IsEnabled = false;
                    LSot5.IsEnabled = false;
                    LDrive1.IsEnabled = false;
                    LDrive2.IsEnabled = false;
                    LDrive3.IsEnabled = false;
                    LDrive4.IsEnabled = false;
                    LDrive5.IsEnabled = false;
                    PravaDrive.IsEnabled = false;
                    TelDrive.IsEnabled = false;
                    PassDrive.IsEnabled = false;
                    NameDrive.IsEnabled = false;
                    SurDrive.IsEnabled = false;
                    PhoneSot.IsEnabled = false;
                    RoleSot.IsEnabled = false;
                    NameSot.IsEnabled = false;
                    SurSot.IsEnabled = false;
                    PassSot.IsEnabled = false;
                    PhoneSot.Visibility = Visibility.Hidden;
                    RoleSot.Visibility = Visibility.Hidden;
                    NameSot.Visibility = Visibility.Hidden;
                    SurSot.Visibility = Visibility.Hidden;
                    PassSot.Visibility = Visibility.Hidden;
                    LSot1.Visibility = Visibility.Hidden;
                    LSot2.Visibility = Visibility.Hidden;
                    LSot3.Visibility = Visibility.Hidden;
                    LSot4.Visibility = Visibility.Hidden;
                    LSot5.Visibility = Visibility.Hidden;
                    LDrive1.Visibility = Visibility.Hidden;
                    LDrive2.Visibility = Visibility.Hidden;
                    LDrive3.Visibility = Visibility.Hidden;
                    LDrive4.Visibility = Visibility.Hidden;
                    LDrive5.Visibility = Visibility.Hidden;
                    RoleSot.Visibility = Visibility.Hidden;
                    PhoneSot.Visibility = Visibility.Hidden;
                    PassSot.Visibility= Visibility.Hidden;
                    NameSot.Visibility = Visibility.Hidden;
                    SurSot.Visibility = Visibility.Hidden;
                    PravaDrive.Visibility = Visibility.Hidden;
                    TelDrive.Visibility = Visibility.Hidden;
                    PassDrive.Visibility = Visibility.Hidden;
                    NameDrive.Visibility = Visibility.Hidden;
                    SurDrive.Visibility = Visibility.Hidden;
                    namem.Content = "Машины";
                    lCar1.Visibility = Visibility.Visible;
                    lCar2.Visibility = Visibility.Visible;
                    lCar3.Visibility = Visibility.Visible;
                    lCar4.Visibility = Visibility.Visible;
                    lCar5.Visibility = Visibility.Visible;
                    yeah.Visibility = Visibility.Visible;
                    no.Visibility = Visibility.Visible;
                    Mod.Visibility = Visibility.Visible;
                    Prob.Visibility = Visibility.Visible;
                    Brand.Visibility = Visibility.Visible;
                    Number.Visibility = Visibility.Visible;
                    lCar1.IsEnabled = true;
                    lCar2.IsEnabled = true;
                    lCar3.IsEnabled = true;
                    lCar4.IsEnabled = true;
                    lCar5.IsEnabled = true;
                    yeah.IsEnabled = true;
                    no.IsEnabled = true;
                    Mod.IsEnabled = true;
                    Prob.IsEnabled = true;
                    Brand.IsEnabled = true;
                    Number.IsEnabled = true;
                    break;
                case 2:
                    LDrive1.IsEnabled = false;
                    LDrive2.IsEnabled = false;
                    LDrive3.IsEnabled = false;
                    LDrive4.IsEnabled = false;
                    LDrive5.IsEnabled = false;
                    LDrive1.Visibility = Visibility.Hidden;
                    LDrive2.Visibility = Visibility.Hidden;
                    LDrive3.Visibility = Visibility.Hidden;
                    LDrive4.Visibility = Visibility.Hidden;
                    LDrive5.Visibility = Visibility.Hidden;
                    PravaDrive.Visibility = Visibility.Hidden;
                    TelDrive.Visibility = Visibility.Hidden;
                    PassDrive.Visibility = Visibility.Hidden;
                    NameDrive.Visibility = Visibility.Hidden;
                    SurDrive.Visibility = Visibility.Hidden;
                    PravaDrive.IsEnabled = false;
                    TelDrive.IsEnabled = false;
                    PassDrive.IsEnabled = false;
                    NameDrive.IsEnabled = false;
                    SurDrive.IsEnabled = false;
                    lCar1.Visibility = Visibility.Hidden; //машины
                    lCar2.Visibility = Visibility.Hidden;
                    lCar3.Visibility = Visibility.Hidden;
                    lCar4.Visibility = Visibility.Hidden;
                    lCar5.Visibility = Visibility.Hidden;
                    lCar1.IsEnabled = false;
                    lCar2.IsEnabled = false;
                    lCar3.IsEnabled = false;
                    lCar4.IsEnabled = false;
                    lCar5.IsEnabled = false;
                    yeah.Visibility = Visibility.Hidden;
                    no.Visibility = Visibility.Hidden;
                    Mod.Visibility = Visibility.Hidden;
                    Prob.Visibility = Visibility.Hidden;
                    Brand.Visibility = Visibility.Hidden;
                    Number.Visibility = Visibility.Hidden;
                    yeah.IsEnabled = false;
                    no.IsEnabled = false;
                    Mod.IsEnabled = false;
                    Prob.IsEnabled = false;
                    Brand.IsEnabled = false;
                    Number.IsEnabled = false;
                    namem.Content = "Сотрудники";
                    LSot1.IsEnabled = true;
                    LSot2.IsEnabled = true;
                    LSot3.IsEnabled = true;
                    LSot4.IsEnabled = true;
                    LSot5.IsEnabled = true;
                    LSot1.Visibility = Visibility.Visible;
                    LSot2.Visibility = Visibility.Visible;
                    LSot3.Visibility = Visibility.Visible;
                    LSot4.Visibility = Visibility.Visible;
                    LSot5.Visibility = Visibility.Visible;
                    PhoneSot.IsEnabled = true;
                    RoleSot.IsEnabled = true;
                    NameSot.IsEnabled = true;
                    SurSot.IsEnabled = true;
                    PassSot.IsEnabled = true;
                    PhoneSot.Visibility = Visibility.Visible;
                    RoleSot.Visibility = Visibility.Visible;
                    NameSot.Visibility = Visibility.Visible;
                    SurSot.Visibility = Visibility.Visible;
                    PassSot.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void LEft_Click(object sender, RoutedEventArgs e)
        {
            secretId--;
            if (secretId < 0)
                secretId = 2;
            switch (secretId)
            {
                case 0:
                    LSot1.IsEnabled = false;
                    LSot2.IsEnabled = false;
                    LSot3.IsEnabled = false;
                    LSot4.IsEnabled = false;
                    LSot5.IsEnabled = false;
                    LSot1.Visibility = Visibility.Hidden;
                    LSot2.Visibility = Visibility.Hidden;
                    LSot3.Visibility = Visibility.Hidden;
                    LSot4.Visibility = Visibility.Hidden;
                    LSot5.Visibility = Visibility.Hidden;
                    PhoneSot.IsEnabled = false;
                    RoleSot.IsEnabled = false;
                    NameSot.IsEnabled = false;
                    SurSot.IsEnabled = false;
                    PassSot.IsEnabled = false;
                    PhoneSot.Visibility = Visibility.Hidden;
                    RoleSot.Visibility = Visibility.Hidden;
                    NameSot.Visibility = Visibility.Hidden;
                    SurSot.Visibility = Visibility.Hidden;
                    PassSot.Visibility = Visibility.Hidden;
                    lCar1.Visibility = Visibility.Hidden; //машины
                    lCar2.Visibility = Visibility.Hidden;
                    lCar3.Visibility = Visibility.Hidden;
                    lCar4.Visibility = Visibility.Hidden;
                    lCar5.Visibility = Visibility.Hidden;
                    lCar1.IsEnabled = false;
                    lCar2.IsEnabled = false;
                    lCar3.IsEnabled = false;
                    lCar4.IsEnabled = false;
                    lCar5.IsEnabled = false;
                    yeah.Visibility = Visibility.Hidden;
                    no.Visibility = Visibility.Hidden;
                    Mod.Visibility = Visibility.Hidden;
                    Prob.Visibility = Visibility.Hidden;
                    Brand.Visibility = Visibility.Hidden;
                    Number.Visibility = Visibility.Hidden;
                    yeah.IsEnabled = false;
                    no.IsEnabled = false;
                    Mod.IsEnabled = false;
                    Prob.IsEnabled = false;
                    Brand.IsEnabled = false;
                    Number.IsEnabled = false;
                    namem.Content = "Водители";
                    LDrive1.IsEnabled = true;
                    LDrive2.IsEnabled = true;
                    LDrive3.IsEnabled = true;
                    LDrive4.IsEnabled = true;
                    LDrive5.IsEnabled = true;
                    LDrive1.Visibility = Visibility.Visible;
                    LDrive2.Visibility = Visibility.Visible;
                    LDrive3.Visibility = Visibility.Visible;
                    LDrive4.Visibility = Visibility.Visible;
                    LDrive5.Visibility = Visibility.Visible;
                    PravaDrive.Visibility = Visibility.Visible;
                    TelDrive.Visibility = Visibility.Visible;
                    PassDrive.Visibility = Visibility.Visible;
                    NameDrive.Visibility = Visibility.Visible;
                    SurDrive.Visibility = Visibility.Visible;
                    PravaDrive.IsEnabled = true;
                    TelDrive.IsEnabled = true;
                    PassDrive.IsEnabled = true;
                    NameDrive.IsEnabled = true;
                    SurDrive.IsEnabled = true;
                    break;
                case 1:
                    LSot1.IsEnabled = false;
                    LSot2.IsEnabled = false;
                    LSot3.IsEnabled = false;
                    LSot4.IsEnabled = false;
                    LSot5.IsEnabled = false;
                    LDrive1.IsEnabled = false;
                    LDrive2.IsEnabled = false;
                    LDrive3.IsEnabled = false;
                    LDrive4.IsEnabled = false;
                    LDrive5.IsEnabled = false;
                    PravaDrive.IsEnabled = false;
                    TelDrive.IsEnabled = false;
                    PassDrive.IsEnabled = false;
                    NameDrive.IsEnabled = false;
                    SurDrive.IsEnabled = false;
                    PhoneSot.IsEnabled = false;
                    RoleSot.IsEnabled = false;
                    NameSot.IsEnabled = false;
                    SurSot.IsEnabled = false;
                    PassSot.IsEnabled = false;
                    PhoneSot.Visibility = Visibility.Hidden;
                    RoleSot.Visibility = Visibility.Hidden;
                    NameSot.Visibility = Visibility.Hidden;
                    SurSot.Visibility = Visibility.Hidden;
                    PassSot.Visibility = Visibility.Hidden;
                    LSot1.Visibility = Visibility.Hidden;
                    LSot2.Visibility = Visibility.Hidden;
                    LSot3.Visibility = Visibility.Hidden;
                    LSot4.Visibility = Visibility.Hidden;
                    LSot5.Visibility = Visibility.Hidden;
                    LDrive1.Visibility = Visibility.Hidden;
                    LDrive2.Visibility = Visibility.Hidden;
                    LDrive3.Visibility = Visibility.Hidden;
                    LDrive4.Visibility = Visibility.Hidden;
                    LDrive5.Visibility = Visibility.Hidden;
                    RoleSot.Visibility = Visibility.Hidden;
                    PhoneSot.Visibility = Visibility.Hidden;
                    PassSot.Visibility = Visibility.Hidden;
                    NameSot.Visibility = Visibility.Hidden;
                    SurSot.Visibility = Visibility.Hidden;
                    PravaDrive.Visibility = Visibility.Hidden;
                    TelDrive.Visibility = Visibility.Hidden;
                    PassDrive.Visibility = Visibility.Hidden;
                    NameDrive.Visibility = Visibility.Hidden;
                    SurDrive.Visibility = Visibility.Hidden;
                    namem.Content = "Машины";
                    lCar1.Visibility = Visibility.Visible;
                    lCar2.Visibility = Visibility.Visible;
                    lCar3.Visibility = Visibility.Visible;
                    lCar4.Visibility = Visibility.Visible;
                    lCar5.Visibility = Visibility.Visible;
                    yeah.Visibility = Visibility.Visible;
                    no.Visibility = Visibility.Visible;
                    Mod.Visibility = Visibility.Visible;
                    Prob.Visibility = Visibility.Visible;
                    Brand.Visibility = Visibility.Visible;
                    Number.Visibility = Visibility.Visible;
                    lCar1.IsEnabled = true;
                    lCar2.IsEnabled = true;
                    lCar3.IsEnabled = true;
                    lCar4.IsEnabled = true;
                    lCar5.IsEnabled = true;
                    yeah.IsEnabled = true;
                    no.IsEnabled = true;
                    Mod.IsEnabled = true;
                    Prob.IsEnabled = true;
                    Brand.IsEnabled = true;
                    Number.IsEnabled = true;
                    break;
                case 2:
                    LDrive1.IsEnabled = false;
                    LDrive2.IsEnabled = false;
                    LDrive3.IsEnabled = false;
                    LDrive4.IsEnabled = false;
                    LDrive5.IsEnabled = false;
                    LDrive1.Visibility = Visibility.Hidden;
                    LDrive2.Visibility = Visibility.Hidden;
                    LDrive3.Visibility = Visibility.Hidden;
                    LDrive4.Visibility = Visibility.Hidden;
                    LDrive5.Visibility = Visibility.Hidden;
                    PravaDrive.Visibility = Visibility.Hidden;
                    TelDrive.Visibility = Visibility.Hidden;
                    PassDrive.Visibility = Visibility.Hidden;
                    NameDrive.Visibility = Visibility.Hidden;
                    SurDrive.Visibility = Visibility.Hidden;
                    PravaDrive.IsEnabled = false;
                    TelDrive.IsEnabled = false;
                    PassDrive.IsEnabled = false;
                    NameDrive.IsEnabled = false;
                    SurDrive.IsEnabled = false;
                    lCar1.Visibility = Visibility.Hidden; //машины
                    lCar2.Visibility = Visibility.Hidden;
                    lCar3.Visibility = Visibility.Hidden;
                    lCar4.Visibility = Visibility.Hidden;
                    lCar5.Visibility = Visibility.Hidden;
                    lCar1.IsEnabled = false;
                    lCar2.IsEnabled = false;
                    lCar3.IsEnabled = false;
                    lCar4.IsEnabled = false;
                    lCar5.IsEnabled = false;
                    yeah.Visibility = Visibility.Hidden;
                    no.Visibility = Visibility.Hidden;
                    Mod.Visibility = Visibility.Hidden;
                    Prob.Visibility = Visibility.Hidden;
                    Brand.Visibility = Visibility.Hidden;
                    Number.Visibility = Visibility.Hidden;
                    yeah.IsEnabled = false;
                    no.IsEnabled = false;
                    Mod.IsEnabled = false;
                    Prob.IsEnabled = false;
                    Brand.IsEnabled = false;
                    Number.IsEnabled = false;
                    namem.Content = "Сотрудники";
                    LSot1.IsEnabled = true;
                    LSot2.IsEnabled = true;
                    LSot3.IsEnabled = true;
                    LSot4.IsEnabled = true;
                    LSot5.IsEnabled = true;
                    LSot1.Visibility = Visibility.Visible;
                    LSot2.Visibility = Visibility.Visible;
                    LSot3.Visibility = Visibility.Visible;
                    LSot4.Visibility = Visibility.Visible;
                    LSot5.Visibility = Visibility.Visible;
                    PhoneSot.IsEnabled = true;
                    RoleSot.IsEnabled = true;
                    NameSot.IsEnabled = true;
                    SurSot.IsEnabled = true;
                    PassSot.IsEnabled = true;
                    PhoneSot.Visibility = Visibility.Visible;
                    RoleSot.Visibility = Visibility.Visible;
                    NameSot.Visibility = Visibility.Visible;
                    SurSot.Visibility = Visibility.Visible;
                    PassSot.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            switch (secretId)
            {
                case 0:
                    
                    int d = 0;
                    d = rnd.Next(1, 4829247);
                    App.Connection.Open();
                    SqlCommand cmd23 = new SqlCommand($"insert into Driver values ({d},'{NameDrive.Text}','{SurDrive.Text}','{PravaDrive.Text}','{TelDrive.Text}','{PassDrive.Password}')", App.Connection);
                    cmd23.ExecuteNonQuery();
                    App.Connection.Close();
                    this.Close();
                    break;
                case 1:
                    if (no.IsChecked == true)
                    {
                        App.Connection.Open();
                        SqlCommand cmd2 = new SqlCommand($"insert into Car values ('{Number.Text}','{Mod.Text}','{Brand.Text}','{Convert.ToInt32(Prob.Text)}','{DateTime.Now}')", App.Connection);
                        cmd2.ExecuteNonQuery();
                        App.Connection.Close();
                    }
                    if (yeah.IsChecked == true)
                    {
                        App.Connection.Open();
                        SqlCommand cmd3 = new SqlCommand($"insert into Car values ('{Number.Text}','{Mod.Text}','{Brand.Text}',0,'{DateTime.Now}') ", App.Connection);
                        cmd3.ExecuteNonQuery();
                        App.Connection.Close();
                    }

                    this.Close();
                    break;
                case 2:
                    int dn = 0;
                    dn = rnd.Next(1, 4829247);
                    App.Connection.Open();
                    SqlCommand cmd = new SqlCommand($"insert into Employee values ({dn},'{NameSot.Text}','{SurSot.Text}','{RoleSot.Text}','{PhoneSot.Text}',0,'{PassSot.Password}')", App.Connection);
                    cmd.ExecuteNonQuery();
                    App.Connection.Close();
                    this.Close();
                    break;
            }
        }

        private void no_Checked(object sender, RoutedEventArgs e)
        {
            if (no.IsChecked == false)
            {
                Prob.IsEnabled = false;

            }

        }

        private void yeah_Checked(object sender, RoutedEventArgs e)
        {
            if (yeah.IsChecked == false)
            {
                Prob.IsEnabled = true;

            }

        }
    }
}
