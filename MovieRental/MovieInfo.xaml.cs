﻿using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for MovieInfo.xaml
    /// </summary>
    public partial class MovieInfo : UserControl
    {
        public MovieInfo()
        {
            InitializeComponent();

        }
        public static void SetMovieInfo()
        {
            //MovieInfo.Movie_Info.Children.Add(new Label() { Content = State.Pick.Title.ToString() });

        }
    }
}
