using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AveCaesarApp.Models
{
    public class Profile
    {
        public Profile(string fullName, FullProfileType profileType)
        {
            FullName = fullName;
            ProfileType = profileType;
        }
        public string FullName { get;  }
        public FullProfileType ProfileType { get; }
    }
}
