namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_State_Messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        TypeName = c.String(maxLength: 200),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StateMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 100),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.State_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.StateMessages", new[] { "State_Id" });
            DropForeignKey("dbo.StateMessages", "State_Id", "dbo.States");
            DropTable("dbo.StateMessages");
            DropTable("dbo.States");
        }
    }
}
