using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Saphyr.Context;
using Saphyr.Models;

namespace Saphyr.Controllers
{
    public class GerentesController : Controller
    {
        private SaphyrContext db = new SaphyrContext();

        //View para exibir os gerentes cadastrados
        public ActionResult Index()
        {
            return View(db.Gerentes.ToList());
        }

        //exibir o gerente por id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Gerente gerente = db.Gerentes.Find(id);
            //redireciona para as listagens
            if (gerente == null)
            {
                return RedirectToAction("Index");
            }

            //resgata os shoppings do gerente
            ViewBag.Shoppings = db.Shoppings.Where(sp => sp.GerenteId == gerente.Id).ToList();
            return View(gerente);
        }

        //somente exibe a view de criacao
        public ActionResult Create()
        {   
            return View();
        }

        //criacao novo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                db.Gerentes.Add(gerente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gerente);
        }

        //view edicao de gerente
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Gerente gerente = db.Gerentes.Find(id);
            if (gerente == null)
            {
                return RedirectToAction("Index");
            }
            return View(gerente);
        }

        //edicao de gerente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gerente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gerente);
        }

        //view remover gerente
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Gerente gerente = db.Gerentes.Find(id);
            if (gerente == null)
            {
                return RedirectToAction("Index");
            }
            return View(gerente);
        }

        //remover gerente
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gerente gerente = db.Gerentes.Find(id);
            db.Gerentes.Remove(gerente);
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
