using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                User loginUser = await unitOfWork.UserRepository.GetByLogin(login);
                var passwordHashier = new SaltedHashier(password);
                if (!SaltedHashier.Verify(passwordHashier.Salt, passwordHashier.Hash, password))
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка");
                    return null;
                }

                return loginUser;
            }
        }

        public async Task<RegistrationResult> Register(string login, string password, string confirmPassword, string fullName, ProfileType profileType)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (string.Equals(password, confirmPassword))
            {
                using (UnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
                {
                    if (await unitOfWork.UserRepository.GetByLogin(login) != null)
                        result = RegistrationResult.LoginAlreadyExists;

                    var passwordHashier = new SaltedHashier(password);

                    User user = new User(1, login, passwordHashier.Hash, fullName, profileType);


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
