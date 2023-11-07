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
    public class FormateursController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Formateurs
        public ActionResult Index()
        {
            var formateurs = db.Formateurs.Include(f => f.Groupe);
            return View(formateurs.ToList());
        }

        // GET: Formateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formateur formateur = db.Formateurs.Find(id);
            if (formateur == null)
            {
                return HttpNotFound();
            }
            return View(formateur);
        }

        // GET: Formateurs/Create
        public ActionResult Create()
        {
            ViewBag.Groupe_idGroupe = new SelectList(db.Groupes, "idGroupe", "NomGroupe");
            return View();
        }

        // POST: Formateurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFormateur,NomFormateur,Groupe_idGroupe")] Formateur formateur)
        {
            if (ModelState.IsValid)
            {
                db.Formateurs.Add(formateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Groupe_idGroupe = new SelectList(db.Groupes, "idGroupe", "NomGroupe", formateur.Groupe_idGroupe);
            return View(formateur);
        }

        // GET: Formateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formateur formateur = db.Formateurs.Find(id);
            if (formateur == null)
            {
                return HttpNotFound();
            }
            ViewBag.Groupe_idGroupe = new SelectList(db.Groupes, "idGroupe", "NomGroupe", formateur.Groupe_idGroupe);
            return View(formateur);
        }

        // POST: Formateurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFormateur,NomFormateur,Groupe_idGroupe")] Formateur formateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Groupe_idGroupe = new SelectList(db.Groupes, "idGroupe", "NomGroupe", formateur.Groupe_idGroupe);
            return View(formateur);
        }

        // GET: Formateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formateur formateur = db.Formateurs.Find(id);
            if (formateur == null)
            {
                return HttpNotFound();
            }
            return View(formateur);
        }

        // POST: Formateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formateur formateur = db.Formateurs.Find(id);
            db.Formateurs.Remove(formateur);
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
