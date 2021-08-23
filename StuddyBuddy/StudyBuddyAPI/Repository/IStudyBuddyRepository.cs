using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyBuddyAPI.Models;

namespace StudyBuddyAPI.Repository
{
    public interface IStudyBuddyRepository
    {
        #region Users
        User GetUser(string username);
        List<User> GetUsers();
        bool IsUniqueUser(string username);
        bool Authenticated(string username, string password);
        User Register(User user);
        bool ActivateUser(string username);

        #endregion

        #region Modules

        List<Module> GetModules();
        List<Module> GetModulesPerUser(string username);
        Module GetModuleByName(string moduleName);
        Module GetModuleByUniqueId(int uniqueId);

        Module InsertModule(Module module);
        Module UpdateModule(Module module);
        bool RemoveModule(int uniqueId);

        #endregion

        #region Tasks

        List<Models.Task> GetTasksPerModule(Module module);
        Models.Task GetTaskByUniqueId(int uniqueId);
        Models.Task InsertTask(Models.Task task);
        Models.Task UpdateTask(Models.Task task);
        bool RemoveTask(Models.Task task);

        #endregion

        #region Roles

        //Phase 2 will implement Administrator functions for access to admin sections

        #endregion
    }
}
