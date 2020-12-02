using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WpfApp2.DAL;

namespace WpfApp2.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        /*

                protected DALconnector Dal { get; }
                protected ViewModelBase()
                {
                    Dal = new DALconnector(this);

                    // Dal.Disconnect();
        */
        protected static DALconnector Dal { get; }
        /*protected DALconnector GetDal() {
            if (dal == null)
                Output = "Ingen uppkoppling, testa att starta om programmet";
            return dal;
                }
            protected static void SetDal(DALconnector dal) {
            ViewModelBase.dal = dal;
                    }*/
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
        protected void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // [Conditional("DEBUG")]  comment: name 'Conditional' could not be found
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
        protected void HandleException(Exception e)
        {
            if (e is NullReferenceException)
            {
                Output = "No database found. Please check your connection and restart the program.";
            }
            //TODO: add more error types
            else
            {
                Output = "Unknown error";
            }
        }
        private string output;
        public string Output
        {
            get => output;
            set => SetProperty(ref output, value, "Output");
        }
    }
}
