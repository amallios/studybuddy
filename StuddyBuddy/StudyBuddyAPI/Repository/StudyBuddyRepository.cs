using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using StudyBuddyAPI.Data;
using StudyBuddyAPI.Models;
using Task = StudyBuddyAPI.Models.Task;

namespace StudyBuddyAPI.Repository
{
    public class StudyBuddyRepository : IStudyBuddyRepository
    {
        studybuddyContext db;
        public StudyBuddyRepository(studybuddyContext _db)
        {
            db = _db;
        }

        #region Users
        /// <summary>
        /// Get User account based on username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            if (db != null)
            {
                return db.Users.FirstOrDefault(x => x.Username == username);
            }

            return null;
        }

        /// <summary>
        /// Return all user accounts
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            if (db != null)
            {
                return db.Users.ToList();
            }

            return null;
        }

        /// <summary>
        /// Check if the user does not allready exist before adding
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsUniqueUser(string username)
        {
            if (db != null)
            {
                if (GetUser(username) == null)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Authenticate the users against the username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticated(string username, string password)
        {
            if (db != null)
            {
                var passwordEncrypted = Functions.ToSHA256(password);
                var usern = GetUser(username);

                if (usern != null && usern.Password == passwordEncrypted)
                    return true;

            }

            return false;
        }

        /// <summary>
        /// Register the user by checking if user does not exist and encrypt password and save user with active = false
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Register(User user)
        {
            if (db != null)
            {
                //Check if the user exist and is uniqueue
                if (IsUniqueUser(user.Username))
                {
                    //Encrypt and save password
                    user.Password = Functions.ToSHA256(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();

                    //Add role to user
                    db.UserRoles.Add(new UserRole { RoleId = 1, UserId = user.UniqueId });
                    db.SaveChanges();
                }

                Functions.SendEmail(user, Functions.EmailTemplates.Register);

                return user;
            }

            return null;
        }

        /// <summary>
        /// Activate a user based on the username being sent via a link in the email 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ActivateUser(string username)
        {
            var user = GetUser(username);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            user.Active = true;
            db.Users.Update(user);
            db.SaveChanges();

            return true;

        }

        #endregion

        #region Modules

        /// <summary>
        /// Get all Modules
        /// </summary>
        /// <returns></returns>
        public List<Module> GetModules()
        {
            if (db != null)
            {
                return db.Modules.ToList();
            }

            return null;
        }

        /// <summary>
        /// Get Moduoles a user had added
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<Module> GetModulesPerUser(string username)
        {
            if (db != null)
            {
                var modules = db.UsersModules.Where(x => x.UserId == db.Users.FirstOrDefault(u => u.Username == username).UniqueId).Select(y => y.Module).ToList();

                return modules;
            }

            return null;
        }

        /// <summary>
        /// Get Module by Name
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public Module GetModuleByName(string moduleName)
        {
            if (db != null)
            {
                return db.Modules.FirstOrDefault(x => x.Name == moduleName);
            }

            return null;
        }

        /// <summary>
        /// Get Module by Unique ID
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public Module GetModuleByUniqueId(int uniqueId)
        {
            if (db != null)
            {
                return db.Modules.FirstOrDefault(x => x.UniqueId == uniqueId);
            }

            return null;
        }

        /// <summary>
        /// Insert Module
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public Module InsertModule(Module module)
        {
            if (db != null)
            {
                db.Modules.Add(module);
                db.SaveChanges();

                return module;
            }

            return null;
        }

        /// <summary>
        /// Update Modules
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public Module UpdateModule(Module module)
        {
            if (db != null)
            {
                db.Modules.Update(module);
                db.SaveChanges();

                return module;
            }

            return null;
        }

        /// <summary>
        /// Remove Module
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public bool RemoveModule(int uniqueId)
        {
            if (db != null)
            {
                db.Modules.Remove(db.Modules.FirstOrDefault(x => x.UniqueId == uniqueId));
                db.SaveChanges();

                return true;
            }

            return false;
        }

        #endregion

        #region Tasks
        /// <summary>
        /// Get Task per module
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public List<Task> GetTasksPerModule(Module module)
        {
            if (db != null)
            {
                List<Task> tasks = db.Tasks.Where(x => x.ModuleId == module.UniqueId).ToList();

                return tasks;
            }

            return null;
        }

        /// <summary>
        /// Get Task by Id
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public Task GetTaskByUniqueId(int uniqueId)
        {
            if (db != null)
            {
                Task tasks = db.Tasks.FirstOrDefault(x => x.UniqueId == uniqueId);

               return tasks;
            }

            return null;
        }

        /// <summary>
        /// Insert new Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public Task InsertTask(Task task)
        {
            if (db != null)
            {
                db.Tasks.Add(task);
                db.SaveChanges();

                return task;
            }

            return null;
        }

        /// <summary>
        /// Update Taks
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public Task UpdateTask(Task task)
        {
            if (db != null)
            {
                db.Tasks.Update(task);
                db.SaveChanges();

                return task;
            }

            return null;
        }

        /// <summary>
        /// Remove Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public bool RemoveTask(Task task)
        {
            if (db != null)
            {
                db.Tasks.Remove(db.Tasks.FirstOrDefault(x => x.UniqueId == task.UniqueId));
                db.SaveChanges();

                return true;
            }

            return false;
        }


        #endregion
    }
}
