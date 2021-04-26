using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AveCaesarApp.Models
{
    public class Item
    { 

        public Item(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
         

        public int GetId() => Id;

    }
}
