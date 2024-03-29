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
using Task = StudyBuddyAPI.Models.Task;


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
        [Route("GetTasksPerModule")]
        public IActionResult GetTasksPerModule(int moduleId)
        {
            try
            {
                List<Task> tasks = studybuddyRepository.GetTasksPerModule(moduleId);
                if (tasks == null)
                {
                    return NotFound();
                }

                return Ok(tasks);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetTaskByUniqueId")]
        public IActionResult GetTaskByUniqueId(int uniqueId)
        {
            try
            {
                Task task = studybuddyRepository.GetTaskByUniqueId(uniqueId);
                if (task == null)
                {
                    return NotFound();
                }

                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("InsertTask")]
        public IActionResult InsertTask(string taskName, DateTime startDate, DateTime endDate, string type, int moduleId)
        {
            try
            {
                Task taskInserted = studybuddyRepository.InsertTask(new Task(){ Name  = taskName, StartDate = startDate, EndDate = endDate, Type = type, Completed = false, ModuleId = moduleId});
                if (taskInserted == null)
                {
                    return NotFound();
                }

                return Ok(taskInserted);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("UpdateTask")]
        public IActionResult UpdateTask(int taskId,string taskName, DateTime startDate, DateTime endDate, string type, int moduleId, bool completed)
        {
            try
            {
                Task taskUpdated = studybuddyRepository.UpdateTask(new Task() { UniqueId = taskId, Name = taskName, StartDate = startDate, EndDate = endDate, Type = type, Completed = false, ModuleId = moduleId });
                if (taskUpdated == null)
                {
                    return NotFound();
                }

                return Ok(taskUpdated);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("RemoveTask")]
        public IActionResult RemoveTask(int uniqueId)
        {
            try
            {
                bool taskRemoved = studybuddyRepository.RemoveTask(uniqueId);
                if (taskRemoved == false)
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