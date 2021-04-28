﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Hashier;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;

namespace AveCaesarApp.Services
{
    public enum RegistrationResult
    {
        Success,
        PasswordDoNotMatch,
        LoginAlreadyExists
    }

    public class AuthenticationService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public AuthenticationService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<User> Login(string login, string password)
        {
            //TODO: Login when DB will be connected
        }

        public async Task<RegistrationResult> Register(string login, string password, string confirmPassword, string fullName, ProfileType profileType)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (string.Equals(password, confirmPassword))
            {
                using (UnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
                { 
                    result = RegistrationResult.LoginAlreadyExists;

                    var passwordHashier = new SaltedHashier(password);

                    User user = new User(1, login, passwordHashier.Hash, fullName, profileType);


                    unitOfWork.UserRepository.Create(user);
                    unitOfWork.Save();
                }
            }
            else
            {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            return result;

        }
    }
}
