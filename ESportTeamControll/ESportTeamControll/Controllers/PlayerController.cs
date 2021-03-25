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
    public class PlayerController : Controller
    {
        // GET: Player
        private IPlayerService service = new PlayerService();
        
        #region Index
        public ActionResult Index()
        {            
            return View(service.Retorna());
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            ViewBag.TeamList = service.ReturnTeams(); 
            return View();
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Cpf,BirthDate,NickName,Function, Team")] Player players)
        {
            if (ModelState.IsValid)
            {
                players.Team = service.ProcuraIdTeam(players.Team.Id);
                service.Adiciona(players);
                return RedirectToAction("Index");
            }
            return View(players);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            ViewBag.TeamList = service.ReturnTeams(); 
            return View(service.ProcuraId(id));
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NickName,Function, Team")] Player players)
        {
            
            if (ModelState.IsValid)
            {
                var team = service.ProcuraIdTeam(players.Team.Id);
                service.Edit(players, team);
                return RedirectToAction("Index");
            }
            return View(players);
        }
        #endregion

        #region Details
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
            service.RemoverPlayer(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}