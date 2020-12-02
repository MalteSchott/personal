using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp2
{
    class ViewModel : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return false;
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand ReadCommand { get; }

        ServiceReference2.WebService1SoapClient soap;
        private string input;
        public string Input
        {
            get => input;
            set => SetProperty(ref input, value, "Input");
        }
        private string output;
        public string Output
        {
            get => output;
            set => SetProperty(ref output, value, "Output");
        }

        public ViewModel()
        {
            ReadCommand = new DelegateCommand(Read);
            soap = new ServiceReference2.WebService1SoapClient();
        }

        private void Read(object obj)
        {
            try
            {
                ServiceReference2.ArrayOfString content = soap.GetFileContents(Input);
                StringBuilder sb = new StringBuilder();
                foreach (string s in content)
                {
                    sb.Append(s + '\n');
                }
                Output = sb.ToString();
            }
            catch
            {
                Output = "Exception encountered. Check that the filename is correct and that the Web Service is running";                
            }
        }
    }
}
