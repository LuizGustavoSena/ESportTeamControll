using ESportTeamControll.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ESportTeamControll.Dal
{
	public class GameInitializer : DropCreateDatabaseIfModelChanges<ESportTeamContext>
	{
		protected override void Seed(ESportTeamContext context)
		{
			IEnumerable<Game> games = new Game[]
			{
				new Game { Id = 1, Name = "Valorant" },
				new Game { Id = 2, Name = "Rocket League" },
				new Game { Id = 3, Name = "Counter-Strike: Global Offensive" }
			};

			foreach (var g in games)
				context.Games.Add(g);

			context.SaveChanges();
		}
	}
}