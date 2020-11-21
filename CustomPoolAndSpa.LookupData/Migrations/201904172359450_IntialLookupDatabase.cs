namespace CustomPoolAndSpa.LookupData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialLookupDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Lookup.ChlorineLevel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.CombinedChlorinePPM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.CyanuricAcidPPM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.FilteredBackwash",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.MainDrainVisible",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.Months",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.PHRange",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Lookup.Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayMember = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Lookup.Years");
            DropTable("Lookup.Units");
            DropTable("Lookup.PHRange");
            DropTable("Lookup.Months");
            DropTable("Lookup.MainDrainVisible");
            DropTable("Lookup.FilteredBackwash");
            DropTable("Lookup.CyanuricAcidPPM");
            DropTable("Lookup.CombinedChlorinePPM");
            DropTable("Lookup.Cities");
            DropTable("Lookup.ChlorineLevel");
        }
    }
}
