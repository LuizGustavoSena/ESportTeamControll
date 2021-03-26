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
    public class SponsorService : ISponsorService
    {
        private ESportTeamContext tc = new ESportTeamContext();
        public List<Sponsor> Retorna()
        {
            return tc.Sponsors.ToList();
        }

        public List<Team> ReturnTeams()
        {
            return tc.Teams.ToList();
        }

        public void Adiciona(Sponsor sponsors)
        {
            
            tc.Sponsors.Add(sponsors);
            SaveChanges();            
        }
        private void SaveChanges()
        {
            tc.SaveChanges();
        }

        public Sponsor ProcuraId(int id)
        {
            return tc.Sponsors.Include(x => x.Teams).First(x => x.Id == id);
        }

        public void RemoverSponsor(int id)
        {
            tc.Sponsors.Remove(ProcuraId(id));
            SaveChanges(); 
        }
        public void Edit(Sponsor sponsors, string[] selectedTeams)
        {
            Sponsor sponsorUpdate = ProcuraId(sponsors.Id);
            sponsorUpdate.Name = sponsors.Name;
            sponsorUpdate.Teams = new List<Team>();

            if (selectedTeams != null)
            {
                foreach (var team in selectedTeams)
                {
                    sponsorUpdate.Teams.Add(ProcuraIdTeam(int.Parse(team)));
                }
            }
            SaveChanges();
        }

        public Team ProcuraIdTeam(int id)
        {
            return tc.Teams.First(x => x.Id == id);
        }

      
    }
}