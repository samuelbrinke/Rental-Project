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
    }
}
