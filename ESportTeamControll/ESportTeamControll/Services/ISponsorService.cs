using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public interface ISponsorService
    {
        List<Sponsor> Retorna();
        void Adiciona(Sponsor sponsors);        
        Sponsor ProcuraId(int id);
        void RemoverSponsor(int id);
        void Edit(Sponsor sponsor);

        List<Team> ReturnTeams();
        Team ProcuraIdTeam(int id);
    }
}