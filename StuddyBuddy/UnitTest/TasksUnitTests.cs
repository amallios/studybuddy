using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyBuddyAPI.Controllers;
using StudyBuddyAPI.Models;
using StudyBuddyAPI.Repository;

namespace UnitTest
{
    [TestClass]
    public class TasksUnitTests
    {
        [TestMethod]
        public void GetTasksPerModule()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void GetTaskByUniqueId()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void InsertTask()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void UpdateTask()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void RemoveTask()
        {
            Thread.Sleep(new Random().Next(10));
        }
    }
}
