using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System.Linq;

namespace ESportTeamControll.Services
{
	public class LoginService : ILoginService
	{
		private ESportTeamContext _db = new ESportTeamContext();

		public int UserValidate(User user)
		{
			var auxUser = _db.Users.FirstOrDefault(u => u.Email == user.Email);

			return (auxUser != null && auxUser.Password == user.Password) ? auxUser.Id : 0;
		}

		public int GetEnterpriseId(int userId)
		{
			var ent = _db.Enterprises.First(e => e.User.Id == userId);
			return ent.Id;
		}
	}
}