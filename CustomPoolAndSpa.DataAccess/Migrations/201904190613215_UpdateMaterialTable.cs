namespace CustomPoolAndSpa.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMaterialTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("Domain.Material", "ItemName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("Domain.Material", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("Domain.Material", "Name");
        }
        
        public override void Down()
        {
            AddColumn("Domain.Material", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("Domain.Material", "UnitPrice");
            DropColumn("Domain.Material", "ItemName");
        }
    }
}
