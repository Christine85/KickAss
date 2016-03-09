using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Admin:User
    {
        public Admin(int userID, string firstName, string lastName, string email) :base(userID, firstName, lastName, email)
        {

        }
    }
}
