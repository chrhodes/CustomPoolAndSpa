using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VNC;

namespace CustomPoolAndSpa.Data
{
    public class CustomPoolAndSpaDatabaseInitializer : CreateDatabaseIfNotExists<CustomPoolAndSpaDbContext>
    {
        protected override void Seed(CustomPoolAndSpaDbContext context)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            Console.WriteLine("Seed(CustomPoolAndSpaDbContext)");
            base.Seed(context);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
