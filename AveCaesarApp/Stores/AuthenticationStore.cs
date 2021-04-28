using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        public async Task<User> Login(string login, string password)
        {
            return await _authenticationService.Login(login, password);
        }

        public async Task<RegistrationResult> Register(string login, string password, string confirmPassword, string fullName,
            ProfileType profileType)
        {
           return await _authenticationService.Register(login, password, confirmPassword, fullName, profileType);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

    }
}
