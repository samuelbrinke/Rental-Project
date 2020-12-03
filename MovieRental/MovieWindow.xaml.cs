using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using DatabaseConnection;

namespace MovieRental
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml
    /// </summary>
    public partial class MovieWindow : Window
    {
        public void LoadAllMovies()
        {
            int movie_skip_count = 0;
            int movie_take_count = 100;
            if (FilterAction.IsSelected)
            {
                State.Movies.Clear();
                State.Movies = API.FilterMovieByAction();
            }
            else if (FilterComedy.IsSelected)
            {
                State.Movies.Clear();
                State.Movies = API.FilterMovieByComedy();
            }
            else if (FilterFamily.IsSelected)
            {
                State.Movies.Clear();
                State.Movies = API.FilterMovieByFamily();
            }
            else if (FilterHorror.IsSelected)
            {
                State.Movies.Clear();
                State.Movies = API.FilterMovieByHorror();
            }
            else
            {
                if (State.Movies != null)
                {
                    State.Movies.Clear();
                }

                State.Movies = API.GetMovie(movie_skip_count, movie_take_count);
            }

            int column_count = MovieGrid.ColumnDefinitions.Count;

            int row_count = (int)Math.Ceiling((double)State.Movies.Count / (double)column_count);

            for (int y = 0; y < row_count; y++)
            {
                // Skapa en rad-definition för att bestämma hur hög just denna raden är.
                MovieGrid.RowDefinitions.Add(
                    new RowDefinition()
                    {
                        Height = new GridLength(200, GridUnitType.Pixel)
                    });

                // Lägga till en film i varje cell för en rad
                for (int x = 0; x < column_count; x++)
                {
                    // Räkna ut vilken film vi ska ploppa in härnäst utifrån mina x,y koordinater
                    int i = y * column_count + x;
                    // Kolla så att vi inte försöker fylla mer Grid celler än vi har filmrecords.
                    if (i < State.Movies.Count)
                    {
                        // Hämta ett film record
                        var movie = State.Movies[i];

                        // Försök att skapa en Image Controller(legobit) och
                        // placera den i rätt Grid cell enl. x,y koordinaterna
                        // Skapa en Image som visar filmomslaget
                        var image = new Image()
                        {
                            Cursor = Cursors.Hand, // Visa en 'click me' hand när man hovrar över bilden
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(4, 4, 4, 4),
                        };
                        image.MouseUp += Image_MouseUp;

                        try
                        {
                            image.Source = new BitmapImage(new Uri(movie.ImageURL)); // Hämta hem bildlänken till RAM
                        }
                        catch (Exception e) when
                            (e is ArgumentNullException ||
                             e is System.IO.FileNotFoundException ||
                             e is UriFormatException)
                        {
                            // Om något gick fel så lägger vi in en placeholder 
                            image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
                        }

                        // Lägg till Image i Grid
                        MovieGrid.Children.Add(image);

                        // Placera in Image i Grid
                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);
                    }
                }
            }
        }
        public MovieWindow()
        {
            InitializeComponent();
            LoadAllMovies();

        }
        // Vad som händer när man klickar på en filmikon i appen.
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Ta reda på vilken koordinat den klickade bilden har.
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            // Används koordinaten för att ta reda på vilken motsvarande record det rörde sig om.
            int i = y * MovieGrid.ColumnDefinitions.Count + x;
            // Lägg valet på minne.
            State.Pick = State.Movies[i];

            // Försök att registrera en uthyrning.
            if (API.RegisterSale(State.Users, State.Pick))
                // MessageBox är små pop-up fönster som är behändiga för att varna användaren om fel etc.
                MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {
            var Profile = new Profile();
            Profile.Show();
        }

        private void Action_Filter_Btn(object sender, RoutedEventArgs e)
        {
            FilterAction.IsSelected = true; FilterComedy.IsSelected = false; FilterFamily.IsSelected = false; FilterHorror.IsSelected = false;
            MovieGrid.Children.Clear();
            MovieGrid.RowDefinitions.Clear();
            LoadAllMovies();
        }

        private void Comedy_Filter_Btn(object sender, RoutedEventArgs e)
        {
            FilterComedy.IsSelected = true; FilterAction.IsSelected = false; FilterFamily.IsSelected = false; FilterHorror.IsSelected = false;
            MovieGrid.Children.Clear();
            MovieGrid.RowDefinitions.Clear();
            LoadAllMovies();
        }

        private void Family_Filter_Btn(object sender, RoutedEventArgs e)
        {
            FilterFamily.IsSelected = true; FilterAction.IsSelected = false; FilterComedy.IsSelected = false; FilterHorror.IsSelected = false;
            MovieGrid.Children.Clear();
            MovieGrid.RowDefinitions.Clear();
            LoadAllMovies();
        }

        private void Horror_Filter_Btn(object sender, RoutedEventArgs e)
        {
            FilterHorror.IsSelected = true; FilterAction.IsSelected = false; FilterComedy.IsSelected = false; FilterFamily.IsSelected = false;
            MovieGrid.Children.Clear();
            MovieGrid.RowDefinitions.Clear();
            LoadAllMovies();
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            FilterHorror.IsSelected = false; FilterAction.IsSelected = false; FilterComedy.IsSelected = false; FilterFamily.IsSelected = false;
            MovieGrid.Children.Clear();
            MovieGrid.RowDefinitions.Clear();
            LoadAllMovies();
        }
    }
}
