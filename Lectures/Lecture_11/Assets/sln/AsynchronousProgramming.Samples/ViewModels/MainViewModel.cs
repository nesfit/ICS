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
using AsynchronousProgramming.Samples.Commands;

namespace AsynchronousProgramming.Samples.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
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
            PerformSomeHeavyWork().Wait();
            DataValue = 500;
        }

        private async void LoadDataAsynchronously()
        {
            await PerformSomeHeavyWork();
            DataValue = 1000;
        }
        private Task PerformSomeHeavyWork()
        {
            return Task.Delay(2000);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class Rootobject
    {
        public int[] data { get; set; }
    }

}
