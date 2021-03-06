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
            var entId = Session["enterpriseId"];
            return View(service.Retorna((int)entId));
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            ViewBag.GameList = service.GetGames();
            ViewBag.CoachList = service.GetCoachs();
            return View();
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Create ([Bind(Include = "Id, Name, Enterprise, Game, Coach, Camps, Sponsors")] Team teams)
        {
            if (ModelState.IsValid)
            {
                var entId = Session["enterpriseId"];
                service.Adiciona(teams, (int)entId);
                return RedirectToAction("Index");
            }
            return View(teams);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            ViewBag.GameList = service.GetGames();
            ViewBag.CoachList = service.GetCoachs();
            service.LimpaCoach(id);
            return View(service.ProcuraId(id));
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Enterprise, Game, Coach, Camps, Sponsors")] Team teams)
        {
            if (ModelState.IsValid)
            {
                service.Edit(teams);
                return RedirectToAction("Index");
            }
            return View(teams);
            
        }
        #endregion

        #region details
        public ActionResult Details(int id)
        {
            ViewBag.PlayerList = service.GetPlayers(id);
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