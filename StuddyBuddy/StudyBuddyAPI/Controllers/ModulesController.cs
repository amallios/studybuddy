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
            try
            {
                List<Module> module = studybuddyRepository.GetModules();
                if (module == null)
                {
                    return NotFound();
                }

                return Ok(module);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetModulesPerUser")]
        public IActionResult GetModulesPerUser(string username)
        {
            try
            {
                List<Module> module = studybuddyRepository.GetModulesPerUser(username);
                if (module == null)
                {
                    return NotFound();
                }

                return Ok(module);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetModuleByName")]
        public IActionResult GetModuleByName(string moduleName)
        {
            try
            {
                Module module = studybuddyRepository.GetModuleByName(moduleName);
                if (module == null)
                {
                    return NotFound();
                }

                return Ok(module);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetModuleByUniqueId")]
        public IActionResult GetModuleByUniqueId(int moduleId)
        {
            try
            {
                Module module = studybuddyRepository.GetModuleByUniqueId(moduleId);
                if (module == null)
                {
                    return NotFound();
                }

                return Ok(module);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("InsertModule")]
        public IActionResult InsertModule(string moduleName, DateTime startDate, DateTime endDate, int userId)
        {
            try
            {
                Module moduleAdded = studybuddyRepository.InsertModule(new Module(){ Name = moduleName, StartDate = startDate, EndDate = endDate, Completed = false}, userId);
                if (moduleAdded == null)
                {
                    return NotFound();
                }

                return Ok(moduleAdded);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("UpdateModule")]
        public IActionResult UpdateModule(int moduleId, string moduleName, DateTime startDate, DateTime endDate, bool completed)
        {
            try
            {
                Module moduleUpdated = studybuddyRepository.UpdateModule(new Module(){ UniqueId = moduleId, Name = moduleName, StartDate = startDate, EndDate = endDate, Completed = completed });
                if (moduleUpdated == null)
                {
                    return NotFound();
                }

                return Ok(moduleUpdated);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("RemoveModule")]
        public IActionResult RemoveModule(int moduleId, int userId)
        {
            try
            {
                bool moduleRemove = studybuddyRepository.RemoveModule(moduleId, userId);
                if (moduleRemove == false)
                {
                    return NotFound();
                }

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
