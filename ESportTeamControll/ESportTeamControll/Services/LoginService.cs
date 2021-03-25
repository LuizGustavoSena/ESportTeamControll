using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using System.Linq;

namespace ESportTeamControll.Services
{
	public class LoginService : ILoginService
	{
		private ESportTeamContext _db = new ESportTeamContext();

		public bool UserValidate(User user)
		{
			var auxUser = _db.Users.First( u => u.Email == user.Email);

			return (auxUser.Password == user.Password) ? true : false;
		}
	}
}