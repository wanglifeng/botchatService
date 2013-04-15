namespace DomainCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_class_State_Messages_Language_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StateMessages", "Language", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StateMessages", "Language");
        }
    }
}
