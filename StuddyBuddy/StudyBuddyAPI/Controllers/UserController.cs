﻿using Microsoft.AspNetCore.Mvc;
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
    public class UserController : ControllerBase
    {
        readonly IStudyBuddyRepository studybuddyRepository;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IStudyBuddyRepository _studyBuddyRepository)
        {
            _logger = logger;
            studybuddyRepository = _studyBuddyRepository;
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = studybuddyRepository.GetUsers();
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

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(string username)
        {
            try
            {
                var user = studybuddyRepository.GetUser(username);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("SendEmail")]
        public IActionResult SendEmail(User user, Functions.EmailTemplates template)
        {
            try
            {
                Functions.SendEmail(user, template);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(true);
        }

        [HttpPost]
        [Route("ActivateUser")]
        public IActionResult ActivateUser(string username)
        {
            var activated = studybuddyRepository.ActivateUser(username);
            if (activated == true)
            {
                //return re("https://www.qarar.org");
                RedirectSuccess(username);
                return Ok(true);
            }
            else
            {
                throw new Exception("User could not be activated");
            }
        }

        [HttpGet]
        [Route("RedirectSuccess/{username}")]
        public IActionResult RedirectSuccess(string username)
        {
            return RedirectPermanent("https://www.qarar.org");
        }
    }
}
