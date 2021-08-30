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
    public class UserUnitTests
    {
        IStudyBuddyRepository studybuddyRepository;

        private readonly ILogger<UserController> _logger;

        [TestMethod] 
        public void GetUsers()
        {
            User testUsers = new User();

            var controller = new UserController(_logger, studybuddyRepository);

            var result = controller.GetUsers() as List<User>;

            Assert.Equals(result.Count, 2);
        }

        [TestMethod]
        public void GetUser()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void CreateUser()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void SendEmail()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void Authenticate()
        {
            Thread.Sleep(new Random().Next(10));
        }
    }
}
