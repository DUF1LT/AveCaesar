using System.Windows;
using AveCaesarApp.Models;

namespace AveCaesarApp.Services
{
    public static class AccessService
    {
        public static bool CanProfileAccessUsers(Profile profile)
        {
            if(profile.ProfileType == FullProfileType.Admin || profile.ProfileType == FullProfileType.Manager)
                return true;
            MessageBox.Show("Доступ запрещен", "Ошибка");
            return false;
        }
        public static bool CanProfileAccessProduct(Profile profile)
        {
           if(profile.ProfileType == FullProfileType.Admin || profile.ProfileType == FullProfileType.Manager)
               return true;
           MessageBox.Show("Доступ запрещен", "Ошибка");
           return false;
        }
        public static bool CanProfileAccessDish(Profile profile)
        {
           if(profile.ProfileType == FullProfileType.Admin || profile.ProfileType == FullProfileType.Chef)
               return true;
           MessageBox.Show("Доступ запрещен", "Ошибка");
           return false;
        }
        public static bool CanProfileAccessOrder(Profile profile)
        {
            if(profile.ProfileType == FullProfileType.Admin || profile.ProfileType == FullProfileType.Waiter)
                return true;
            MessageBox.Show("Доступ запрещен", "Ошибка");
            return false;
        }
    }
}
