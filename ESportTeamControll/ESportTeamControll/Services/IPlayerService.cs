using ESportTeamControll.Models;
using System.Collections.Generic;

namespace ESportTeamControll.Services
{
    public interface IPlayerService
    {
        List<Player> Retorna();

        void Adiciona(Player players);

        void SaveChanges();

        Player ProcuraId(int id);

        void Edit(Player players);

        void RemoverPlayer(int id);
    }
}