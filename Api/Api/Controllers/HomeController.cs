using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TomatoFarm.Data;

namespace TomatoFarm.Api.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("ping")]
        public IHttpActionResult Get()
        {
            var now = DateTime.Now;

            return Ok($"{now.ToLongDateString()} {now.ToShortDateString()}");
        }

        [HttpGet]
        [Route("migrate")]
        public IHttpActionResult Migrate()
        {
            using (var context = new TomatoFarmContext())
            {
                var users = context.Users.ToList();
            }

            return Ok("done");
        }
    }
}
