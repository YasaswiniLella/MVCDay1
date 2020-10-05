namespace MVCDay1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateofbirth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "DateofBirth", c => c.DateTime());
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Gender", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "DateofBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
