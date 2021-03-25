using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
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
            return tc.Sponsors.First(x => x.Id == id);
        }

        public void RemoverSponsor(int id)
        {
            tc.Sponsors.Remove(ProcuraId(id));
            SaveChanges(); 
        }
        public void Edit(Sponsor sponsor)
        {
            Sponsor sponsorUpdate = ProcuraId(sponsor.Id);
            sponsorUpdate.Name = sponsor.Name;
            sponsorUpdate.Teams = sponsor.Teams;
            SaveChanges();
        }

        public Team ProcuraIdTeam(int id)
        {
            return tc.Teams.First(x => x.Id == id);
        }

      
    }
}