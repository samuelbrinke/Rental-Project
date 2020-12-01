using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatabaseConnection;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;

namespace MovieRental
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        

        public Profile()
        {
            InitializeComponent();
            
        }

        private void Grid_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void Movie_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetPassword_btn_Click(object sender, RoutedEventArgs e)
        {
            Grid_Profile.Visibility = Visibility.Collapsed;
            Grid_ResetPassword.Visibility = Visibility.Visible;
        }

        private void Profile_btn_Click(object sender, RoutedEventArgs e)
        {
            Grid_Profile.Visibility = Visibility.Visible;
            Grid_ResetPassword.Visibility = Visibility.Collapsed;




            var user = State.Users;
            Username_txtBox.Text = State.Users.UserName.ToString();
        }

        

        private void ChangePassword_btn_Click(object sender, RoutedEventArgs e)
        {

            if (NewPassword_box1.Password == NewPassword_box2.Password)
            {
                State.Users.Password = NewPassword_box1.Password;
                API.ChangePassword(State.Users);
                SuccesOrNotLabel.Content = "Password succesfully updated";
                SuccesOrNotLabel.Foreground = Brushes.Green;
                SuccesOrNotLabel.Visibility = Visibility.Visible;
            }
            else
            {
                SuccesOrNotLabel.Content = "!!Password not updated!! Check that password is matching";
                SuccesOrNotLabel.Foreground = Brushes.Red;
                SuccesOrNotLabel.Visibility = Visibility.Visible;
            }

        }

       
    }
}
