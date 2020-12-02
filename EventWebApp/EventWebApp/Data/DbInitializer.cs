using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventWebApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(EventDualAppContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
