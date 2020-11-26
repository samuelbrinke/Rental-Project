using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    public static class API
    {
        static Context ctx;
        static API()
        {
            ctx = new Context();
        }
        public static User GetUserByUsername(string username)
        {
            return ctx.Users.FirstOrDefault(c => c.UserName.ToLower() == username.ToLower());
        }

        public static bool CheckPassword(User user, string password)
        {
            
            if (user != null && user.Password == password)
            {
                return true;
            }
            else { return false; }
        }

        public static List<Movie> GetMovie(int movie_skip_count, int movie_take_count)
        {
            return ctx.Movies
                .OrderBy(m => m.Title)
                .Skip(movie_skip_count)
                .Take(movie_take_count)
                .ToList();
        }

        public static void AddUser(string username, string firstname, string lastname, int personalnumber, int phonenumber, int zipcode, string adress )
        {
            User user = new User();
            user.FirstName = firstname;
            user.LastName = lastname;
            user.UserName = username;
            user.PhoneNumber = phonenumber;
            user.ZipCode = zipcode;
            user.Adress = adress;
            user.PersonalNumber = personalnumber;
            ctx.Users.Add(user);
            ctx.SaveChanges();
        }

        public static bool RegisterSale(User user, Movie movie)
        {
            // Försök att lägga till ett nytt sales record
            try
            {
                ctx.Add(new Rental() { Date = DateTime.Now, User = user, Movie = movie });

                bool one_record_added = ctx.SaveChanges() == 1;
                return one_record_added;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
    }
}
