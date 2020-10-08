using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitCloneService.DbInfra;

namespace twitCloneService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserController(
            IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(_userDataAccess.GetAllUsers());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
