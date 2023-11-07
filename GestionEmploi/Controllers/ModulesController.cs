using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionEmploi.Models;

namespace GestionEmploi.Controllers
{
    public class ModulesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Modules
        public ActionResult Index()
        {
            var modules = db.Modules.Include(m => m.Formateur).Include(m => m.Salle);
            return View(modules.ToList());
        }

        // GET: Modules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            ViewBag.FormateurIdFormateur = new SelectList(db.Formateurs, "IdFormateur", "NomFormateur");
            ViewBag.Salle_idSalle = new SelectList(db.Salles, "idSalle", "NomSalle");
            return View();
        }

        // POST: Modules/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idModule,NomModule,DureeModule,FormateurIdFormateur,Salle_idSalle")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Modules.Add(module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormateurIdFormateur = new SelectList(db.Formateurs, "IdFormateur", "NomFormateur", module.FormateurIdFormateur);
            ViewBag.Salle_idSalle = new SelectList(db.Salles, "idSalle", "NomSalle", module.Salle_idSalle);
            return View(module);
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormateurIdFormateur = new SelectList(db.Formateurs, "IdFormateur", "NomFormateur", module.FormateurIdFormateur);
            ViewBag.Salle_idSalle = new SelectList(db.Salles, "idSalle", "NomSalle", module.Salle_idSalle);
            return View(module);
        }

        // POST: Modules/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idModule,NomModule,DureeModule,FormateurIdFormateur,Salle_idSalle")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormateurIdFormateur = new SelectList(db.Formateurs, "IdFormateur", "NomFormateur", module.FormateurIdFormateur);
            ViewBag.Salle_idSalle = new SelectList(db.Salles, "idSalle", "NomSalle", module.Salle_idSalle);
            return View(module);
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
