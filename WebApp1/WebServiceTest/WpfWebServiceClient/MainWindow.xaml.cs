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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWebServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<Person> people = new List<Person>();
        public ServiceReference1.WebService1SoapClient serviceReference1 = new ServiceReference1.WebService1SoapClient();

        public MainWindow()
        {
            InitializeComponent();
            //people.Add(new Person { FirstName = "Jim" });
            //myComboBox.ItemsSource = people;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            tbSettingText.Text = string.Join("\n",serviceReference1.GetFileContents("wstextfile"));
        }
    }
}
