using ESportTeamControll.Models;
using ESportTeamControll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESportTeamControll.Controllers
{
    public class UserController : Controller
    {
        private IUserService _service = new UserService();

        // GET: User
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
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
                return RedirectToAction("../Enterprise/Create", user);

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(user);
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}