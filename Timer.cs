using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace DigitalTimer

{
    public class Timer
    {
        public MainWindow mainWindow;
        public DispatcherTimer dispatcherTimer;

        int seconds = 55;
        int minutes = 59;
        int hours = 23;

        string ss;
        string mm;
        string hh;

        public Timer(MainWindow window)
        {
            mainWindow = window;

            dispatcherTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            dispatcherTimer.Tick += Timer_TickSub;
        }

        private void Timer_TickSub(object sender, EventArgs e)
        {
            seconds = seconds < 59 ? seconds + 1 : 0;
            ss = seconds < 10 ? $"0{seconds}" : seconds.ToString();

            minutes = seconds % 60 == 0 ? minutes + 1 : minutes;
            minutes = minutes < 60 ? minutes : 0;
            mm = minutes < 10 ? $"0{minutes}" : minutes.ToString();

            hours = seconds % 3600 == 0 ? hours + 1 : hours;
            hours = hours < 24 ? hours : 0;
            hh = hours < 10 ? $"0{hours}" : hours.ToString();

            mainWindow.LabelTimer.Content = $"{hh}:{mm}:{ss}";
        }

        public void Start()
        {
            dispatcherTimer.Start();
        }
        public void Stop()
        {
            dispatcherTimer.Stop();
        }

    }
}
