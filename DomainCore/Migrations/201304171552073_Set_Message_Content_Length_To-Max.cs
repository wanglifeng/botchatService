namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Set_Message_Content_Length_ToMax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
