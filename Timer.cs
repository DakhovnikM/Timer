using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;


namespace DigitalTimer
{
    public class Timer : INotifyPropertyChanged
    {
        private readonly DispatcherTimer dispatcherTimer;
        private DateTime startTime;

        private TimeSpan milliSecond;

        private string timerContent;
        public string TimerContent
        {
            get { return timerContent; }
            set
            {
                timerContent = value;
                OnPropertyChanged("TimerContent");
            }
        }

        public ObservableCollection<string> IntervalContent { get; }

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                //OnPropertyChanged("Count");
            }
        }

        private string ms;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public Command ClearCommand { get; }
        public Command GetIntervalCommand { get; }
        public Command StartCommand { get; }
        public Command StopCommand { get; }

        public Timer()
        {
            ClearCommand = new Command(ClearInterval);
            GetIntervalCommand = new Command(GetInterval);
            StartCommand = new Command(Start);
            StopCommand = new Command(Stop);

            IntervalContent = new ObservableCollection<string>();
            TimerContent = "00:00:00:000";
            dispatcherTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 1) };
            dispatcherTimer.Tick += Timer_Tick;
        }

        private void ClearInterval(object obj)
        {
            Count = 0;
            IntervalContent.Clear();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            milliSecond = DateTime.Now - startTime;
            ms = milliSecond.TotalMilliseconds.ToString("00:00:00:000", CultureInfo.InvariantCulture);
            TimerContent = ms;
        }

        public void Start(object obj)
        {
            startTime = DateTime.Now;
            dispatcherTimer.Start();
        }

        public void Stop(object obj)
        {
            dispatcherTimer.Stop();
        }

        public void GetInterval(object obj)
        {
            Count++;
            IntervalContent.Add($"{Count}. {ms}");
        }
    }
}