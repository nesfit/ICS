using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AsynchronousProgramming.Samples.Annotations;
using Microsoft.Toolkit.Mvvm.Input;

namespace AsynchronousProgramming.Samples.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int dataValue;

        public int DataValue
        {
            get => dataValue;
            set
            {
                if (dataValue == value)
                {
                    return;
                }
                dataValue = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataAsynchronouslyCommand { get; }
        public ICommand LoadDataSynchronouslyCommand { get; }

        public MainViewModel()
        {
            LoadDataAsynchronouslyCommand = new RelayCommand(LoadDataAsynchronously);
            LoadDataSynchronouslyCommand = new RelayCommand(LoadDataSynchronously);
        }

        private void LoadDataSynchronously()
        {
            // Without Task.Run to spawn Async operation on different thread, the continuation would not run and UI thread would wait for result indefinitely causing deadlock
            //DataValue = PerformSomeHeavyWorkAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            DataValue = Task.Run(async () => await PerformSomeHeavyWorkAsync()).GetAwaiter().GetResult();

            // Never ever use .Wait(), or .Result on async methods... always .GetAwaiter().GetResult()
        }

        private async void LoadDataAsynchronously() => DataValue = await PerformSomeHeavyWorkAsync();

        private readonly Random random = new();
        private async Task<int> PerformSomeHeavyWorkAsync()
        {
            var randomWaitIntervalSimulatingHeavyWork = random.Next(100, 2000);
            await Task.Delay(randomWaitIntervalSimulatingHeavyWork);
            return randomWaitIntervalSimulatingHeavyWork;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
