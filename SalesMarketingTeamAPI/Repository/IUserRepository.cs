using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMarketingTeamAPI.Models;

namespace SalesMarketingTeamAPI.Repository
{
    public interface IUserRepository
    {

        public Login GetUser(Login login);
        Task<ActionResult<Login>> GetUserByPassword(string un, string pwd);
        Login validateUser(string username, string password);
        Task<int> AddUser(Login login);
    }
}
