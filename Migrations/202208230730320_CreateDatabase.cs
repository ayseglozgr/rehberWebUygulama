namespace rehberWebUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nameOfCity = c.String(),
                        plateCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        surname = c.String(),
                        homePhone = c.String(),
                        officePhone = c.String(),
                        emailaddress = c.String(),
                        address = c.String(),
                        cityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.cityId, cascadeDelete: true)
                .Index(t => t.cityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "cityId", "dbo.Cities");
            DropIndex("dbo.People", new[] { "cityId" });
            DropTable("dbo.People");
            DropTable("dbo.Cities");
        }
    }
}
