namespace Demo.ODataV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class F1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransporterRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Note = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransporterRequests");
        }
    }
}
