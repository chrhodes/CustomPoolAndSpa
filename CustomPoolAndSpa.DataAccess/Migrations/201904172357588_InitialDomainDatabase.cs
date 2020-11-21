namespace CustomPoolAndSpa.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDomainDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Domain.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street1 = c.String(maxLength: 50),
                        Street2 = c.String(maxLength: 50),
                        City = c.String(maxLength: 30),
                        State = c.String(maxLength: 30),
                        ZipCode = c.String(maxLength: 20),
                        DateModified = c.DateTime(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CellPhone = c.String(maxLength: 50),
                        WorkPhone = c.String(maxLength: 50),
                        MainPhone = c.String(maxLength: 50),
                        HomePhone = c.String(maxLength: 50),
                        DateModified = c.DateTime(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.Material",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        DateModified = c.DateTime(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.MaterialUsed",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        DateModified = c.DateTime(),
                        DateCreated = c.DateTime(),
                        Material_Id = c.Int(nullable: false),
                        ServiceReport_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.Material", t => t.Material_Id, cascadeDelete: true)
                .ForeignKey("Domain.ServiceCall", t => t.ServiceReport_Id, cascadeDelete: true)
                .Index(t => t.Material_Id)
                .Index(t => t.ServiceReport_Id);
            
            CreateTable(
                "Domain.ServiceCall",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceDate = c.DateTime(nullable: false),
                        ServiceTime = c.Time(nullable: false, precision: 7),
                        ServiceType_VacuumService = c.Boolean(nullable: false),
                        ServiceType_ChemicalCheck = c.Boolean(nullable: false),
                        ServiceType_SPAService = c.Boolean(nullable: false),
                        ServiceType_PolarisService = c.Boolean(nullable: false),
                        ServiceType_ServiceCall = c.Boolean(nullable: false),
                        ServiceType_Delivery = c.Boolean(nullable: false),
                        PoolCondition_ChlorineResidual = c.Single(nullable: false),
                        PoolCondition_FreeChlorine = c.Single(nullable: false),
                        PoolCondition_PHLevel = c.Single(nullable: false),
                        PoolCondition_TotalAlkalinity = c.Single(nullable: false),
                        PoolCondition_Turbidity = c.Single(nullable: false),
                        PoolCondition_CyanuricAcidLevel = c.Single(nullable: false),
                        PoolCondition_Temperature = c.Single(nullable: false),
                        AdditionalTime = c.Time(nullable: false, precision: 7),
                        DateModified = c.DateTime(),
                        DateCreated = c.DateTime(),
                        ServiceAddress_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.ServiceAddress", t => t.ServiceAddress_Id, cascadeDelete: true)
                .Index(t => t.ServiceAddress_Id);
            
            CreateTable(
                "Domain.ServiceAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateModified = c.DateTime(),
                        DateCreated = c.DateTime(),
                        Address_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.Address", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("Domain.Customer", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Address_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Domain.MaterialUsed", "ServiceReport_Id", "Domain.ServiceCall");
            DropForeignKey("Domain.ServiceCall", "ServiceAddress_Id", "Domain.ServiceAddress");
            DropForeignKey("Domain.ServiceAddress", "Customer_Id", "Domain.Customer");
            DropForeignKey("Domain.ServiceAddress", "Address_Id", "Domain.Address");
            DropForeignKey("Domain.MaterialUsed", "Material_Id", "Domain.Material");
            DropIndex("Domain.ServiceAddress", new[] { "Customer_Id" });
            DropIndex("Domain.ServiceAddress", new[] { "Address_Id" });
            DropIndex("Domain.ServiceCall", new[] { "ServiceAddress_Id" });
            DropIndex("Domain.MaterialUsed", new[] { "ServiceReport_Id" });
            DropIndex("Domain.MaterialUsed", new[] { "Material_Id" });
            DropTable("Domain.ServiceAddress");
            DropTable("Domain.ServiceCall");
            DropTable("Domain.MaterialUsed");
            DropTable("Domain.Material");
            DropTable("Domain.Customer");
            DropTable("Domain.Address");
        }
    }
}
