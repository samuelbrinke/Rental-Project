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

            List<Rental> booking = new List<Rental>();
            booking.AddRange(API.GetRentalByUser(State.Users));
            Grid_Profile.Visibility = Visibility.Collapsed;
            Grid_ResetPassword.Visibility = Visibility.Collapsed;
            Grid_Orders.Visibility = Visibility.Visible;
            SPOrderAvalible.Children.Clear();
            SPOrderNotAvalible.Children.Clear();

            for (int i = 0; i < booking.Count; i++)
            {
                if( booking[i].DateEnd > DateTime.Now)
                {
                    SPOrderAvalible.Children.Add(new Label() { Content = "Movie title: " + booking[i].Movie.Title.ToString() });
                    SPOrderAvalible.Children.Add(new Label() { Content = "Movie StartDate: " + booking[i].DateStart.ToString() });
                    SPOrderAvalible.Children.Add(new Label() { Content = "Movie EndDate: " + booking[i].DateEnd.ToString() });
                    SPOrderAvalible.Children.Add(new Border() { BorderThickness = new Thickness(1.0), BorderBrush = Brushes.Purple });
                }
                else
                {   
                    SPOrderNotAvalible.Children.Add(new Label() { Content = "Movie title: " + booking[i].Movie.Title.ToString() });
                    SPOrderNotAvalible.Children.Add(new Label() { Content = "Movie StartDate: " + booking[i].DateStart.ToString() });
                    SPOrderNotAvalible.Children.Add(new Label() { Content = "Movie EndDate: " + booking[i].DateEnd.ToString() });
                    SPOrderNotAvalible.Children.Add(new Border() { BorderThickness = new Thickness(1.0), BorderBrush = Brushes.Purple });
                }
                
            }
            
            


        }

        private void ResetPassword_btn_Click(object sender, RoutedEventArgs e)
        {
            Grid_Profile.Visibility = Visibility.Collapsed;
            Grid_ResetPassword.Visibility = Visibility.Visible;
            Grid_Orders.Visibility = Visibility.Collapsed;
        }

        private void Profile_btn_Click(object sender, RoutedEventArgs e)
        {
            Grid_Profile.Visibility = Visibility.Visible;
            Grid_ResetPassword.Visibility = Visibility.Collapsed;
            Grid_Orders.Visibility = Visibility.Collapsed;

            //Show informoation from user in database
            var user = State.Users;
            Username_txtBox.Text = user.UserName.ToString();
            FirstName_txtBox.Text = user.FirstName.ToString();
            LastName_txtBox.Text = user.LastName.ToString();
            PersonalNumber_txtBox.Text = user.PersonalNumber.ToString();
            Adress_txtBox.Text = user.Adress.ToString();
            ZipCode_txtBox.Text = user.ZipCode.ToString();
            PhoneNumber_txtBox.Text = user.PhoneNumber.ToString();

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

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            State.Users.UserName = Username_txtBox.Text;
            State.Users.FirstName = FirstName_txtBox.Text;
            State.Users.LastName = LastName_txtBox.Text;
            State.Users.PersonalNumber = PersonalNumber_txtBox.Text;
            State.Users.Adress = Adress_txtBox.Text;
            State.Users.ZipCode = ZipCode_txtBox.Text;
            State.Users.PhoneNumber = PhoneNumber_txtBox.Text;
            API.ChangePassword(State.Users);
        }
    }
}
