using System;
using System.Collections.Generic;
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
                ctx.AddRange(new List<User>
                {
                    new User {FirstName = "Gustav", LastName = "Gustavsson", Adress = "Storgatan 1", PersonalNumber = 950101, PhoneNumber = 0708223344, ZipCode = 56249 },
                    new User {FirstName = "Oskar", LastName = "Oskarsson", Adress = "Lillgatan 1", PersonalNumber = 920201, PhoneNumber = 0708554433, ZipCode = 56248 },
                    new User {FirstName = "Bengt", LastName = "Bengtsson", Adress = "Smedjegatan 1", PersonalNumber = 860101, PhoneNumber = 0708223399, ZipCode = 56249 }
                });
                ctx.SaveChanges();
                
            }
        }
    }
}
