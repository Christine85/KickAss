using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public abstract class User
    {
        public User(int userID, string firstName, string lastName, string email)
        {
            UserId = userID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
