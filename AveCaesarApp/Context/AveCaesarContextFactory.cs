using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace AveCaesarApp.Context
{
    public class AveCaesarContextFactory 
    {
        public AveCaesarContext CreateDbContext()
        {
            return new AveCaesarContext();
        }
    }
}
