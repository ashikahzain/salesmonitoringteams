using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMarketingTeamAPI.Models;
using SalesMarketingTeamAPI.ViewModel;

namespace SalesMarketingTeamAPI.Repository
{
    public class VisitTableRepository : IVisitTableRepository
    {
        SalesTeamMonitoringDBContext db;

        public VisitTableRepository(SalesTeamMonitoringDBContext db)
        {
            this.db = db;
        }
        //Get list of all visits
        public async Task<List<Visittable>> GetVisits()
        {
            if (db != null)
            {
                return await db.Visittable.ToListAsync();
            }
            return null;
        }


        public async Task<Visittable> GetVisitbyId(int id)
        {
            var visit = await db.Visittable.FirstOrDefaultAsync(v => v.VisitId == id);
            if (visit == null)
            {
                return null;
            }
            return visit;
        }

        public async Task<int> AddVisit(Visittable visit)
        {
            if (db != null)
            {
                await db.Visittable.AddAsync(visit);
                await db.SaveChangesAsync();
            }
            return visit.VisitId;
        }

        public async Task DeleteVisit(int id)
        {
           if(db!=null)
            {
                var emp = await db.Visittable.FirstOrDefaultAsync(em => em.EmpId == id);
                if (emp != null)
                {
                    emp.IsDeleted = false;
                    await db.SaveChangesAsync();
                }
               
            }
        }

        public async  Task DisableVisit(Visittable visit)
        {
            if (db != null)
            {
               
                if (visit != null)
                {
                    visit.IsDisabled = true;
                    db.Visittable.Update(visit);
                    await db.SaveChangesAsync();
                }

            }
        }

        public async Task<List<VisitViewModel>> GetVisitbyDate(DateTime date)
        {
            if (db != null)
            {
                return await (from visit in db.Visittable
                              join employee in db.Employeeregistration on visit.EmpId equals employee.EmpId
                              where visit.VisitDatetime==date
                              select new VisitViewModel
                              {
                                  VisitId=visit.VisitId,
                                  VisitDatetime=visit.VisitDatetime,
                                  CustName=visit.CustName,
                                  ContactPerson=visit.ContactPerson,
                                  ContactNo=visit.ContactNo,
                                  InterestProduct=visit.InterestProduct,
                                  VisitSubject=visit.VisitSubject,
                                  Description=visit.Description,
                                  IsDeleted=visit.IsDeleted,
                                  IsDisabled=visit.IsDisabled,
                                  EmpId=visit.EmpId,
                                  FirstName=employee.FirstName,
                                  LastName=employee.LastName
                                  
                              }).ToListAsync();

               
            }
            return null;
        }

        public async Task<Visittable> UpdateVisit(Visittable visit)
        {
            if (db != null)
            {
                db.Visittable.Update(visit);
                await db.SaveChangesAsync();
            }
            return visit;
        }
    }
}
