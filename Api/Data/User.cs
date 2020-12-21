using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace TomatoFarm.Data
{
    public class User : IdentityUser
    {
        public string StarRating { get; set; }

        public virtual ICollection<Tomato> Tomatos { get; set; }
    }
}
