using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public enum CivilState { Unknown, Single, Married };

    public class Employee //: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Employee() { }
        public Employee(String firstName, String lastName,  CivilState civilState)
        {
            FirstName = firstName;
            LastName = lastName;
            CivilState = civilState;
        }

        private String _firstName;
        private String _lastName;
        private CivilState _civilState;

        public String FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == _firstName)
                {
                    return;
                }
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public String LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == _lastName)
                {
                    return;
                }
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public CivilState CivilState
        {
            get
            {
                return _civilState;
            }
            set
            {
                if (value == _civilState)
                {
                    return;
                }

                _civilState = value;
                OnPropertyChanged("CivilState");
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        
    }
}
