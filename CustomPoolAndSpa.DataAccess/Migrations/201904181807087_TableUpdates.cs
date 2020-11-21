namespace CustomPoolAndSpa.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("Domain.Address", "Address1", c => c.String(maxLength: 50));
            AddColumn("Domain.Address", "Address2", c => c.String(maxLength: 50));
            AddColumn("Domain.Address", "CountryOrRegion", c => c.String(maxLength: 50));
            AddColumn("Domain.Customer", "Title", c => c.String(maxLength: 50));
            AddColumn("Domain.Customer", "FirstName", c => c.String(maxLength: 50));
            AddColumn("Domain.Customer", "LastName", c => c.String(maxLength: 50));
            AddColumn("Domain.Customer", "CompanyName", c => c.String(maxLength: 50));
            AddColumn("Domain.Customer", "EmailAddress", c => c.String(maxLength: 50));
            AddColumn("Domain.Customer", "BillingAddress_Id", c => c.Int());
            AddColumn("Domain.Customer", "HomeAddress_Id", c => c.Int());
            CreateIndex("Domain.Customer", "BillingAddress_Id");
            CreateIndex("Domain.Customer", "HomeAddress_Id");
            AddForeignKey("Domain.Customer", "BillingAddress_Id", "Domain.Address", "Id");
            AddForeignKey("Domain.Customer", "HomeAddress_Id", "Domain.Address", "Id");
            DropColumn("Domain.Address", "Street1");
            DropColumn("Domain.Address", "Street2");
        }
        
        public override void Down()
        {
            AddColumn("Domain.Address", "Street2", c => c.String(maxLength: 50));
            AddColumn("Domain.Address", "Street1", c => c.String(maxLength: 50));
            DropForeignKey("Domain.Customer", "HomeAddress_Id", "Domain.Address");
            DropForeignKey("Domain.Customer", "BillingAddress_Id", "Domain.Address");
            DropIndex("Domain.Customer", new[] { "HomeAddress_Id" });
            DropIndex("Domain.Customer", new[] { "BillingAddress_Id" });
            DropColumn("Domain.Customer", "HomeAddress_Id");
            DropColumn("Domain.Customer", "BillingAddress_Id");
            DropColumn("Domain.Customer", "EmailAddress");
            DropColumn("Domain.Customer", "CompanyName");
            DropColumn("Domain.Customer", "LastName");
            DropColumn("Domain.Customer", "FirstName");
            DropColumn("Domain.Customer", "Title");
            DropColumn("Domain.Address", "CountryOrRegion");
            DropColumn("Domain.Address", "Address2");
            DropColumn("Domain.Address", "Address1");
        }
    }
}
