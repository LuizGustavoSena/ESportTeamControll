using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public interface IPlayerService
    {
        List<Player> Retorna();

        void Adiciona(Player players);

        void SaveChanges();

        Player ProcuraId(int id);

        void Edit(Player players, Team team);

        void RemoverPlayer(int id);

        Team ProcuraIdTeam(int id);

        IEnumerable<SelectListItem> ReturnTeams();
    }
}