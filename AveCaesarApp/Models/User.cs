using System.ComponentModel.DataAnnotations;

namespace AveCaesarApp.Models
{
    public enum ProfileType
    {
        [Display(Name = "Менеджер")]
        Manager = 1,
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
