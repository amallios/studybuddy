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
    public class TaskController : ControllerBase
    {
        readonly IStudyBuddyRepository studybuddyRepository;

        private readonly ILogger<UserController> _logger;

        public TaskController(ILogger<UserController> logger, IStudyBuddyRepository _studyBuddyRepository)
        {
            _logger = logger;
            studybuddyRepository = _studyBuddyRepository;
        }

        [HttpGet]
        [Route("GetModules")]
        public IActionResult GetTasks()
        {
            return Ok();
        }
    }
}