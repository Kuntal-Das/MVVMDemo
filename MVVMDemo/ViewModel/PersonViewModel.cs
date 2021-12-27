using MVVMDemo.Commands;
using MVVMDemo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMDemo.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;

        public Person PersonProp
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropChange("Person");
            }
        }

        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { _people = value; OnPropChange("People"); }
        }

        private ICommand _submitCommand;

        public ICommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _submitCommand;
            }
            set { _submitCommand = value; }
        }

        public PersonViewModel()
        {
            PersonProp = new Person();
            People = new ObservableCollection<Person>();
        }


        private void SubmitExecute(object obj) => People.Add(new Person(PersonProp));
        private bool CanSubmitExecute(object arg) =>
            !(string.IsNullOrEmpty(PersonProp.FirstName) || string.IsNullOrEmpty(PersonProp.LastName));

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropChange(string propName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
