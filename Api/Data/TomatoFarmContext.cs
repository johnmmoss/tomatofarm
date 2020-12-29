using TomatoFarm.Data.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TomatoFarm.Data
{
    public class TomatoFarmContext : IdentityDbContext<User>
    {
        public TomatoFarmContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TomatoFarmContext, Configuration>());
        }

        public static TomatoFarmContext Create()
        {
            return new TomatoFarmContext();
        }
    }
}
