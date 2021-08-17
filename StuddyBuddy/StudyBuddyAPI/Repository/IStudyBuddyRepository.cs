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
        #region User Section
        User GetUser(string username);
        List<User> GetUsers();
        bool IsUniqueUser(string username);
        bool Authenticated(string username, string password);
        User Register(User user);
        bool ActivateUser(string username);

        #endregion

        #region Roles

        #endregion

        #region Modules

        #endregion

        #region Tasks

        #endregion
    }
}
