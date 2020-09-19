using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TareaExamenFrame.Models;

namespace TareaExamenFrame.Controllers
{
    public class avilasController : Controller
    {
        private DataContext db = new DataContext();
        [Authorize]
        // GET: avilas
        public ActionResult Index()
        {
            return View(db.avilas.ToList());
        }
        [Authorize]
        // GET: avilas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avila avila = db.avilas.Find(id);
            if (avila == null)
            {
                return HttpNotFound();
            }
            return View(avila);
        }
        [Authorize]
        // GET: avilas/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: avilas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "avilaID,Friendofavila,Place,email,Birthday")] avila avila)
        {
            if (ModelState.IsValid)
            {
                db.avilas.Add(avila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avila);
        }
        [Authorize]
        // GET: avilas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avila avila = db.avilas.Find(id);
            if (avila == null)
            {
                return HttpNotFound();
            }
            return View(avila);
        }
        [Authorize]
        // POST: avilas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "avilaID,Friendofavila,Place,email,Birthday")] avila avila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avila);
        }
        [Authorize]
        // GET: avilas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avila avila = db.avilas.Find(id);
            if (avila == null)
            {
                return HttpNotFound();
            }
            return View(avila);
        }
        [Authorize]
        // POST: avilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            avila avila = db.avilas.Find(id);
            db.avilas.Remove(avila);
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
