namespace ProcManagement.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesofuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entries", "UserID");
        }
    }
}
