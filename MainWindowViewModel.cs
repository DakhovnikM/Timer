﻿
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace TimerWPF;

public class MainWindowViewModel : INotifyPropertyChanged
{
    #region Fields
    private DateTime startTime;

    private TimeSpan milliSecond;

    private double ms;

    private string timerContent;
    #endregion

    #region Properties
    private DispatcherTimer DispatcherTimer { get; }

    public string TimerContent
    {
        get { return timerContent; }
        set
        {
            timerContent = value;
            OnPropertyChanged("TimerContent");
        }
    }

    private int Count { get; set; }

    private double Difference { get; set; }

    public ObservableCollection<string> IntervalContent { get; }
    #endregion

    #region BtnIsEnabled
    private bool btnStopIsEnabled;
    public bool BtnStopIsEnabled
    {
        get { return btnStopIsEnabled; }
        set
        {
            btnStopIsEnabled = value;
            OnPropertyChanged("BtnStopIsEnabled");
        }
    }

    private bool btnStartIsEnabled;
    public bool BtnStartIsEnabled
    {
        get { return btnStartIsEnabled; }
        set
        {
            btnStartIsEnabled = value;
            OnPropertyChanged("BtnStartIsEnabled");
        }
    }

    private bool btnIntervalIsEnabled;
    public bool BtnIntervalIsEnabled
    {
        get { return btnIntervalIsEnabled; }
        set
        {
            btnIntervalIsEnabled = value;
            OnPropertyChanged("BtnIntervalIsEnabled");
        }
    }

    private bool btnClearIsEnabled;
    public bool BtnClearIsEnabled
    {
        get { return btnClearIsEnabled; }
        set
        {
            btnClearIsEnabled = value;
            OnPropertyChanged("BtnClearIsEnabled");
        }
    }
    #endregion

    #region INotifyProp
    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string prop = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    #endregion

    #region Commands
    public Command ClearCommand { get; }
    public Command GetIntervalCommand { get; }
    public Command StartCommand { get; }
    public Command StopCommand { get; }
    #endregion

    #region Ctor
    public MainWindowViewModel()
    {
        ClearCommand = new Command(ClearInterval);
        GetIntervalCommand = new Command(GetInterval);
        StartCommand = new Command(Start);
        StopCommand = new Command(Stop);

        IntervalContent = new ObservableCollection<string>();
        TimerContent = "00:00:00:000";
        DispatcherTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 1) };
        DispatcherTimer.Tick += Timer_Tick;

        BtnStartIsEnabled = true;
    }
    #endregion

    private void ClearInterval(object obj)
    {
        Count = 0;
        IntervalContent.Clear();
        BtnClearIsEnabled = false;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        milliSecond = DateTime.Now - startTime;
        ms = milliSecond.TotalMilliseconds;
        TimerContent = ms.ToString("00:00:00:000", CultureInfo.InvariantCulture);
    }

    public void Start(object obj)
    {
        startTime = DateTime.Now;
        DispatcherTimer.Start();
        BtnStopIsEnabled = true;
        BtnIntervalIsEnabled = true;
        BtnStartIsEnabled = false;
    }

    public void Stop(object obj)
    {
        DispatcherTimer.Stop();
        BtnStartIsEnabled = true;
        BtnStopIsEnabled = false;
        BtnIntervalIsEnabled = false;
    }

    public void GetInterval(object obj)
    {
        Count++;
        BtnClearIsEnabled = true;

        var res = Count == 1
            ? "00:00:000"
            : (ms - Difference).ToString("00:00:000", CultureInfo.InvariantCulture);

        IntervalContent.Add($"{Count}. {TimerContent}  (+{res})");
        Difference = ms;
    }
}
