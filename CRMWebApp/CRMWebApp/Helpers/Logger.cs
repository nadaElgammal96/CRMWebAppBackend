using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMWebApp.Helpers
{
    public class Logger
    {
        public Logger()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                             .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day)
                             .CreateLogger();
        }
    }
}
