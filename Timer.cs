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
        private readonly DispatcherTimer dispatcherTimer;
        private DateTime startTime;

        private TimeSpan milliSecond;

        private string ms;

        public Timer(MainWindow window)
        {
            mainWindow = window;

            dispatcherTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 1) };
            dispatcherTimer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            milliSecond = DateTime.Now - startTime;
            ms = milliSecond.TotalMilliseconds.ToString("00:00:00:000");
            mainWindow.LabelTimer.Content = ms;
        }

        public void Start()
        {
            startTime = DateTime.Now;
            dispatcherTimer.Start();
        }
        public void Stop()
        {
            dispatcherTimer.Stop();
        }

        public string GetInterval()
        {
            return ms;
        }

    }
}
