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
    public class emploiesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: emploies
        public ActionResult Index()
        {
            var emploies = db.emploies.Include(e => e.Formateur).Include(e => e.Groupe).Include(e => e.Module);
            return View(emploies.ToList());
        }

        // GET: emploies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emploie emploie = db.emploies.Find(id);
            if (emploie == null)
            {
                return HttpNotFound();
            }
            return View(emploie);
        }

        // GET: emploies/Create
        public ActionResult Create()
        {
            ViewBag.FormateurIdFormateur = new SelectList(db.Formateurs, "IdFormateur", "NomFormateur");
            ViewBag.Groupe_idGroupe = new SelectList(db.Groupes, "idGroupe", "NomGroupe");
            ViewBag.Module_idModule = new SelectList(db.Modules, "idModule", "NomModule");
            return View();
        }

        // POST: emploies/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmploie,Jours,heure_debut,heure_fin,FormateurIdFormateur,Groupe_idGroupe,Module_idModule")] emploie emploie)
        {
            if (ModelState.IsValid)
            {
                db.emploies.Add(emploie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormateurIdFormateur = new SelectList(db.Formateurs, "IdFormateur", "NomFormateur", emploie.FormateurIdFormateur);
            ViewBag.Groupe_idGroupe = new SelectList(db.Groupes, "idGroupe", "NomGroupe", emploie.Groupe_idGroupe);
            ViewBag.Module_idModule = new SelectList(db.Modules, "idModule", "NomModule", emploie.Module_idModule);
            return View(emploie);
        }

        // GET: emploies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emploie emploie = db.emploies.Find(id);
            if (emploie == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormateurIdFormateur = new SelectList(db.Formateurs, "IdFormateur", "NomFormateur", emploie.FormateurIdFormateur);
            ViewBag.Groupe_idGroupe = new SelectList(db.Groupes, "idGroupe", "NomGroupe", emploie.Groupe_idGroupe);
            ViewBag.Module_idModule = new SelectList(db.Modules, "idModule", "NomModule", emploie.Module_idModule);
            return View(emploie);
        }

        // POST: emploies/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmploie,Jours,heure_debut,heure_fin,FormateurIdFormateur,Groupe_idGroupe,Module_idModule")] emploie emploie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emploie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormateurIdFormateur = new SelectList(db.Formateurs, "IdFormateur", "NomFormateur", emploie.FormateurIdFormateur);
            ViewBag.Groupe_idGroupe = new SelectList(db.Groupes, "idGroupe", "NomGroupe", emploie.Groupe_idGroupe);
            ViewBag.Module_idModule = new SelectList(db.Modules, "idModule", "NomModule", emploie.Module_idModule);
            return View(emploie);
        }

        // GET: emploies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emploie emploie = db.emploies.Find(id);
            if (emploie == null)
            {
                return HttpNotFound();
            }
            return View(emploie);
        }

        // POST: emploies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emploie emploie = db.emploies.Find(id);
            db.emploies.Remove(emploie);
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
