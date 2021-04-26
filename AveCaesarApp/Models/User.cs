using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AveCaesarApp.Models
{
    public enum ProfileType
    {
        [Display(Name = "Менеджер")]
        Manager = 0,
        [Display(Name = "Повар")]
        Chef,
        [Display(Name = "Официант")]
        Waiter
    }

    public class User : Item
    {
        public User(int id, string login, string hashedPassword, string fullName, ProfileType profileType) : base(id)
        {
            Login = login;
            HashedPassword = hashedPassword;
            FullName = fullName;
            ProfileType = profileType;
        }

        public string Login { get; set; }
        public string HashedPassword { get; set; }
        public string FullName { get; set; }
        public ProfileType ProfileType { get; set; }
        
    }
}
