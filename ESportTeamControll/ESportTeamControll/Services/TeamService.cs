using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public class TeamService : ITeamService
    {
        private ESportTeamContext tc = new ESportTeamContext();
        public List<Team> Retorna()
        {
            return tc.Teams.ToList();
        }
        public void Adiciona(Team teams)
        {
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
            tc.Teams.Remove(ProcuraId(id));
            SaveChanges();
        }
        public void Edit(Team teams)
        {
            Team teamUpdate = ProcuraId(teams.Id);
            teamUpdate.Name = teams.Name;
            teamUpdate.Sponsors = teams.Sponsors;
            teamUpdate.Coach = teams.Coach;
            teamUpdate.Camps = teams.Camps;
            SaveChanges();
        }
        public IEnumerable<SelectListItem> ReturnTeams()
        {
            return new SelectList(tc.Teams, "Id","Name");
        }
            

    }
}