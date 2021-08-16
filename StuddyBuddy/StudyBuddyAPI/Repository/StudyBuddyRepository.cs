using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsers()
        {
            if (db != null)
            {
                return await db.Users.ToListAsync();
            }

            return null;
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User Register(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool ActivateUser(string username, string token)
        {
            throw new NotImplementedException();
        }
    }
}
