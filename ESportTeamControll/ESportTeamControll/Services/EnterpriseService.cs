using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Services
{
	public class EnterpriseService : IEnterpriseService
	{
		private ESportTeamContext _db = new ESportTeamContext();
		public void Create(Enterprise ent)
		{
			_db.Enterprises.Add(ent);
			SaveChanges();
		}

		public void Delete(int id)
		{
			_db.Enterprises.Remove(GetById(id));
			SaveChanges();
		}

		public void Edit(Enterprise ent)
		{
			var entUpdate = GetById(ent.Id);
			entUpdate.FantasyName = ent.FantasyName;
			entUpdate.Cnpj = ent.Cnpj;
			SaveChanges();
		}

		public Enterprise GetById(int id)
		{
			return _db.Enterprises.First( e => e.Id == id);
		}

		public void SaveChanges()
		{
			_db.SaveChanges();
		}
	}
}