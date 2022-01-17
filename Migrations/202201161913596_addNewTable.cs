namespace Hotel_AllFrameWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        YearOfBrith = c.Int(nullable: false),
                        EntryDate = c.Int(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Claients");
        }
    }
}
