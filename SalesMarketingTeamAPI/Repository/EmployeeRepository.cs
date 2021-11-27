using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMarketingTeamAPI.Models;

namespace SalesMarketingTeamAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        SalesTeamMonitoringDBContext db;

        public EmployeeRepository(SalesTeamMonitoringDBContext db)
        {
            this.db = db;
        }


        public async Task<List<Employeeregistration>> GetEmployees()
        {
            if (db != null)
            {
                return await db.Employeeregistration.ToListAsync();
            }
            return null;
        }


        public async Task<Employeeregistration> GetEmployeebyId(int id)
        {
            var emp = await db.Employeeregistration.FirstOrDefaultAsync(em => em.EmpId == id);
            if (emp == null)
            {
                return null;
            }
            return emp;
        }

        public async Task<int> AddEmployee(Employeeregistration employee)
        {
            if (db != null)
            {
                await db.Employeeregistration.AddAsync(employee);
                await db.SaveChangesAsync();
            }
            return employee.EmpId;
        }


        public async Task<int> UpdateEmployee(Employeeregistration employee)
        {
            if (db != null)
            {
                db.Employeeregistration.Update(employee);
                await db.SaveChangesAsync();
            }
            return employee.EmpId;
        }
    }
}
