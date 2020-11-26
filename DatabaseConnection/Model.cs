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

        public int PersonalNumber { get; set; }

        public int PhoneNumber { get; set; }

        public int ZipCode { get; set; }

        public string Adress { get; set; }

        public virtual List<Rental> Sales { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        public virtual List<Rental> Sales { get; set; }
    }

    public class Rental
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public virtual User User { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
