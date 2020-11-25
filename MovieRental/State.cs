using DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental
{
    class State
    {
        public static User Users { get; set; }
        public static List<Movie> Movies { get; set; }
    }
}
