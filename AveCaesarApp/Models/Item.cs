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
            ID = id;
        }

        public int ID { get; set; }
         

        public int GetId() => ID;

    }
}
