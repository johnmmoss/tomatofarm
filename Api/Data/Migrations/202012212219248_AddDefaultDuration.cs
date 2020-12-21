namespace TomatoFarm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DefaultDuration", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "StarRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "StarRating", c => c.String(unicode: false));
            DropColumn("dbo.AspNetUsers", "DefaultDuration");
        }
    }
}
