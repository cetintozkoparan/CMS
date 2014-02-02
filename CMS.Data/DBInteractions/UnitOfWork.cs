
namespace CMS.Data.DBInteractions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBFactory _databaseFactory;
        private BaseContext _dataContext;

        public UnitOfWork(IDBFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        protected BaseContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
