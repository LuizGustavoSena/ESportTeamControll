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
    public class TeamController : Controller
    {
        // GET: Team
        private ITeamService service = new TeamService();


        #region Index
        public ActionResult Index()
        {
            return View(service.Retorna());
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Create (Team teams)
        {
            if (ModelState.IsValid)
            {
                service.Adiciona(teams);
                return RedirectToAction("Index");
            }
            return View(teams);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            return View(service.ProcuraId(id));
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Edit(Team teams)
        {
            if (ModelState.IsValid)
            {
                service.Edit(teams);
                return RedirectToAction("index");
            }
            return View(teams);
            
        }
        #endregion

        #region details
        public ActionResult Details(int id)
        {
            return View(service.ProcuraId(id));
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            return View(service.ProcuraId(id));
        }

        [HttpPost, ActionName("Delete")] [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            service.RemoverTime(id);
            return RedirectToAction("Index");
        }
        #endregion


    }
}