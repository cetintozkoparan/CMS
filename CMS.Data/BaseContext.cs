using System.Data.Entity;
using CMS.Entities;
namespace CMS.Data
{
    public class BaseContext : DbContext
    {
        public DbSet<SampleEntity> SampleEntities { get; set; }
        public BaseContext() : base("name=BaseContext") { }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
