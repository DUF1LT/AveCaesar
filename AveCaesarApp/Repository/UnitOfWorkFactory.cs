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
        private AveCaesarContextFactory _contextFactory;
        public UnitOfWorkFactory(AveCaesarContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public UnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(_contextFactory);
        }
    }
}
