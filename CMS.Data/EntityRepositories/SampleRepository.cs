using CMS.Data.DBInteractions;
using CMS.Entities;

namespace CMS.Data.EntityRepositories
{
    public class SampleRepository : EntityRepositoryBase<SampleEntity>, ISampleRepository
    {
        public SampleRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

}