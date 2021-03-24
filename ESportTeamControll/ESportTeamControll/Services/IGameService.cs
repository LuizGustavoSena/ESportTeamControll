using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Services
{
	public interface IGameService
	{
		IEnumerable<Game> GetAll();

		Game GetById(int id);

		void Create(Game game);

		void Edit(Game game);

		void Delete(int id);

		void SaveChanges();

	}
}