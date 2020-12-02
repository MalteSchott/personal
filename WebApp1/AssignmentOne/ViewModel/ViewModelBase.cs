using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AssignmentOne
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected static DALconnector Dal { get; }
        protected static NavigationService Nav { get; set; }
        
        static ViewModelBase()
        {
            try
            {
                Dal = new DALconnector();
            }
            catch
            {

            }
        }

        protected ViewModelBase()
        {
            if (Dal == null)
                HandleException(new NullReferenceException());   
        }
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return false;
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        protected void NotifyPropertyChanged(string Obj)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Obj));
            }
        }

        protected void HandleException(Exception e)
        {
            if (Dal == null)
            {
                Output = "No database found. Please check your connection and restart the program.";
            }
            else if (e is NullReferenceException)
            {
                Output = "Please select a course";
            }
            else if (e is ArgumentOutOfRangeException)
            {
                Output = "Database did not find any data, please ensure you entered the right information";
            }
            else if (e is FormatException)
            {
                Output = "Max participants must be a number";
            }
            else if (e is System.Data.SqlClient.SqlException)
            {
                System.Data.SqlClient.SqlException ex = e as System.Data.SqlClient.SqlException;
                switch (ex.Number)
                {
                    default:
                        Output = "Unexpected SQLexception, exception number: \"" + ex.Number + "\"";
                        Console.WriteLine(e.Message + "\n" + e.StackTrace);
                        break;
                    case 8152:
                        Output = "Data was longer than database limit. Make sure that no field has an excessively long entry or contact sysadmin";
                        break;
                    case 2627:
                        if (this is ViewModel.AdminViewModel)
                            Output = "ID already in use. Please pick a new ID";
                        else if (this is MemberViewModel)
                            Output = "Already registered on course.";
                        else
                            Output = "Unexpected Unique key violation";
                        break;
                }
            }
            else
            {
                Output = "Unexpected exception";
            }
            Console.WriteLine(e.Message + "\n" + e.StackTrace);
        }
        private string output;
        public string Output
        {
            get => output;
            set => SetProperty(ref output, value, "Output");
        }
    }
}