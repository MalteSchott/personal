using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TablesOfInterest : Window
    {
        public TablesOfInterest()
        {
            InitializeComponent();
            DataContext = new TableViewModel();
        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) //Drop-Down Selection
        { 
            int SelectedIndex = ComboBox1.SelectedIndex;
            object selectedItem = ComboBox1.SelectedItem;

            Console.WriteLine(selectedItem);
        }

    }
}
