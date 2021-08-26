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

        Module InsertModule(Module module, int userId);
        Module UpdateModule(Module module);
        bool RemoveModule(int uniqueId, int userId);

        #endregion

        #region Tasks

        List<Models.Task> GetTasksPerModule(int moduleId);
        Models.Task GetTaskByUniqueId(int uniqueId);
        Models.Task InsertTask(Models.Task task);
        Models.Task UpdateTask(Models.Task task);
        bool RemoveTask(int uniqueId);

        #endregion

        #region Roles

        //Phase 2 will implement Administrator functions for access to admin sections

        #endregion
    }
}
