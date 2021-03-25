using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
    public class PlayerService : IPlayerService
    {
        private ESportTeamContext tc = new ESportTeamContext();
        public IEnumerable<SelectListItem> ReturnTeams()
        {
            return new SelectList(tc.Teams, "Id", "Name");
        }

        public Team ProcuraIdTeam(int id)
        {
            return tc.Teams.First(x => x.Id == id);
        }

        public List<Player> Retorna()
        {
            return tc.Players.ToList();
        }

        public void Adiciona(Player players)
        {
            tc.Players.Add(players);
            SaveChanges();
        }

        public void SaveChanges()
        {
            tc.SaveChanges();
        }

        public Player ProcuraId(int id)
        {
            return tc.Players.First(x => x.Id == id);
        }



        public void Edit(Player players)
        {
            Player playerUpdate = ProcuraId(players.Id);
            playerUpdate.Name = players.Name;
            playerUpdate.Function = players.Function;
        }

        public void RemoverPlayer(int id)
        {
            tc.Players.Remove(ProcuraId(id));
            SaveChanges();
        }
    }
}