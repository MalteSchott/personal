using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.Utils;

namespace WpfApp2.ViewModel
{
    class TableViewModel : ViewModelBase
    {

        private ObservableCollection<RowViewModel> m_RowsReg;
        private ObservableCollection<RowViewModel> m_Rows;
        private Random rand;
        private string user;

        public DelegateCommand JoinCommand { get; }

        private RowViewModel selected;

        public TableViewModel(string user)
        {
            this.user = user;
        }

        public RowViewModel Selected
        {
            get => selected;
            set => SetProperty(ref selected, value, "Selected");
        }

        public void UpdateTable()
        {
            try
            {
                List<List<string>> cols = Dal.ShowTables();
                RowsReg = new ObservableCollection<RowViewModel>();
                Rows = new ObservableCollection<RowViewModel>();

                foreach (List<string> rows in cols)
                {


                    Rows.Add(new RowViewModel
                    {
                        TablesOfInterest = rows[0],
                        ColumnNames = rows[1],
                        NumberOfRows = rows[2]


                    });
                }
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }




        public ObservableCollection<RowViewModel> Rows
        {
            get { return m_Rows; }
            set { m_Rows = value; }
        }

        public ObservableCollection<RowViewModel> RowsReg
        {
            get { return m_RowsReg; }
            set { m_RowsReg = value; }
        }




    }


}
