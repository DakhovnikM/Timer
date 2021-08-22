using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigitalTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer timer;
        private int count;

        public MainWindow()
        {
            InitializeComponent();
            timer = new Timer();
            DataContext = timer;
            //BtnStop.IsEnabled = false;
            //BtnInterval.IsEnabled = false;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            //timer.Start();
            //BtnStart.IsEnabled = false;
            //BtnStop.IsEnabled = true;
            //BtnInterval.IsEnabled = true;

        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            //timer.Stop();
            //BtnStart.IsEnabled = true;
            //BtnStop.IsEnabled = false;
            //BtnInterval.IsEnabled = false;
        }

        private void BtnInterval_Click(object sender, RoutedEventArgs e)
        {
            //count++;
            //LabelInterval.Content += $"{count}. {timer.GetInterval()}\n";

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            //count = 0;
            //LabelInterval.Content = "";
        }
    }
}
