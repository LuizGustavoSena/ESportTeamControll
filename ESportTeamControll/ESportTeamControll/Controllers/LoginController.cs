using ESportTeamControll.Models;
using ESportTeamControll.Services;
using System.Web.Mvc;

namespace ESportTeamControll.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService _service = new LoginService();

        // GET: Login
        public ActionResult SignIn()
        {
            Session.Remove("userEmail");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn([Bind(Include = "Email, Password")] User user, int? entId)
        {
            if(user.Email != null && user.Password != null)
            {
                int userId = _service.UserValidate(user);
                if (userId != 0)
                {
                    Session["userEmail"] = user.Email;
                    if (entId != null)
                        Session["enterpriseId"] = entId;
                    else 
                    {
                        Session["enterpriseId"] = _service.GetEnterpriseId(userId);
                    }
                    return RedirectToAction("Index", "Team");
                }
                ViewBag.Msg = "Email e/ou senha incorreto";
            }
            
            return View(user);
        }

    }
}