namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Set_UserStatus_Into_user_Class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Status", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
        }
    }
}
