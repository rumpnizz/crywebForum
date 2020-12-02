namespace cryWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Hash", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Salt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Salt", c => c.String());
            AlterColumn("dbo.Users", "Hash", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            DropColumn("dbo.Posts", "Created");
            DropColumn("dbo.Threads", "Created");
        }
    }
}
