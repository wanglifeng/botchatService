namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_registerTime_Into_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RegisterTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RegisterTime");
        }
    }
}
