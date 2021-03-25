using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Services
{
	public interface IUserService
	{
		IEnumerable<User> GetAll();

		User GetById(int id);

		void Create(User user);

		void Edit(User user);

		void Delete(int id);

		void SaveChanges();
	}
}