using System;

namespace CMS.Data.DBInteractions
{
    public interface IDBFactory : IDisposable
    {
        BaseContext Get();
    }
}
