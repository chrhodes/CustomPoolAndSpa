using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Common.Domain;
using CustomPoolAndSpa.Application.Interfaces;
using CustomPoolAndSpa.Domain;

using VNC;

namespace CustomPoolAndSpa.Data
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Address> Addresses { get; set; }

        public DatabaseService() : base("CustomPoolAndSpaDB")
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //Database.SetInitializer(new DatabaseInitializer());
            Database.SetInitializer<CustomPoolAndSpaDbContext>(
                new DropCreateDatabaseIfModelChanges<CustomPoolAndSpaDbContext>());

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            try
            {
                // TODO(crhodes)
                // This gives us too many types including the embedded ServiceType and PoolConditionReport
                // Need some way of filtering them out, otherwise have to put pointless IsDirty field in them.

                modelBuilder.Types()
                    .Configure(c => c.Ignore("IsDirty"));

            }
            catch (InvalidOperationException ex)
            {
                // Ignore
            }

            base.OnModelCreating(modelBuilder);

            // Do not pluralize table names

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public void Save()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            this.SaveChanges();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
