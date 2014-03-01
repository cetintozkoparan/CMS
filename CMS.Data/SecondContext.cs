using System.Data.Entity;
using CMS.Entities;
namespace CMS.Data
{
    public class SecondContext : DbContext
    {
        public DbSet<SampleEntity> SampleEntities { get; set; }
        public SecondContext() : base("name=BaseContext") { }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
