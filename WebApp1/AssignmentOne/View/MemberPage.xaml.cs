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
using System.ComponentModel;

namespace AssignmentOne
{
    /// <summary>
    /// Interaction logic for Member.xaml
    /// </summary>
    public partial class Member : Page
    {
        public Member(string user)
        {
            InitializeComponent();
            DataContext = new MemberViewModel(user);
        }
    }
}
