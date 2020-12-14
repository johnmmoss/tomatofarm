using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var now = DateTime.Now;

            return Ok($"{now.ToLongDateString()} {now.ToShortDateString()}");
        }
    }
}
