using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Dal
{
    public class ESportTeamInitializer : DropCreateDatabaseIfModelChanges<ESportTeamContext>
    {
        protected override void Seed(ESportTeamContext context)
        {
            var teams = new List<Team>
            {
                new Team{Id = 1, Name = "MVL"}
            };
            teams.ForEach(d => context.Teams.Add(d));

            var coachs = new List<Coach> {
                new Coach{Id = 1, Name = "Gaules", BirthDate = DateTime.Parse("05/10/1973"), Cpf = "1", NickName = "RobertinhoAK"},
                new Coach{Id = 2, Name = "Fall", BirthDate = DateTime.Parse("07/17/1987"), Cpf = "2", NickName = "F@ll"}
            };
            coachs.ForEach(i => context.Coachs.Add(i));

            IEnumerable<Game> games = new Game[]
            {
                new Game { Id = 1, Name = "Valorant" },
                new Game { Id = 2, Name = "Rocket League" },
                new Game { Id = 3, Name = "Counter-Strike: Global Offensive" }
            };
            foreach (var g in games)
                context.Games.Add(g);

            var camps = new List<Camp>{
                new Camp { Id = 1, Name = "CB lol", StarDate = DateTime.Parse("04/15/2021"), EndDate = DateTime.Parse("04/18/2021")},
                new Camp { Id = 2, Name = "CS League", StarDate = DateTime.Parse("06/20/2021"), EndDate = DateTime.Parse("06/22/2021")}
            };
            camps.ForEach(x => context.Camps.Add(x));

            context.SaveChanges();
        }
    }
}