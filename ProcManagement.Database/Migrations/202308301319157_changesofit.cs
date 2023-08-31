namespace ProcManagement.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesofit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hospitals", "UserID");
        }
    }
}
