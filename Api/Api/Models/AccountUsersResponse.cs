using System.Collections.Generic;
using System.Linq;
using TomatoFarm.Data;

namespace TomatoFarm.Api.Models
{
    public class AccountUsersResponse
    {
        public List<UserModel> Users { get; private set; }

        public AccountUsersResponse(List<User> users)
        {
            Users = users.Select(x => new UserModel { Email = x.Email }).ToList();
        }

        public class UserModel
        {
            public string Email { get; set; }
        }
    }
}
