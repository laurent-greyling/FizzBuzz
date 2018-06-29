using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace FizzBuzz.ViewModels
{
    public class PrintNumbersViewModel : INotifyPropertyChanged
    {
        public int _number { get; set; } = 1;

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        public PrintNumbersViewModel()
        {
            SetNumber();
        }

        private void SetNumber()
        {
            var timer = new Timer
            {
                Interval = 10000
            };

            timer.Elapsed += UpdateNumber;
            timer.Start();

            if (Number == 100)
            {
                timer.Stop();
            }
        }

        private void UpdateNumber(object sender, ElapsedEventArgs e)
        {
            if (Number != 100)
            {
                Number++;
            }         
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
