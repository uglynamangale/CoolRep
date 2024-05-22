using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Логика взаимодействия для Dishes.xaml
    /// </summary>
    public partial class Dishes : Window
    {
        List<Dish> dishes;
        public Dishes()
        {
            dishes = new List<Dish>();
            InitializeComponent();
            App.Connection.Open();
            SqlCommand cmd = new SqlCommand($"select * from Блюдо", App.Connection);
            var r = cmd.ExecuteReader();
            while(r.Read())
            {
                dishes.Add(new Dish(
                    r.GetString(0),
                    r.GetString(1),
                    r.GetString(2),
                    Convert.ToInt32(r.GetValue(3)),
                    r.GetInt32(4),
                    Convert.ToInt32(r.GetValue(5))));
            }
            DisplayDishes(dishes);
            Category.Items.Add("Все");
            foreach(var value in dishes.Select(x => x.Category).Distinct().ToList())
            {
                Category.Items.Add(value);
            }
            Category.SelectedIndex=0;
            App.Connection.Close();
        }
        private void DisplayDishes(List<Dish> dishes)
        {
            Dishes_CB.ItemsSource = dishes.Select(x=>x.Name);
        }

        private void Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Category.SelectedIndex == -1)
                return;
            if (Category.SelectedIndex == 0)
            {
                DisplayDishes(dishes);
                return;
            }

            List<Dish> temp_dishes = dishes.Where(x=>x.Category == Category.SelectedItem.ToString()).Select(x => x).ToList();
            DisplayDishes(temp_dishes);
        }

        private void AddToService_Click(object sender, RoutedEventArgs e)
        {
            if (Dishes_CB.SelectedIndex == -1)
                return;
            DishesDataGrid.Items.Add(dishes.Where(x=>x.Name == Dishes_CB.SelectedItem.ToString()).Select(x=>x).FirstOrDefault());
            PriceCount();
        }

        private void DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (DishesDataGrid.SelectedIndex == -1)
                return;
            DishesDataGrid.Items.RemoveAt(DishesDataGrid.SelectedIndex);
            PriceCount();
        }

        private void PriceCount()
        {
            int price = 0;
            foreach(Dish r in DishesDataGrid.Items)
            {
                price += r.Price;
            }
            
            Check.Text = $"Общая стоимость {price}";
        }

        private void AdditionalServices_Click(object sender, RoutedEventArgs e)
        {
            if (DishesDataGrid.Items.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одну позицию");
                return;
            }
            App.All_Dishes.Clear();
            List<Dish> dishes = new List<Dish>();
            foreach (Dish r in DishesDataGrid.Items)
            {
                App.All_Dishes.Add(r.Name);
            }
            App.FullPrice += Convert.ToInt32(Check.Text.Split().Last());
            new FinalWindow().Show();
            this.Close();
        }
    }
}
