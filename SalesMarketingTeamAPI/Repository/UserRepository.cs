using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesMarketingTeamAPI.Models;

namespace SalesMarketingTeamAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        SalesTeamMonitoringDBContext db;

        public UserRepository(SalesTeamMonitoringDBContext db)
        {
            this.db = db;
        }

        //Get user using the given data
        public Login GetUser(Login login)
        {
            if (db != null)
            {
                Login user = db.Login.FirstOrDefault(em => em.UserName == login.UserName && em.Password == login.Password);
                return user;
            }
            return null;
        }

        public async Task<ActionResult<Login>> GetUserByPassword(string un, string pwd)
        {
            var user = await db.Login.FirstOrDefaultAsync(em => em.UserName == un && em.Password == pwd);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public Login validateUser(string username, string password)
        {
            if (db != null)
            {
                Login login = db.Login.FirstOrDefault(em => em.UserName == username && em.Password == password);
                if (login != null)
                {
                    return login;
                }
            }
            return null;
        }
        public async Task<int> AddUser(Login login)
        {
            if (db != null)
            {
                await db.Login.AddAsync(login);
                await db.SaveChangesAsync();
            }
            return login.LId;
        }

  
    }
}
