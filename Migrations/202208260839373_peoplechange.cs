namespace rehberWebUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class peoplechange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "cityId", "dbo.Cities");
            DropIndex("dbo.People", new[] { "cityId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.People", "cityId");
            AddForeignKey("dbo.People", "cityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
