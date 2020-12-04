using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string ZipCode { get; set; }

        public string Adress { get; set; }

        public virtual List<Rental> Sales { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        public string Genre { get; set; }

        public string Rating { get; set; }

        public string ImdbUrl { get; set; }

        public virtual List<Rental> Sales { get; set; }
    }

    public class Rental
    {
        public int Id { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public virtual User User { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
