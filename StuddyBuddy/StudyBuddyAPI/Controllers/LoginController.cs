using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyBuddyAPI.Repository;

namespace StudyBuddyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        IStudyBuddyRepository studybuddyRepository;

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, IStudyBuddyRepository _studyBuddyRepository)
        {
            _logger = logger;
            studybuddyRepository = _studyBuddyRepository;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await studybuddyRepository.GetUsers();
                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
