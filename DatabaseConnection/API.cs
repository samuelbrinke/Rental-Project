﻿using System;
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

        public static List<Movie> FilterMovieByAction()
        {
            return ctx.Movies
                .Where(g => g.Genre.Contains("action"))
                .ToList();
        }
        public static List<Movie> FilterMovieByComedy()
        {
            return ctx.Movies
                .Where(g => g.Genre.Contains("Comedy"))
                .ToList();
        }
        public static List<Movie> FilterMovieByFamily()
        {
            return ctx.Movies
                .Where(g => g.Genre.Contains("Family"))
                .ToList();
        }
        public static List<Movie> FilterMovieByHorror()
        {
            return ctx.Movies
                .Where(g => g.Genre.Contains("Horror"))
                .ToList();
        }

        public static List<Movie> FilterMovieBySearch(string search)
        {
            return ctx.Movies
                .Where(f => f.Title.Contains(search))
                .ToList();
        }

        public static void AddUser(string username, string password, string firstname, string lastname, string personalnumber, string phonenumber, string zipcode, string adress )
        {
            User user = new User();
            user.FirstName = firstname;
            user.LastName = lastname;
            user.UserName = username;
            user.Password = password;
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
                ctx.Add(new Rental() { DateStart = DateTime.Now, DateEnd = DateTime.Now.AddHours(48), User = user, Movie = movie });

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

        public static void ChangePassword(User user)
        {
            ctx.Users.Update(user);
            ctx.SaveChanges();
        }

        public static List<Rental> GetRentalByUser(User user)
        {
            return ctx.Rentals
                .Where(b => b.User.Equals(user))
                .ToList();
        }
    }
}
