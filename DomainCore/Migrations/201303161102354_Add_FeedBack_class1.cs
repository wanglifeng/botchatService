namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FeedBack_class1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedBacks", "UserName", c => c.String(maxLength: 50));
            AddColumn("dbo.FeedBacks", "ClientId", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedBacks", "ClientId");
            DropColumn("dbo.FeedBacks", "UserName");
        }
    }
}
