using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Row : ViewModelBase
    {
        public Row()
        {

        }


        private string column_names; //Column names for MyList (TableViewModel line 103)
        public string Column_names
        {
            get => column_names;
            set => SetProperty(ref column_names, value, "Column_names");

        }
    }
}
