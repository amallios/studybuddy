using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using StudyBuddyAPI.Models;
using StudyBuddyAPI.Repository;


namespace StudyBuddyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : ControllerBase
    {
        readonly IStudyBuddyRepository studybuddyRepository;

        private readonly ILogger<UserController> _logger;

        public ModuleController(ILogger<UserController> logger, IStudyBuddyRepository _studyBuddyRepository)
        {
            _logger = logger;
            studybuddyRepository = _studyBuddyRepository;
        }

        [HttpGet]
        [Route("GetModules")]
        public IActionResult GetModules()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("GetModulesPerUser")]
        public IActionResult GetModulesPerUser(string username)
        {
            try
            {
                var module = studybuddyRepository.GetModulesPerUser(username);
                if (module == null)
                {
                    return NotFound();
                }

                return Ok(module);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
