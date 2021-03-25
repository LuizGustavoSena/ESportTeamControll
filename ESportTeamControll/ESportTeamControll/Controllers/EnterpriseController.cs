using ESportTeamControll.Models;
using ESportTeamControll.Services;
using System.Web.Mvc;

namespace ESportTeamControll.Controllers
{
    public class EnterpriseController : Controller
    {
        private IEnterpriseService _service = new EnterpriseService();

        // GET: Enterprise
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Enterprise ent, User user)
        {
            if (ModelState.IsValid)
            {
                ent.User = user;
                _service.Create(ent);
                return RedirectToAction("SignIn", "Login");
            }
            return View(ent);
        }

        public ActionResult Edit(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Enterprise ent)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(ent);
                return RedirectToAction("../Team/Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(_service.GetById(id));
        }

        public ActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Create");
        }
    }
}