using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFarm.Data
{
    public class TomatoFarmContext : IdentityDbContext<User>
    {
        public TomatoFarmContext()
            : base("DefaultConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TomatoFarmContext, Migrations.Configuration>());
        }

    }
}
