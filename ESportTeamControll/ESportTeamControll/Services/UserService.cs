using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Services
{
	public class UserService : IUserService
	{
		private ESportTeamContext _db = new ESportTeamContext();
		public void Create(User user)
		{
			_db.Users.Add(user);
			SaveChanges();
		}

		public void Delete(int id)
		{
			_db.Users.Remove(GetById(id));
			SaveChanges();
		}

		public void Edit(User user)
		{
			var userUpdate = GetById(user.Id);
			userUpdate.Name = user.Name;
			userUpdate.Cpf = user.Cpf;
			userUpdate.BirthDate = user.BirthDate;
			userUpdate.Email = user.Password;
			userUpdate.Password = user.Password;
			SaveChanges();
		}

		public IEnumerable<User> GetAll()
		{
			return _db.Users.ToArray();
		}

		public User GetById(int id)
		{
			return _db.Users.First( u => u.Id == id);
		}

		public void SaveChanges()
		{
			_db.SaveChanges();
		}
	}
}