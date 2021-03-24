using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Dal
{
    public class TeamInitializer : DropCreateDatabaseIfModelChanges<ESportTeamContext>
    {
        protected override void Seed(ESportTeamContext context)
        {
            var teams = new List<Team>
            {
                new Team{Id = 1, Name = "MVL"}
            };
            teams.ForEach(d => context.Teams.Add(d));
            context.SaveChanges();
        }
    }
}