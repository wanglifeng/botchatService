namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_ChineseLastname_class : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChineseLastNames", "LastName", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChineseLastNames", "LastName", c => c.String());
        }
    }
}
