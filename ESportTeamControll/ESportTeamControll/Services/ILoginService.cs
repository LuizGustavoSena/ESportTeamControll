using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Services
{
	public interface ILoginService
	{
		int UserValidate(User user);

		int GetEnterpriseId(int userId);
	}
}