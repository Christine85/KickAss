using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class DataManager
    {
        KickAssDataBaseContext context;

        public DataManager(KickAssDataBaseContext context)
        {
            this.context = context;
        }

        public void CreateUser(CreateUserVM viewModel)
        {
            var user = new User();
            
            user.UserId = 1;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Email = viewModel.Email;
            user.PhoneNumber = viewModel.PhoneNumber;

            context.Users.Add(user);
            context.SaveChanges();

            var security = new Security();

            security.Email = viewModel.Email;
            security.Password = viewModel.Password;

            context.Securitys.Add(security);
            context.SaveChanges();

        }
    }
}
