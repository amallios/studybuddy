using System.Collections.Generic;
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

        [TestMethod] public void GetAllUsers()
        {
            //User testUsers = new User();

            //var controller = new UserController(_logger,studybuddyRepository);

            //var result = controller.GetUsers() as List<User>;

            //Assert.Equals(result.Count, result.Count);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
