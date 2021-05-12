using System.ComponentModel.DataAnnotations;

namespace AveCaesarApp.Models
{
    public enum FullProfileType
    {
        [Display(Name = "Админ")]
        Admin = 0,
        [Display(Name = "Менеджер")]
        Manager = 1,
        [Display(Name = "Повар")]
        Chef,
        [Display(Name = "Официант")]
        Waiter
    }
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
        public User()
        {
        }
        public User(int id, string login, string hashedPassword, string fullName, FullProfileType profileType) : base(id)
        {
            Login = login;
            HashedPassword = hashedPassword;
            FullName = fullName;
            ProfileType = profileType;
        }

        public string Login { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public string FullName { get; set; }
        public FullProfileType ProfileType { get; set; }
        
    }
}
