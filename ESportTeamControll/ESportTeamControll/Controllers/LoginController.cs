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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn([Bind(Include = "Email, Password")] User user)
        {
            if(user.Email != null && user.Password != null)
            {
                if (_service.UserValidate(user))
                {
                    Session["userEmail"] = user.Email;
                    return RedirectToAction("Index", "Team");
                }
                ViewBag.Msg = "Email e/ou senha incorreto";
            }
            
            return View(user);
        }

    }
}