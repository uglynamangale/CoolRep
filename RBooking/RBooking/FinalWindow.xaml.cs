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

namespace RBooking
{
    /// <summary>
    /// Логика взаимодействия для FinalWindow.xaml
    /// </summary>
    public partial class FinalWindow : Window
    {
        List<CheckBox> CheckBoxes;
        List<TextBlock> TextBlockes;
        List<Service> services = new List<Service>();
        public FinalWindow()
        {
            InitializeComponent();
            App.Connection.Open();

            SqlCommand cmd = new SqlCommand($"select * from Услуга",App.Connection);
            CheckBoxes = new List<CheckBox>() { S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13, S14, S15, S16, S17, S18, S19, S20, S21, S22, S23, S24 };
            TextBlockes = new List<TextBlock>() { SP1, SP2, SP3, SP4, SP5, SP6, SP7, SP8, SP9, SP10, SP11, SP12, SP13, SP14, SP15, SP16, SP17, SP18, SP19, SP20, SP21, SP22, SP23, SP24 };
            foreach (var cb in CheckBoxes)
            {
                cb.Visibility = Visibility.Hidden;
            }
            foreach (var cb in TextBlockes)
            {
                cb.Visibility = Visibility.Hidden;
            }
            var r = cmd.ExecuteReader();

            while(r.Read())
            {
                services.Add(new Service(r.GetString(0),r.GetString(1),r.GetInt32(2),Convert.ToInt32(r.GetValue(3))));
            }

            for(int i = 0; i < services.Count; i++)
            {
                CheckBoxes[i].Visibility=Visibility.Visible;
                TextBlockes[i].Visibility = Visibility.Visible;

                CheckBoxes[i].Content = services[i].Name.ToString();
                TextBlockes[i].Text = $"{services[i].Price} руб.";
            }
            App.Connection.Close();
        }

        private void BookAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < services.Count; i++)
            {
                if (CheckBoxes[i].IsChecked == true && CheckBoxes[i].Visibility==Visibility.Visible)
                {
                    App.All_Services.Add(CheckBoxes[i].Content.ToString());
                    App.FullPrice += Convert.ToInt32(TextBlockes[i].Text.Split()[0]);
                }
            }
            App.Book();
            MessageBox.Show($"Ваша бронь занесена базу, итоговая сумма составляет {App.FullPrice} руб.");
            Application.Current.Shutdown();
        }
    }
}
