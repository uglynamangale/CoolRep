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
    /// Логика взаимодействия для UserBooks.xaml
    /// </summary>
    public partial class UserBooks : Window
    {
        public UserBooks()
        {
            InitializeComponent();
            BooksDisplay();
        }
        private void BooksDisplay()
        {
            BooksData.Items.Clear();
            List<BookInfo> books = new List<BookInfo>();
            App.Connection.Open();

            SqlCommand cmd = new SqlCommand($"select * from Бронь", App.Connection);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                books.Add(new BookInfo(r.GetValue(0).ToString(), r.GetValue(1).ToString(), r.GetValue(2).ToString(), r.GetValue(3).ToString()));
            }

            foreach
                (BookInfo book in books.Where(x => x.User == App.User).Select(x => x))
            {
                BooksData.Items.Add(book);
            }
            App.Connection.Close();
        }
        private void Drop_Click(object sender, RoutedEventArgs e)
        {
            if (BooksData.SelectedIndex == -1)
                return;
            App.Connection.Open();

            SqlCommand cmd = new SqlCommand($"delete from Бронь where Дата_брони = '{((BookInfo)BooksData.SelectedItem).Date}' and Код_клиента = {App.User}", App.Connection);

            cmd.ExecuteNonQuery();

            App.Connection.Close();

            MessageBox.Show("Бронь удалена из базы");

            BooksDisplay();
        }
    }
}
