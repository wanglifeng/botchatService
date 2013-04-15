namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Language_Into_User_Class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Language", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Language");
        }
    }
}
