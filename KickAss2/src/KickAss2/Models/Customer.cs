using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Customer : User
    {
        public Customer(int userID, string firstName, string lastName, string email) : base(userID, firstName, lastName, email)
        {

        }

    }
}
