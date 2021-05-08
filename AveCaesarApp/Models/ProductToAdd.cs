using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AveCaesarApp.Models
{
    public class ProductToAdd
    {
        public Product Product { get; set; }
        public float Amount { get; set; }

        public override string ToString()
        {
            return string.Join(Product.Name, " - ", Amount, " ", Product.WeightType);
        }
    }
}
