using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public class CampService : ICampService
    {
        private ESportTeamContext _db = new ESportTeamContext();

        public List<Camp> GetAll()
        {
            return _db.Camps.ToList();
        }
        public Team GetTeam(int id)
        {
            return _db.Teams.First(x => x.Id == id);
        }
        public void Insert(Camp camp, string[] selectedTeams)
        {
            if (selectedTeams != null)
            {
                camp.Teams = new List<Team>();
                foreach (var team in selectedTeams)
                {
                    camp.Teams.Add(GetTeam(int.Parse(team)));
                }
            }

            _db.Camps.Add(camp);
            _db.SaveChanges();
        }
        public void Update(Camp camp, string[] selectedTeams)
        {
            var campUp = Search(camp.Id);
            campUp.Name = camp.Name;
            campUp.StarDate = camp.StarDate;
            campUp.EndDate = camp.EndDate;

            campUp.Teams = new List<Team>();
            if (selectedTeams != null)
            {
                foreach (var team in selectedTeams)
                {
                    campUp.Teams.Add(GetTeam(int.Parse(team)));
                }
            }
            _db.SaveChanges();
        }
        public Camp Search(int id)
        {
            return _db.Camps.Include(x => x.Teams).First(i => i.Id == id);
        }
        public void Delete(int id)
        {
            _db.Camps.Remove(Search(id));
            _db.SaveChanges();
        }
        public List<Team> ReturnTeams()
        {
            return _db.Teams.ToList();
        }
        public IEnumerable<SelectListItem> ReturnTeams(int id)
        {
            var teste = new SelectList(_db.Teams, "Id", "Name", id);
            return teste;
        }
    }
}
