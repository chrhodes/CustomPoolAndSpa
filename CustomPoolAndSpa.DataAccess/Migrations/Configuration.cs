namespace CustomPoolAndSpa.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using CustomPoolAndSpa.Domain;
    using global::Common.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomPoolAndSpaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // TODO(crhodes)
        // Decide how to use this.  Maybe just for the base data like Address, Customer, ServiceAddress, and Material.
        //
        // Have another method that creates the ServiceReport hierarchy
        //  ServiceAddress
        //      ServiceReport
        //          PoolConditionReport
        //          MaterialUsed
        //              Material

        ServiceAddress CreateServiceAddress(CustomPoolAndSpaDbContext context, int id, Customer customer, Address address)
        {
            var serviceAddress = new ServiceAddress
            {
                Id = id,
                Customer = customer,
                Address = address
            };

            context.ServiceAddressSet.AddOrUpdate(serviceAddress);

            return serviceAddress;
        }

        protected override void Seed(CustomPoolAndSpaDbContext context)
        {
            Console.WriteLine("Seed()");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // This Seeds Address, Customer, and Material

            SeedAddressCustomerMaterialTables(context);

            // Customers

            var vikki = context.CustomerSet.Find(1);
            var natalie = context.CustomerSet.Find(2);
            var christopher = context.CustomerSet.Find(3);

            // Addresses

            var hillrise = context.AddressSet.Find(1);
            var woodyhills = context.AddressSet.Find(2);
            var pheasanttrail = context.AddressSet.Find(3);

            // Vikki has one pool

            var serviceAddress1 = CreateServiceAddress(context, 1, vikki, hillrise);

            if (serviceAddress1.Id != 1)
            {
                throw new Exception("WTF Id not equal to 1");          
            }

            // Christopher has two pools

            var serviceAddress2 = CreateServiceAddress(context, 2, christopher, hillrise);

            if (serviceAddress2.Id != 2)
            {
                throw new Exception("WTF Id not equal to 2");
            }

            var serviceAddress3 = CreateServiceAddress(context, 3, christopher, woodyhills);

            if (serviceAddress3.Id != 3)
            {
                throw new Exception("WTF Id not equal to 3");
            }

            // Added this from Program.cs

            var mat1 = context.MaterialSet.Find(1);
            var mat2 = context.MaterialSet.Find(2);
            var mat3 = context.MaterialSet.Find(3);
            var mat4 = context.MaterialSet.Find(4);

            var poolConditionReport1 = new PoolCondition();

            poolConditionReport1.ChlorineResidual = 2;
            poolConditionReport1.CyanuricAcidLevel = 35;
            poolConditionReport1.FreeChlorine = 1;
            poolConditionReport1.PHLevel = 7.4F;
            poolConditionReport1.Temperature = 87.3F;
            poolConditionReport1.TotalAlkalinity = 160;
            poolConditionReport1.Turbidity = 1;

            var serviceCall = new ServiceCall
            {
                ServiceAddress = serviceAddress1,
                ServiceDate = DateTime.Now,
                ServiceTime = new TimeSpan(1, 2, 3),
                PoolCondition = poolConditionReport1
            };

            var mu1 = new MaterialUsed
            {
                //Id = 3,
                Material = mat3,
                Quantity = 3,
                ServiceReport = serviceCall
            };

            var mu2 = new MaterialUsed
            {
                //Id = 4,
                Material = mat4,
                Quantity = 4.9F,
                ServiceReport = serviceCall
            };

            // This doesn't get rows added.

            serviceCall.MaterialsUsed.Add(mu1);
            serviceCall.MaterialsUsed.Add(mu2);

            // But if we tell the context about them directly it works
            // The EF6 course suggests otherwise.

            context.MaterialUsedSet.Add(mu1);
            context.MaterialUsedSet.Add(mu2);

            // Or here

            context.ServiceCallSet.Add(serviceCall);

            serviceCall.ServiceType.ChemicalCheck = true;

            context.SaveChanges();

            base.Seed(context);
        }

        private static void SeedAddressCustomerMaterialTables(CustomPoolAndSpaDbContext context)
        {
            context.AddressSet.AddOrUpdate(
                i => i.Id,
                new Address
                {
                    Id = 1,
                    Address1 = "43 Hillrise",
                    City = "Dove Canyon",
                    State = "CA",
                    ZipCode = "92679"
                },
                new Address
                {
                    Id = 2,
                    Address1 = "1545 Woody Hills Dr.",
                    City = "El Cajon",
                    State = "CA",
                    ZipCode = "92019"
                },
                new Address
                {
                    Id = 3,
                    Address1 = "2???? Pheasant Trail",
                    City = "Wauconda",
                    State = "IL",
                    ZipCode = "60084"
                }
                );

            context.CustomerSet.AddOrUpdate(
                i => i.Id,
                new Customer
                {
                    Id = 1,
                    Title = "Empress",
                    FirstName = "Vikki",
                    LastName = "Schanz",
                    CellPhone = "714-287-5719",
                    HomePhone = "Home Phone",
                    MainPhone = "Main Phone",
                    WorkPhone = "Work Phone"
                },
                new Customer { Id = 2, FirstName = "Natalie", LastName="Rhodes", CellPhone = "949-525-0103" },
                new Customer { Id = 3, FirstName = "Christopher", LastName="Rhodes", CellPhone = "949-540-4431" },
                new Customer { Id = 4, FirstName = "Paul", LastName= "Schanz" },
                new Customer { Id = 5, FirstName = "George Lachow" },
                new Customer { Id = 6, FirstName = "Tim", LastName="Lachow" },
                new Customer { Id = 7, FirstName = "Diane", LastName= "" },
                new Customer { Id = 8, CompanyName = "VNC", MainPhone = "<Don't Bother Calling>" },
                new Customer { Id = 9, CompanyName = "CustomPoolAndSpa", FirstName = "Paul", LastName = "Schanz" }
                );

            context.MaterialSet.AddOrUpdate(
                i => i.Id,
                new Material
                {
                    Id = 1,
                    ItemName = "MaterialA",
                    Description = "Material A Description",
                    UnitPrice = 3.5M
                },
                new Material { Id = 2, ItemName = "MaterialB", Description = "Material B Description", UnitPrice = 1.3M },
                new Material { Id = 3, ItemName = "MaterialC", Description = "Material C Description", UnitPrice = 34M },
                new Material { Id = 4, ItemName = "MaterialD", Description = "Material D Description", UnitPrice = 3.5M }
                );
        }
    }
}
