using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESportTeamControll.Services
{
	public class GameService : IGameService
	{
		private ESportTeamContext db = new ESportTeamContext();

		public IEnumerable<Game> GetAll()
		{
			return db.Games.ToArray();
		}
		public Game GetById(int id)
		{
			return db.Games.First( g => g.Id == id);
		}

		public void Create(Game game)
		{
			db.Games.Add(game);
			SaveChanges();
		}

		public void Delete(int id)
		{
			var game = GetById(id);
			db.Games.Remove(game);
			SaveChanges();
		}

		public void Edit(Game game)
		{
			var gameUpdate = GetById(game.Id);
			gameUpdate.Name = game.Name;
			SaveChanges();
		}

		public void SaveChanges()
		{
			db.SaveChanges();
		}
	}
}