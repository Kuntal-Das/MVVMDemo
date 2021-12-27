using System;
using System.ComponentModel;
using System.Text;

namespace MVVMDemo.Models
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string FullName => $"{FirstName} {LastName}";
        public Person() { }
        public Person(Person person)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        private string _fName;
        public string FirstName
        {
            get { return _fName; }
            set
            {
                _fName = value;
                OnPropChange("FirstName");
                OnPropChange("FullName");
            }
        }

        private string _lName;
        public string LastName
        {
            get { return _lName; }
            set
            {
                _lName = value;
                OnPropChange("LastName");
                OnPropChange("FullName");
            }
        }

        public string FullName => $"{FirstName} {LastName}".Trim();

        public DateTime DateAdded { get; set; }


        //IDataErrorInfo
        public string Error => null;

        public string this[string PropName]
        {
            get
            {
                string result = String.Empty;
                switch (PropName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(this.FirstName)) result = "First Name is Required";
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(this.LastName)) result = "Last Name is Required";
                        break;
                }
                return result.ToString();
            }

        }


        //INotifyChangedProperty
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropChange(string propName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
