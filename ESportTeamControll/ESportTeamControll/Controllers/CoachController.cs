using ESportTeamControll.Models;
using ESportTeamControll.Services;
using System.Web.Mvc;

namespace ESportTeamControll.Controllers
{
    public class CoachController : Controller
    {
        private ICoachService _service = new CoachService();
        // GET: Coach
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(coach);
                return RedirectToAction("Index");
            }
            return View(coach);
        }

        public ActionResult Edit(int id)
        {
            return View(_service.Search(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _service.Update(coach);
                return RedirectToAction("Index");
            }
            return View(coach);
        }

        public ActionResult Details(int id)
        {
            return View(_service.Search(id));
        }

        public ActionResult Delete(int id)
        {
            return View(_service.Search(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }

}