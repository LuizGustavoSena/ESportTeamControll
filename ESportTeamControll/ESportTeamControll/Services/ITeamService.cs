using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public interface ITeamService
    {
        List<Team> Retorna();

        void Adiciona(Team teams);

        IEnumerable<SelectListItem> GetGames();

        IEnumerable<SelectListItem> GetCoachs();

        void SaveChanges();

        Team ProcuraId(int id);

        void LimpaCoach(int id);

        void RemoverTime(int id);

        void Edit(Team teams);

        
    }
}