namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Set_StateMessage_Content_Length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StateMessages", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StateMessages", "Content", c => c.String(maxLength: 100));
        }
    }
}
