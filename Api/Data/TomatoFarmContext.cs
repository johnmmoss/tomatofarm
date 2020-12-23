using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFarm.Data
{
        [DbConfigurationType(typeof(MySqlEFConfiguration))]
        public class TomatoFarmContext: IdentityDbContext<User>
        {
            public TomatoFarmContext()
                : base("DefaultConnection")
            {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TomatoFarmContext, Migrations.Configuration>());
        }

        }
    }
