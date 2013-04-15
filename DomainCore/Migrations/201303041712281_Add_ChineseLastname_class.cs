namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ChineseLastname_class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChineseLastNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChineseLastNames");
        }
    }
}
