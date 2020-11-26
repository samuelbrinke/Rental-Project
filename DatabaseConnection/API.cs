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
    }
}
