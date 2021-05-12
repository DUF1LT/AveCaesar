using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AveCaesarApp.Hasher;
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

        public async Task<Profile> Login(string login, string password)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                User loginUser = await unitOfWork.UserRepository.GetByLogin(login);
                if (loginUser != null)
                {
                    var passwordHashier = new SaltedHasher(password);
                    if (!SaltedHasher.Verify(loginUser.Salt, loginUser.HashedPassword, password))
                    {
                        return null;
                    }
                }
                else
                    return null;

                return new Profile(loginUser.FullName, loginUser.ProfileType);
            }
        }

        public async Task<RegistrationResult> Register(string login, string password, string confirmPassword, string fullName, FullProfileType profileType)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (string.Equals(password, confirmPassword))
            {
                using (UnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
                {
                    if (await unitOfWork.UserRepository.GetByLogin(login) != null)
                        result = RegistrationResult.LoginAlreadyExists;

                    var passwordHashier = new SaltedHasher(password);

                    User user = new User()
                    {
                        Login = login,
                        FullName = fullName,
                        HashedPassword = passwordHashier.Hash,
                        Salt = passwordHashier.Salt,
                        ProfileType = profileType
                    };


                    if (result == RegistrationResult.Success)
                    {
                        unitOfWork.UserRepository.Create(user);
                        await unitOfWork.SaveAsync();
                    }
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
