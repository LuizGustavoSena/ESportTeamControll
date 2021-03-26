using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Linq;

namespace ESportTeamControll.Services
{
    public class CoachService : ICoachService
    {
        private ESportTeamContext _db = new ESportTeamContext();

        public List<Coach> GetAll()
        {
            return _db.Coachs.ToList();
        }

        public void Insert(Coach coach)
        {
            coach.Available = true;
            _db.Coachs.Add(coach);
            _db.SaveChanges();
        }

        public Coach Search(int id)
        {
            return _db.Coachs.First(i => i.Id == id);
        }

        public void Update(Coach coach)
        {
            var coachUp = Search(coach.Id);
            coachUp.Cpf = coach.Cpf;
            coachUp.Name = coach.Name;
            coachUp.BirthDate = coach.BirthDate;
            coachUp.NickName = coach.NickName;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var coachDe = Search(id);
            _db.Coachs.Remove(coachDe);
            _db.SaveChanges();
        }
    }
}