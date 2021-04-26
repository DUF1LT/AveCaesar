using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Models;
using AveCaesarApp.Services;
using AveCaesarApp.ViewModels.Base;

namespace AveCaesarApp.Stores
{
    public class AuthenticationStore
    {

        private readonly AuthenticationService _authenticationService;
        
        public AuthenticationStore(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public User CurrentUser { get; set; }

        public void Login(string login, string password)
        {

        }

        public void Register(string login, string password, string confirmPassword, string fullName,
            ProfileType profileType)
        {
            _authenticationService.Register(login, password, confirmPassword, fullName, profileType);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

    }
}
