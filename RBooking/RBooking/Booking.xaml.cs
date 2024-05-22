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
    /// Логика взаимодействия для Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        List<CheckBox> hbtns;
        List<CheckBox> tbtns;
        List<Label> Hall_Lables;
        List<Label> People_Lables;
        List<Label> Price_Lables;
        List<Table> tables = new List<Table>();
        public Booking()
        {
            InitializeComponent();
            hbtns = new List<CheckBox>() {Z1,Z2,Z3,Z4,Z5,Z6,Z7,Z8,Z9,Z10 };
            tbtns = new List<CheckBox>() { T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150 };
            Hall_Lables = new List<Label>() { TL1_Hall, TL2_Hall, TL3_Hall, TL4_Hall, TL5_Hall, TL6_Hall, TL7_Hall, TL8_Hall, TL9_Hall, TL10_Hall, TL11_Hall, TL12_Hall, TL13_Hall, TL14_Hall, TL15_Hall, TL16_Hall, TL17_Hall, TL18_Hall, TL19_Hall, TL20_Hall, TL21_Hall, TL22_Hall, TL23_Hall, TL24_Hall, TL25_Hall, TL26_Hall, TL27_Hall, TL28_Hall, TL29_Hall, TL30_Hall, TL31_Hall, TL32_Hall, TL33_Hall, TL34_Hall, TL35_Hall, TL36_Hall, TL37_Hall, TL38_Hall, TL39_Hall, TL40_Hall, TL41_Hall, TL42_Hall, TL43_Hall, TL44_Hall, TL45_Hall, TL46_Hall, TL47_Hall, TL48_Hall, TL49_Hall, TL50_Hall, TL51_Hall, TL52_Hall, TL53_Hall, TL54_Hall, TL55_Hall, TL56_Hall, TL57_Hall, TL58_Hall, TL59_Hall, TL60_Hall, TL61_Hall, TL62_Hall, TL63_Hall, TL64_Hall, TL65_Hall, TL66_Hall, TL67_Hall, TL68_Hall, TL69_Hall, TL70_Hall, TL71_Hall, TL72_Hall, TL73_Hall, TL74_Hall, TL75_Hall, TL76_Hall, TL77_Hall, TL78_Hall, TL79_Hall, TL80_Hall, TL81_Hall, TL82_Hall, TL83_Hall, TL84_Hall, TL85_Hall, TL86_Hall, TL87_Hall, TL88_Hall, TL89_Hall, TL90_Hall, TL91_Hall, TL92_Hall, TL93_Hall, TL94_Hall, TL95_Hall, TL96_Hall, TL97_Hall, TL98_Hall, TL99_Hall, TL100_Hall, TL101_Hall, TL102_Hall, TL103_Hall, TL104_Hall, TL105_Hall, TL106_Hall, TL107_Hall, TL108_Hall, TL109_Hall, TL110_Hall, TL111_Hall, TL112_Hall, TL113_Hall, TL114_Hall, TL115_Hall, TL116_Hall, TL117_Hall, TL118_Hall, TL119_Hall, TL120_Hall, TL121_Hall, TL122_Hall, TL123_Hall, TL124_Hall, TL125_Hall, TL126_Hall, TL127_Hall, TL128_Hall, TL129_Hall, TL130_Hall, TL131_Hall, TL132_Hall, TL133_Hall, TL134_Hall, TL135_Hall, TL136_Hall, TL137_Hall, TL138_Hall, TL139_Hall, TL140_Hall, TL141_Hall, TL142_Hall, TL143_Hall, TL144_Hall, TL145_Hall, TL146_Hall, TL147_Hall, TL148_Hall, TL149_Hall, TL150_Hall };
            People_Lables = new List<Label>() {TL1_People,TL2_People,TL3_People,TL4_People,TL5_People,TL6_People,TL7_People,TL8_People,TL9_People,TL10_People,TL11_People,TL12_People,TL13_People,TL14_People,TL15_People,TL16_People,TL17_People,TL18_People,TL19_People,TL20_People,TL21_People,TL22_People,TL23_People,TL24_People,TL25_People,TL26_People,TL27_People,TL28_People,TL29_People,TL30_People,TL31_People,TL32_People,TL33_People,TL34_People,TL35_People,TL36_People,TL37_People,TL38_People,TL39_People,TL40_People,TL41_People,TL42_People,TL43_People,TL44_People,TL45_People,TL46_People,TL47_People,TL48_People,TL49_People,TL50_People,TL51_People,TL52_People,TL53_People,TL54_People,TL55_People,TL56_People,TL57_People,TL58_People,TL59_People,TL60_People,TL61_People,TL62_People,TL63_People,TL64_People,TL65_People,TL66_People,TL67_People,TL68_People,TL69_People,TL70_People,TL71_People,TL72_People,TL73_People,TL74_People,TL75_People,TL76_People,TL77_People,TL78_People,TL79_People,TL80_People,TL81_People,TL82_People,TL83_People,TL84_People,TL85_People,TL86_People,TL87_People,TL88_People,TL89_People,TL90_People,TL91_People,TL92_People,TL93_People,TL94_People,TL95_People,TL96_People,TL97_People,TL98_People,TL99_People,TL100_People,TL101_People,TL102_People,TL103_People,TL104_People,TL105_People,TL106_People,TL107_People,TL108_People,TL109_People,TL110_People,TL111_People,TL112_People,TL113_People,TL114_People,TL115_People,TL116_People,TL117_People,TL118_People,TL119_People,TL120_People,TL121_People,TL122_People,TL123_People,TL124_People,TL125_People,TL126_People,TL127_People,TL128_People,TL129_People,TL130_People,TL131_People,TL132_People,TL133_People,TL134_People,TL135_People,TL136_People,TL137_People,TL138_People,TL139_People,TL140_People,TL141_People,TL142_People,TL143_People,TL144_People,TL145_People,TL146_People,TL147_People,TL148_People,TL149_People,TL150_People };
            Price_Lables = new List<Label>() { TL1_Price, TL2_Price, TL3_Price, TL4_Price, TL5_Price, TL6_Price, TL7_Price, TL8_Price, TL9_Price, TL10_Price, TL11_Price, TL12_Price, TL13_Price, TL14_Price, TL15_Price, TL16_Price, TL17_Price, TL18_Price, TL19_Price, TL20_Price, TL21_Price, TL22_Price, TL23_Price, TL24_Price, TL25_Price, TL26_Price, TL27_Price, TL28_Price, TL29_Price, TL30_Price, TL31_Price, TL32_Price, TL33_Price, TL34_Price, TL35_Price, TL36_Price, TL37_Price, TL38_Price, TL39_Price, TL40_Price, TL41_Price, TL42_Price, TL43_Price, TL44_Price, TL45_Price, TL46_Price, TL47_Price, TL48_Price, TL49_Price, TL50_Price, TL51_Price, TL52_Price, TL53_Price, TL54_Price, TL55_Price, TL56_Price, TL57_Price, TL58_Price, TL59_Price, TL60_Price, TL61_Price, TL62_Price, TL63_Price, TL64_Price, TL65_Price, TL66_Price, TL67_Price, TL68_Price, TL69_Price, TL70_Price, TL71_Price, TL72_Price, TL73_Price, TL74_Price, TL75_Price, TL76_Price, TL77_Price, TL78_Price, TL79_Price, TL80_Price, TL81_Price, TL82_Price, TL83_Price, TL84_Price, TL85_Price, TL86_Price, TL87_Price, TL88_Price, TL89_Price, TL90_Price, TL91_Price, TL92_Price, TL93_Price, TL94_Price, TL95_Price, TL96_Price, TL97_Price, TL98_Price, TL99_Price, TL100_Price, TL101_Price, TL102_Price, TL103_Price, TL104_Price, TL105_Price, TL106_Price, TL107_Price, TL108_Price, TL109_Price, TL110_Price, TL111_Price, TL112_Price, TL113_Price, TL114_Price, TL115_Price, TL116_Price, TL117_Price, TL118_Price, TL119_Price, TL120_Price, TL121_Price, TL122_Price, TL123_Price, TL124_Price, TL125_Price, TL126_Price, TL127_Price, TL128_Price, TL129_Price, TL130_Price, TL131_Price, TL132_Price, TL133_Price, TL134_Price, TL135_Price, TL136_Price, TL137_Price, TL138_Price, TL139_Price, TL140_Price, TL141_Price, TL142_Price, TL143_Price, TL144_Price, TL145_Price, TL146_Price, TL147_Price, TL148_Price, TL149_Price, TL150_Price};
            foreach (var cb in hbtns)
            {
                cb.Visibility = Visibility.Hidden;
            }
            Processing_TextChanged(null, null);
            Show_Tables(null);

            App.Connection.Open();
            SqlCommand cmd = new SqlCommand($"select * from Стол order by Номер_зала,Номер_стола", App.Connection);

            var r = cmd.ExecuteReader();

            while(r.Read())
            {
                tables.Add(new Table(r.GetInt32(0), r.GetInt32(1), r.GetInt32(2), r.GetDouble(3)));
            }
            r.Close();

            cmd = new SqlCommand($"select distinct Номер_зала from Стол order by Номер_зала", App.Connection);

            r = cmd.ExecuteReader();

            List<int> Halls = new List<int>();
            while (r.Read())
            {
                Halls.Add(r.GetInt32(0));
            }
            for(int i = 0; i < Halls.Count;i++)
            {
                hbtns[i].Content = $"Зал {Halls[i]}";
                hbtns[i].Visibility = Visibility.Visible;
            }
            App.Connection.Close();
        }

        private void Z_Checked(object sender, RoutedEventArgs e)
        {
            List<int> Halls = new List<int>();
            foreach (var r in hbtns)
            {
                Halls = hbtns.Where(x => x.IsChecked == true).Select(x => Convert.ToInt32(x.Content.ToString().Split().Last())).ToList();
            }
            var temp_tables = tables.Where(x => Halls.Contains(x.Hall_Num)).Select(x => x).ToList();
            Show_Tables(temp_tables);
            T_Click(null, null);
        }
        private void Show_Tables(List<Table> tables)
        {
            foreach (var cb in tbtns)
            {
                cb.Visibility = Visibility.Hidden;
            }
            foreach (var lbl in Hall_Lables)
            {
                lbl.Visibility = Visibility.Hidden;
            }
            foreach (var lbl in People_Lables)
            {
                lbl.Visibility = Visibility.Hidden;
            }
            foreach (var lbl in Price_Lables)
            {
                lbl.Visibility = Visibility.Hidden;
            }
            if (tables == null)
                return;
            for (int i = 0; i < tables.Count; i++)
            {
                tbtns[i].Content = "Стол " + tables[i].Table_Num;
                Hall_Lables[i].Content = "Зал " + tables[i].Hall_Num;
                People_Lables[i].Content = tables[i].People + " чел.";
                Price_Lables[i].Content = tables[i].Price + " руб./час";

                tbtns[i].Visibility = Visibility.Visible;
                Hall_Lables[i].Visibility = Visibility.Visible;
                People_Lables[i].Visibility = Visibility.Visible;
                Price_Lables[i].Visibility = Visibility.Visible;


            }
            MainPanel.Height = tables.Count * 40;
        }

        private void T_Click(object sender, RoutedEventArgs e)
        {
            if(Processing.Text == "")
            {
                return;
            }
            int people = 0;
            int price = 0;
            for(int i = 0; i < tbtns.Count;i++) 
            {
                if (tbtns[i].Visibility == Visibility.Hidden)
                    break;
                if (tbtns[i].IsChecked == false)
                    continue;
                people += Convert.ToInt32(People_Lables[i].Content.ToString().Split()[0]);
                price += Convert.ToInt32(Price_Lables[i].Content.ToString().Split()[0]);
            }
            try
            {
                Check.Text = $"Общая стоимость составляет {price*Math.Ceiling(Convert.ToInt32(Processing.Text)/60.0)} руб. для {people} человек";
            }
            catch
            {

            }
            App.FullPrice = price * Math.Ceiling(Convert.ToInt32(Processing.Text) / 60.0);
        }

        private void Processing_TextChanged(object sender, TextChangedEventArgs e)
        {
            T_Click(null, null);
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            List<Table> Tables_For_Booking = new List<Table>();
            if (Date.Text == "" || Time.Text == "")
                return;
            try
            {
                Convert.ToInt32(Processing.Text);
            }
            catch
            {
                MessageBox.Show("Некорректная длительность брони");
                return;
            }
            try
            {
                App.Connection.Open();

                for (int i = 0; i < tbtns.Count; i++)
                {
                    if (tbtns[i].Visibility == Visibility.Hidden)
                        break;

                    if (tbtns[i].IsChecked == true)
                    {
                        SqlCommand cmd = new SqlCommand($"select dbo.Check_Table({tbtns[i].Content.ToString().Split()[1]},{Hall_Lables[i].Content.ToString().Split()[1]}," +
                            $"'{Date.Text}','{Time.Text}',{Processing.Text})", App.Connection);

                        var r = cmd.ExecuteReader();

                        r.Read();
                        if (r.GetInt32(0) != 0)
                        {
                            MessageBox.Show($"Столик {tbtns[i].Content.ToString().Split()[1]}, {Hall_Lables[i].Content} в выбранный временной промежуток занят\n" +
                                $"Выберите другое время или исключите столик из брони");
                            App.Connection.Close();
                            return;
                        }
                        r.Close();
                        Tables_For_Booking.Add(
                            new Table(
                                Convert.ToInt32(tbtns[i].Content.ToString().Split()[1]),
                                Convert.ToInt32(Hall_Lables[i].Content.ToString().Split()[1]),
                                Convert.ToInt32(People_Lables[i].Content.ToString().Split()[0]),
                                Convert.ToDouble(Price_Lables[i].Content.ToString().Split()[0])
                                )
                            );
                    }
                }
                if(Tables_For_Booking.Count < 1)
                {
                    MessageBox.Show("Выберите хотя бы один столик");
                }
                App.Connection.Close();
                App.Date = Date.Text;
                App.StartTime = Time.Text;
                App.Time = Processing.Text;
                App.All_Tables = Tables_For_Booking;
                new Dishes().Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка, повторите попытку");
                App.Connection.Close();
            }

        }
    }
}
