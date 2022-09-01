namespace rehberWebUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.People", "cityId");
            AddForeignKey("dbo.People", "cityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "cityId", "dbo.Cities");
            DropIndex("dbo.People", new[] { "cityId" });
        }
    }
}
