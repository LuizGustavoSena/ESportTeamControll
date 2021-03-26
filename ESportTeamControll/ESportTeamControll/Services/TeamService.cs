using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace ESportTeamControll.Services
{
    public class TeamService : ITeamService
    {
        private ESportTeamContext tc = new ESportTeamContext();
        public List<Team> Retorna(int entId)
        {
            return tc.Teams.Where( t => t.Enterprise.Id == entId).ToList();
        }

        public IEnumerable<SelectListItem> GetGames()
        {
            return new SelectList(tc.Games, "Id", "Name");
        }
        public IEnumerable<SelectListItem> GetCoachs()
        {
            return new SelectList(tc.Coachs.Where(x => x.Available == true), "Id", "Name");
        }
        public void Adiciona(Team teams, int entId)
        {
            var coachUp = tc.Coachs.First(x => x.Id == teams.Coach.Id);
            var ent = tc.Enterprises.First( e => e.Id == entId);
            coachUp.Available = false;
            teams.Game = tc.Games.First(x => x.Id == teams.Game.Id);
            teams.Coach = coachUp;
            teams.Enterprise = ent;
            tc.Teams.Add(teams);
            SaveChanges();
        }
        public void SaveChanges()
        {
            tc.SaveChanges();
        }
        public Team ProcuraId(int id)
        {
            return tc.Teams.First(x => x.Id == id);
        }
        public void RemoverTime(int id)
        {
            LimpaCoach(id);
            tc.Teams.Remove(ProcuraId(id));
            SaveChanges();
        }
        public void Edit(Team teams)
        {
            Team teamUpdate = ProcuraId(teams.Id);
            var coachUp = tc.Coachs.First(x => x.Id == teams.Coach.Id);
            coachUp.Available = false;
            teamUpdate.Name = teams.Name;
            teamUpdate.Sponsors = teams.Sponsors;
            teamUpdate.Coach = coachUp;
            teamUpdate.Camps = teams.Camps;
            teamUpdate.Game = tc.Games.First(x => x.Id == teams.Game.Id);
            SaveChanges();
        }

        public void LimpaCoach(int id)
        {
            var team = tc.Teams.Include(x => x.Coach).First(x => x.Id == id);
            //var coachUp = tc.Coachs.First(x => x.Id == team.Coach.Id);
            team.Coach.Available = true;
            SaveChanges();
        }
    }
}