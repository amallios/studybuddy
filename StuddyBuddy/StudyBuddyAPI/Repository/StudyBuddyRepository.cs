using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudyBuddyAPI.Data;
using StudyBuddyAPI.Models;

namespace StudyBuddyAPI.Repository
{
    public class StudyBuddyRepository : IStudyBuddyRepository
    {
        studybuddyContext db;
        public StudyBuddyRepository(studybuddyContext _db)
        {
            db = _db;
        }

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
                    db.UserRoles.Add(new UserRole {RoleId = 1, UserId = user.UniqueId});
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
    }
}
