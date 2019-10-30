using System;
using System.Timers;

namespace BlazorCrud.Client.Utils
{
    public class TimerService : IDisposable
    {
        public event Action OnStart;
        public event Action OnStop;

        private Timer _countDownTimer;
        private int _countDownSeconds;

        public TimerService(int seconds = 5)
        {
            _countDownSeconds = seconds;
        }

        protected virtual void Start()
        {
            OnStart?.Invoke();
            StartTimer();
        }

        private void Stop(object source, ElapsedEventArgs args)
        {
            OnStop?.Invoke();
        }

        private void InitTimer()
        {
            if (!(_countDownTimer is null)) return;
            (_countDownTimer ??= new Timer(_countDownSeconds * 1000)).Elapsed += Stop;
            _countDownTimer.AutoReset = false;
        }

        private void StartTimer()
        {
            InitTimer();
            if (_countDownTimer.Enabled)
                _countDownTimer.Stop();

            _countDownTimer.Start();
        }

        public void Dispose()
        {
            _countDownTimer?.Dispose();
        }
    }
}