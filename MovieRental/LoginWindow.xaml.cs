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
using DatabaseConnection;

namespace MovieRental
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Btn(object sender, RoutedEventArgs e)
        {
            //State.Users = API.GetUserByUsername(TxtName.Text.Trim());
            bool checkPassword = API.CheckPassword(API.GetUserByUsername(TxtName.Text.Trim()), TxtPassword.Password);
            if (checkPassword)
            {
                State.Users = API.GetUserByUsername(TxtName.Text.Trim());
                if (State.Users != null)
                {
                    var next_window = new MovieWindow();
                    next_window.Show();
                    this.Close();
                }
            }

            
            else
            {
                TxtName.Text = "";
                TxtPassword.Password = "";
                InvalidUsername.Content = "Username or password is incorrect";
                InvalidUsername.Visibility = Visibility.Visible;
                TxtName.Focus();
            }
        }

        private void Register_btn(object sender, RoutedEventArgs e)
        {
            var register_window = new RegisterWindow();
            register_window.Show();

        }
    }
}
