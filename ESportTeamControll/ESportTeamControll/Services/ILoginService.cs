using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Services
{
	public interface ILoginService
	{
		bool UserValidate(User user);
	}
}