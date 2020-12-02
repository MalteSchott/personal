using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.ViewModel
{
    public class RowViewModel : ViewModelBase
    {
        public RowViewModel()
        {
        }
        private string m_tablesOfInterest;
        public string TablesOfInterest
        {
            get
            {
                return m_tablesOfInterest;
            }
            set
            {
                m_tablesOfInterest = value;
                NotifyPropertyChanged("TablesOfInterest");
            }
        }
        public string ColumnNames
        {
            get;
            set;
        }

        public string NumberOfRows
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }



    }
}