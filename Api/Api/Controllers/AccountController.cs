using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TomatoFarm.Api.Identity;
using TomatoFarm.Api.Models;
using TomatoFarm.Data;

namespace TomatoFarm.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private ApplicationUserManager _applicationUserManager = null;
        protected ApplicationUserManager ApplicationUserManager
        {
            get
            {
                return _applicationUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [Route("register")]
        public async Task<IHttpActionResult> CreateUser(AccountCreateRequest accountCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                UserName = accountCreateRequest.Email,
                Email = accountCreateRequest.Email,
            };

            IdentityResult addUserResult = await this.ApplicationUserManager.CreateAsync(user, accountCreateRequest.Password);

            if (!addUserResult.Succeeded)
            {
                return BadRequest();
            }

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            var response = new AccountCreateResponse
            {
                Email = user.Email
            };

            return Created(locationHeader, response);
        }

        [Authorize]
        [Route("users", Name = "GetUsers")]
        public IHttpActionResult GetUsers()
        {
            var users = ApplicationUserManager.Users.ToList();
            var response = new AccountUsersResponse(users);
            return Ok(response);
        }

        [Authorize]
        [Route("users/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            var user = await this.ApplicationUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                var response = new AccountUserResponse();
                response.Email = user.Email;
                return Ok(response);
            }

            return NotFound();

        }

        [Authorize]
        [Route("users/{email}", Name = "GetUserByEmail")]
        public async Task<IHttpActionResult> GetUserByName(string email)
        {
            var user = await this.ApplicationUserManager.FindByNameAsync(email);

            if (user != null)
            {
                var response = new AccountUserResponse();
                response.Email = user.Email;
                return Ok(response);
            }

            return NotFound();
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

    }
}
