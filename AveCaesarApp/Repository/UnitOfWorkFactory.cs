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
