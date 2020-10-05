namespace MVCDay1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableMembership : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipType = c.String(),
                        SignUpFee = c.Single(nullable: false),
                        Duration = c.String(),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Memberships");
        }
    }
}
