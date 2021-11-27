using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesMarketingTeamAPI.Models;

namespace SalesMarketingTeamAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employeeregistration>> GetEmployees();
        Task<Employeeregistration> GetEmployeebyId(int id);
        Task<int> AddEmployee(Employeeregistration employee);
        Task<int> UpdateEmployee(Employeeregistration employee);
    }
}
