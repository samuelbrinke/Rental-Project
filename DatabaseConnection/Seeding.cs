using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    class Seeding
    {
        static void Main()
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Users);
                ctx.RemoveRange(ctx.Movies);

                var movies = new List<Movie>();
                string[] lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");

                for (int i = 1; i < 100; i++)
                {
                    string[] cells = lines[i].Split(',');
                    string url = cells[5].Trim('"');

                    // Hoppa över alla icke-fungerande url:er
                    try { var test = new Uri(url); }
                    catch (Exception) { continue; }

                    movies.Add(new Movie { Title = cells[2], ImageURL = url });
                }

                ctx.AddRange(movies);

                ctx.AddRange(new List<User>
                {
                    new User {UserName = "Gustavsson1",FirstName = "Gustav", LastName = "Gustavsson", Adress = "Storgatan 1", PersonalNumber = 950101, PhoneNumber = 0708223344, ZipCode = 56249 },
                    new User {UserName = "Oskar2", FirstName = "Oskar", LastName = "Oskarsson", Adress = "Lillgatan 1", PersonalNumber = 920201, PhoneNumber = 0708554433, ZipCode = 56248 },
                    new User {UserName = "Bengan", FirstName = "Bengt", LastName = "Bengtsson", Adress = "Smedjegatan 1", PersonalNumber = 860101, PhoneNumber = 0708223399, ZipCode = 56249 }
                });
                ctx.SaveChanges();
                
            }
        }
    }
}
