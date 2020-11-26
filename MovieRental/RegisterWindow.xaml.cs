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

namespace MovieRental
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_btn(object sender, RoutedEventArgs e)
        {
            API.AddUser(Username_txtBox.Text, FirstName_txtBox.Text, LastName_txtBox.Text, Convert.ToInt32(PersonalNumber_txtBox.Text), Convert.ToInt32(PhoneNumber_txtBox.Text), Convert.ToInt32(ZipCode_txtBox.Text), Adress_txtBox.Text);
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
