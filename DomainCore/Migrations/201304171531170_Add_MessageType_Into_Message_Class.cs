namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_MessageType_Into_Message_Class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageType", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageType");
        }
    }
}
