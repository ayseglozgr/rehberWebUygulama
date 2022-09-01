namespace rehberWebUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "mobilePhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "mobilePhone");
        }
    }
}
