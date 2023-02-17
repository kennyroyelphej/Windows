using System.Windows.Input;

namespace WPF_MVVM_Example.ViewModel
{
    public class GreetingViewModel : ViewModelBase
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string greeting = string.Empty;

        public ICommand? CmdClickMe { get; set; }

        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }
        public string LastName 
        {
            get { return lastName; } 
            set { lastName = value; OnPropertyChanged(nameof(LastName)); } 
        }
        public string Greeting
        {
            get { return greeting; }
            set { greeting = value; OnPropertyChanged(nameof(Greeting)); }
        }

        public GreetingViewModel()
        {
            CmdClickMe = new ViewModelCommand(SayGreeting, () => CanExecuteSayGreetings);
        }

        public bool CanExecuteSayGreetings
        {
            get { return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName); }
        }

        private void SayGreeting()
        {
            Greeting = "Hello " + FirstName + " " + LastName;
        }
    }
}
