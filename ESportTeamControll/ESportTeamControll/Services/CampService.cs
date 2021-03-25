using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var campDe = Search(id);
            _db.Camps.Remove(campDe);
            _db.SaveChanges();
        }
    }
}