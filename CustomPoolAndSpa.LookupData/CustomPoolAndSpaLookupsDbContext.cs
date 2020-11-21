using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CustomPoolAndSpa.Domain.Lookups;

using VNC;

namespace CustomPoolAndSpa.LookupData
{
    public class CustomPoolAndSpaLookupsDbContext : DbContext
    {
        public DbSet<ChlorineLevel> ChlorineLevelSet { get; set; }

        public DbSet<Cities> CitiesSet { get; set; }

        public DbSet<CombinedChlorinePPM> CombinedChlorinePPMSet { get; set; }

        public DbSet<CyanuricAcidPPM> CyanuricAcidPPMSet { get; set; }

        public DbSet<FilteredBackwash> FilteredBackwashSet { get; set; }

        public DbSet<MainDrainVisible> MainDrainVisibleSet { get; set; }

        public DbSet<Months> MonthsSet { get; set; }

        public DbSet<PHRange> PHRangeSet { get; set; }

        public DbSet<Units> UnitsSet { get; set; }

        public DbSet<Years> YearsSet { get; set; }

        public CustomPoolAndSpaLookupsDbContext() : base("CustomPoolAndSpaDB")
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomPoolAndSpaDbContext, Configuration>());

            // There are four database initialization strategies

            // 1. CreateDatabaseIfNotExists (default)

            // Database.SetInitializer<CustomPoolAndSpaDbContext>(new CreateDatabaseIfNotExists<CustomPoolAndSpaDbContext>());

            // 2. DropCreateDatabaseIfModelChanges

            // Database.SetInitializer<CustomPoolAndSpaDbContext>(new DropCreateDatabaseIfModelChanges<CustomPoolAndSpaDbContext>());

            Database.SetInitializer<CustomPoolAndSpaLookupsDbContext>(
                new DropCreateDatabaseIfModelChanges<CustomPoolAndSpaLookupsDbContext>());

            // 3. DropCreateDatabaseAlways

            // Database.SetInitializer<CustomPoolAndSpaDbContext>(new DropCreateDatabaseAlways<CustomPoolAndSpaDbContext>());

            // 4. Custom DB Initializer

            //Database.SetInitializer<CustomPoolAndSpaDbContext>(new CustomPoolAndSpaDatabaseInitializer());

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);
            //try
            //{
            //    // TODO(crhodes)
            //    // This gives us too many types including the embedded ServiceType and PoolConditionReport
            //    // Need some way of filtering them out, otherwise have to put pointless IsDirty field in them.

            //    modelBuilder.Types()
            //        .Configure(c => c.Ignore("IsDirty"));

            //}
            //catch (InvalidOperationException ex)
            //{
            //    // Ignore
            //}

            base.OnModelCreating(modelBuilder);

            // Do not pluralize table names

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("Lookup");

            // Ignore any IsDirty property on any types pulled into model.



            // Fluent API approach to constraints
            // Alternative is to apply attributes to Model Class

            //modelBuilder.Entity<Friend>()
            //    .Property(f => f.FirstName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            // Could also have a general purpose approach. See class infra.

            //modelBuilder.Configurations.Add(new FriendConfiguration());

            // Alternatively can use DataAnnotations on model class.

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
