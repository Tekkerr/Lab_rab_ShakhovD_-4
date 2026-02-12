using System;
using System.Windows;
using System.Windows.Input;

namespace Lab_rab_ShakhovD_Вариант4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMinutes_Click(object sender, RoutedEventArgs e)
        {
            TimeData time;
            if (!TryGetTime(out time))
                return;

            TbResult.Text = time.GetFullMinutes().ToString();
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            TimeData time;
            if (!TryGetTime(out time))
                return;

            time.MinusTenMinutes();
            TbResult.Text = time.Hours + ":" + time.Minutes + ":" + time.Seconds;
        }

        private bool TryGetTime(out TimeData time)
        {
            time = new TimeData();

            int h, m, s;

            if (!int.TryParse(TbHours.Text, out h) ||
                !int.TryParse(TbMinutes.Text, out m) ||
                !int.TryParse(TbSeconds.Text, out s))
            {
                MessageBox.Show("Ошибка ввода");
                return false;
            }

            if (h < 0 || h > 23 || m < 0 || m > 59 || s < 0 || s > 59)
            {
                MessageBox.Show("Некорректное время");
                return false;
            }

            time.Hours = h;
            time.Minutes = m;
            time.Seconds = s;

            return true;
        }

        private void NumberOnly(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
                e.Handled = true;
        }

        private void NoSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
    }
}
