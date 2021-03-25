using ESportTeamControll.Dal;
using ESportTeamControll.Models;
using ESportTeamControll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESportTeamControll.Controllers
{
    public class CampController : Controller
    {
        private ICampService _service = new CampService();
        // GET: Camp
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.TeamList = _service.ReturnTeams();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, StarDate, EndDate, Team")] Camp camp)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(camp);
                return RedirectToAction("Index");
            }
            return View(camp);
        }

        public ActionResult Edit(int id)
        {
            var camp = _service.Search(id);
            ViewBag.TeamList = _service.ReturnTeams(camp.Team.Id);
            return View(camp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, StarDate, EndDate, Team")] Camp camp)
        {
            if (ModelState.IsValid)
            {
                _service.Update(camp);
                return RedirectToAction("Index");
            }
            return View(camp);
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