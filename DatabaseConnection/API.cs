using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    public class API
    {
        public static User GetUserByUsername(string username)
        {
            using var ctx = new Context();
            return ctx.Users.FirstOrDefault(c => c.UserName.ToLower() == username.ToLower());
        }
    }
}
