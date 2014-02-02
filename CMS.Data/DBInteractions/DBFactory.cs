
using System.Data.Entity;

namespace CMS.Data.DBInteractions
{
public class DBFactory : Disposable, IDBFactory
{

    public DBFactory()
    {
        Database.SetInitializer<BaseContext>(null);
    }
    private BaseContext dataContext;
    public BaseContext Get()
    {
        return dataContext ?? (dataContext = new BaseContext());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
