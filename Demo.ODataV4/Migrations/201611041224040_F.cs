namespace Demo.ODataV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class F : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Note = c.String(),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
