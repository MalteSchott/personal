using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClientWSU2
{

    // class for storing data from one row in the database
    public class Row : ViewModelBase
    {
       


        private string col1;
        public string Col1
        {
            get => col1;
            set => SetProperty(ref col1, value, "Col1");

        }

        private string col2;
        public string Col2
        {
            get => col2;
            set => SetProperty(ref col2, value, "Col2");

        }

        private string col3;
        public string Col3
        {
            get => col3;
            set => SetProperty(ref col3, value, "Col3");

        }

       
    }

    public class Row2 : ViewModelBase
    {



        private string col1b;
        public string Col1b
        {
            get => col1b;
            set => SetProperty(ref col1b, value, "Colb");

        }

        private string col2;
        public string Col2
        {
            get => col2;
            set => SetProperty(ref col2, value, "Col2");

        }

        private string col3;
        public string Col3
        {
            get => col3;
            set => SetProperty(ref col3, value, "Col3");

        }


    }
}
