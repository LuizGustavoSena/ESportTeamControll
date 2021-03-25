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

        public void Insert(Camp camp)
        {
            camp.Team = _db.Teams.First(x => x.Id == camp.Team.Id);
            _db.Camps.Add(camp);
            _db.SaveChanges();
        }

        public Camp Search(int id)
        {
            return _db.Camps.First(i => i.Id == id);
        }

        public void Update(Camp camp)
        {
            var campUp = Search(camp.Id);
            campUp.Name = camp.Name;
            campUp.StarDate = camp.StarDate;
            campUp.EndDate = camp.EndDate;
            campUp.Team = _db.Teams.First(x => x.Id == camp.Team.Id);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Camps.Remove(Search(id));
            _db.SaveChanges();
        }

        public IEnumerable<SelectListItem> ReturnTeams()
        {
            return new SelectList(_db.Teams, "Id", "Name");
        }

        public IEnumerable<SelectListItem> ReturnTeams(int id)
        {
            return new SelectList(_db.Teams, "Id", "Name", id);
        }

    }
}