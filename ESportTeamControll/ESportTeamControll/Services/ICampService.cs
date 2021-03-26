using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public interface ICampService
    {
        List<Camp> GetAll();
        void Insert(Camp camp, string[] selectedTeams);
        Team GetTeam(int id);
        Camp Search(int id);
        void Update(Camp camp, string[] selectedTeams);
        void Delete(int id);
        List<Team> ReturnTeams();
        IEnumerable<SelectListItem> ReturnTeams(int id);
    }
}