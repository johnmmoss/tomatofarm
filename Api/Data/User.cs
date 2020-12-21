using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace TomatoFarm.Data
{
    public class User : IdentityUser
    {
        public int DefaultDuration { get; set; }

        public virtual ICollection<Tomato> Tomatos { get; set; }
    }
}
