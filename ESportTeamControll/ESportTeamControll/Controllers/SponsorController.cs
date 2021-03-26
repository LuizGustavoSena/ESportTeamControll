using ESportTeamControll.Models;
using ESportTeamControll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESportTeamControll.Controllers
{
    public class SponsorController : Controller
    {
        private ISponsorService service = new SponsorService();
        // GET: Sponsor
        #region Index
        public ActionResult Index()
        {
            return View(service.Retorna());
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            ViewBag.TeamlistTeam = service.ReturnTeams();
            return View();
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Id, Name")]Sponsor sponsors, string[] selectedTeams)
        {
            if(selectedTeams != null)
            {
                sponsors.Teams = new List<Team>();
                foreach(var team in selectedTeams)
                {
                    sponsors.Teams.Add(service.ProcuraIdTeam(int.Parse(team)));
                }
            }
            if (ModelState.IsValid)
            {                
                service.Adiciona(sponsors);
                return RedirectToAction("Index");
            }
            return View(sponsors);
        }
        #endregion

        #region edit
        public ActionResult Edit(int id)
        {
            ViewBag.TeamlistTeam = service.ReturnTeams();
            return View(service.ProcuraId(id));
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,Name")] Sponsor sponsors, string[] selectedTeams)
        {
            if (ModelState.IsValid)
            {
                service.Edit(sponsors, selectedTeams);
                return RedirectToAction("Index");
            }
            return View(sponsors);
        }
        #endregion

        #region details
        public ActionResult Details(int id)
        {
            ViewBag.ListTeam = service.ProcuraId(id).Teams.ToList();
            return View(service.ProcuraId(id));
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            return View(service.ProcuraId(id));
        }

        [HttpPost, ActionName("Delete")][ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            service.RemoverSponsor(id);
            return RedirectToAction("Index");
        }

        #endregion
    }
}