using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Services
{
	public interface IEnterpriseService
	{
		Enterprise GetById(int id);

		void Create(Enterprise ent);

		void Edit(Enterprise ent);

		void Delete(int id);

		void SaveChanges();
	}
}