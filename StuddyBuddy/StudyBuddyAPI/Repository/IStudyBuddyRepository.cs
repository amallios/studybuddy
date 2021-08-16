using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyBuddyAPI.Models;

namespace StudyBuddyAPI.Repository
{
    public interface IStudyBuddyRepository
    {
        #region User Section
        User GetUser(string username);
        Task<List<User>> GetUsers();
        bool IsUniqueUser(string username);
        User Authenticate(string username, string password);
        User Register(string username, string password);
        bool ActivateUser(string username, string token);
        #endregion

        #region Roles
        #endregion

        #region Modules
        #endregion

        #region Tasks
        #endregion
    }
}
