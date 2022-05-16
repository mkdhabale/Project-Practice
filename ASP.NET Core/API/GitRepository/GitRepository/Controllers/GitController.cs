using GitRepository.Helpers.CustomeModelBinder;
using GitRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitController : ControllerBase
    {
        private readonly IGitServices _gitServices;

        public GitController(IGitServices gitServices)
        {
            _gitServices = gitServices;
        }
        [HttpGet("")]
        //[Route("GetUsers")]
        //custome Model binder is added for adapt future enhancement for multiple fitlers
        public async Task<IActionResult> RetrieveUsers([ModelBinder(BinderType = typeof(ListArrayModelBinder))] List<string> usernames)
        {
            if (usernames == null)
                return BadRequest("Please check usernames.");
            var users = await _gitServices.RetrieveUsers(usernames);
            if (users is null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        

        /* 
        //add for only testing purponse of unit test
        [HttpGet("")]
        [Route("Add")]
        public int Add(int x1, int x2)
        {
            return _gitServices.AddValue(x1, x2);
        }*/

    }
}
