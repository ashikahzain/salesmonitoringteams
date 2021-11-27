using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesMarketingTeamAPI.Models;
using SalesMarketingTeamAPI.ViewModel;

namespace SalesMarketingTeamAPI.Repository
{
    public interface IVisitTableRepository
    {
        Task<List<Visittable>> GetVisits();
        Task<List<VisitViewModel>> GetVisitbyDate(DateTime date);
        Task<Visittable> GetVisitbyId(int id);
        Task<int> AddVisit(Visittable visit);
        Task<Visittable> UpdateVisit(Visittable visit);
        Task DisableVisit(Visittable visit);
        Task  DeleteVisit(int id);



    }
}
