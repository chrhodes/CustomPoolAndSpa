namespace CustomPoolAndSpa.LookupData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using VNC;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomPoolAndSpa.LookupData.CustomPoolAndSpaLookupsDbContext>
    {
        public Configuration()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            AutomaticMigrationsEnabled = false;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        protected override void Seed(CustomPoolAndSpa.LookupData.CustomPoolAndSpaLookupsDbContext context)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
