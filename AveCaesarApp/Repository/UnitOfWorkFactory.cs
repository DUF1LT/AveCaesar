using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AveCaesarApp.Context;

namespace AveCaesarApp.Repository
{
    public class UnitOfWorkFactory
    {
        public UnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
    }
}
