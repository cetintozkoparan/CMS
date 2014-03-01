namespace CMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SampleEntities",
                c => new
                    {
                        SampleEntityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.SampleEntityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SampleEntities");
        }
    }
}
