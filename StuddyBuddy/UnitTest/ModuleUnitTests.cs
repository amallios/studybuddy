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
    public class ModuleUnitTests
    {
        [TestMethod]
        public void GetModules()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void GetModulesPerUser()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void GetModuleByName()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void GetModuleByUniqueId()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void InsertModule()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void UpdateModule()
        {
            Thread.Sleep(new Random().Next(10));
        }

        [TestMethod]
        public void RemoveModule()
        {
            Thread.Sleep(new Random().Next(10));
        }
    }
}
