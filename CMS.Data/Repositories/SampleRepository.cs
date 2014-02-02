using CMS.Data.DBInteractions;
using CMS.Data.Repositories;
using CMS.Entities;

namespace CodeFirstData.EntityRepositories
{
    public class StudentRepository : EntityRepositoryBase<SampleEntity>, ISampleRepository
    {
        public StudentRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

}