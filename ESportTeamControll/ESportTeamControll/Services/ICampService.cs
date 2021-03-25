using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public interface ICampService
    {
        List<Camp> GetAll();
        void Insert(Camp camp);
        Camp Search(int id);
        void Update(Camp camp);
        void Delete(int id);
        IEnumerable<SelectListItem> ReturnTeams();
        IEnumerable<SelectListItem> ReturnTeams(int id);
    }
}