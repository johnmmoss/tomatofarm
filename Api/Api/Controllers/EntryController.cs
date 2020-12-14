using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using tomatofarm.co.uk.Models;
using TomatoFarm.Data;

namespace tomatofarm.co.uk.Controllers
{
    public class EntryController : ApiController
    {
        // http://localhost:55021/api/entry/B4376B7A-6718-4151-976E-4FE527998C1A
        public IHttpActionResult Get(Guid? id)
        {
            User user;
            if (id.HasValue)
            {
                try
                {
                    using (var context = new TomatoContext())
                    {
                        var allUsers = context.Users.Include("Entries").ToList();
                        user = allUsers
                                .Where(x => x.Accessor.ToString().ToLower() == id.Value.ToString().ToLower())
                                .FirstOrDefault();

                        if (user != null)
                        {
                            var userEntryModel = new UserEntryModel();

                            userEntryModel.Accessor = user.Accessor;
                            userEntryModel.Entries = user.Entries.Select(x => new EntryModel()
                            {

                                ID = x.ID,
                                Date = x.Date,
                                Period = x.Period

                            }).ToList();

                            return Ok(userEntryModel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            return BadRequest();
        }
    }
}
