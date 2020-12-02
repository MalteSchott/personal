using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections;
using System.Windows.Navigation;

namespace AssignmentOne
{
    class LoginViewModel : ViewModelBase
    {
        private String id;
        public String ID
        {
            get { return id; }
            set
            {
                SetProperty(ref id, value, "ID");
            }
        }
        private bool userSelected;
        public bool UserSelected {
            get => userSelected;
            set => SetProperty(ref userSelected, value, "UserSelected");
        }
        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value, "Password");
        }

        public DelegateCommand LoginCommand { get; }
        delegate byte[] ToBytes(string s);
        private static readonly ToBytes toBytes = Encoding.UTF8.GetBytes;
        public LoginViewModel(NavigationService nav)
        {
            Nav = nav;
            LoginCommand = new DelegateCommand(TryToLogin);
            UserSelected = true;
        }
        
        private void TryToLogin(object source)
        {
            try
            {
                string pwdb;
                if(UserSelected)
                    pwdb = Dal.ShowMemberPassword(ID)[0][0];
                else
                    pwdb = Dal.ShowAdminPassword(ID)[0][0];
                if (Utils.CryptographyUtilities.Hash(Password, ID).Equals((pwdb)))
                {
                    if (UserSelected)
                        Nav.Navigate(new Member(ID));
                    else
                        Nav.Navigate(new AdminPage());
                }
                else
                {
                    Output = "Invalid password";
                }
            }
            catch(Exception e)
            {
                HandleException(e);
            }
        }
    }
}