namespace MVCDay1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumninMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DirectorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DirectorName");
        }
    }
}
