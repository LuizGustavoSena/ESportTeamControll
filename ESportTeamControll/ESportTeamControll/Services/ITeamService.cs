using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public interface ITeamService
    {
        List<Team> Retorna(int entId);

        void Adiciona(Team teams, int entId);

        IEnumerable<SelectListItem> GetGames();

        IEnumerable<SelectListItem> GetCoachs();

        void SaveChanges();

        Team ProcuraId(int id);

        void LimpaCoach(int id);

        void RemoverTime(int id);

        void Edit(Team teams);

        
    }
}