using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp1.DAL;

namespace WpfApp1.ViewModel
{
    public class TableViewModel : ViewModelBase
    {

        protected static DALconnector Dal { get; }

        static TableViewModel()
        {
            try
            {
                Dal = new DALconnector();
            }
            catch
            {
                
            }
        }

        protected void HandleException(Exception e)
        {
            if (Dal == null)
            {
                Output = "No database found. Please check your connection and restart the program.";
            }
            Output = "Unexpected exception";
            
        }
    
        private string output;
        public string Output
        {
            get => output;
            set => SetProperty(ref output, value, "Output");
        }

        public TableViewModel() //Create TablesOfInterest
        {
            TableOfInterest = Dal.ShowTablesOfInterest();
            if (Dal == null)
                HandleException(new NullReferenceException());
        }

        private int numberRows; //SQL-Reader int
        public int NumberRows
        {
            get => numberRows;
            set => SetProperty(ref numberRows, value, "NumberRows");
        }

        private List<string> nameOfColumns; //SQL-Reader List<string>
        public List<string> NameOfColumns
        {
            get => nameOfColumns;
            set => SetProperty(ref nameOfColumns, value, "NameOfColumns");
        }

        private List<string> tableOfInterest; //SQL-Reader List<string>
        public List<string> TableOfInterest
        {
            get => tableOfInterest;
            set => SetProperty(ref tableOfInterest, value, "TableOfInterest");
        }

        private ObservableCollection<Row> mylist; //Holds Column Names line 103
        public ObservableCollection<Row> MyList
        {
            get => mylist;
            set => SetProperty(ref mylist, value, "Mylist");
        }

        private object selectedItem; //Drop-Down object selection
        public object SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value, "SelectedItem");
                SelectedItemUpdate();
            }
        }

        private void SelectedItemUpdate() //change lists at object selection
        {
            try
            {

                string SelectedItemString = SelectedItem.ToString(); //Selection in Drop-Down to string
                NumberRows = Dal.ShowNumberOfRows(SelectedItemString); //Selection to run SQL-Reader (Int)
                NameOfColumns = Dal.ShowNamesOfColumns(SelectedItemString); // Selection to run SQL-Reader

                MyList = new ObservableCollection<Row>();
                foreach (string s in NameOfColumns)
                {
                    Row item = new Row();
                    item.Column_names = s;
                    MyList.Add(item);
                }
            }
            catch(Exception e)
            {
                HandleException(e);
            }
        }
    }
}
