namespace CustomPoolAndSpa.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNameFromCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("Domain.Customer", "Name");
        }
        
        public override void Down()
        {
            AddColumn("Domain.Customer", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
