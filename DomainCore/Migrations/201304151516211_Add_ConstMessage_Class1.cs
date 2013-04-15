namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ConstMessage_Class1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConstMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Format = c.String(maxLength: 100),
                        Content = c.String(),
                        Language = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConstMessages");
        }
    }
}
