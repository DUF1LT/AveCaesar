using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Hashier;
using AveCaesarApp.Models;

namespace AveCaesarApp.Services
{
    public class AuthenticationService
    {

        public void Login(string login, string password)
        {
            //TODO: Login when DB will be connected
        }

        public void Register(string login, string password, string confirmPassword, string fullName, ProfileType profileType)
        {
            if (string.Equals(password, confirmPassword))
            {

                var passwordHasier = new SaltedHashier(password);

                User user = new User(1, login, passwordHasier.Hash, fullName, profileType);
            }

        }
    }
}
