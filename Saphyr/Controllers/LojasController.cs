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
    public class LojasController : Controller
    {
        private SaphyrContext db = new SaphyrContext();

        //exibe as lojas 
        public ActionResult Index()
        {
            //pega as lojas e inclui os shopppings
            var lojas = db.Lojas.Include(l => l.Shopping);
            return View(lojas.ToList());
        }

        //exibir a loja por id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Loja loja = db.Lojas.Find(id);
            //redireciona para listar lojas
            if (loja == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(loja);
        }

        //somente exibe a view de criacao
        public ActionResult Create()
        {
            //coloca a lista de shoppings
            ViewBag.ShoppingId = new SelectList(db.Shoppings.OrderBy(sh => sh.Nome), "Id", "Nome");
            return View();
        }

        //criacao novo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loja loja)
        {
            if (ModelState.IsValid)
            {
                db.Lojas.Add(loja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //coloca a lista de shoppings
            ViewBag.ShoppingId = new SelectList(db.Shoppings.OrderBy(sh => sh.Nome), "Id", "Nome", loja.ShoppingId);
            return View(loja);
        }

        //view edicao de loja
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null)
            {
                return RedirectToAction("Index");
            }
            //coloca os shoppings
            ViewBag.ShoppingId = new SelectList(db.Shoppings.OrderBy(sh => sh.Nome), "Id", "Nome", loja.ShoppingId);
            return View(loja);
        }

        //edicao de loja
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Loja loja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //coloca os shoppings 
            ViewBag.ShoppingId = new SelectList(db.Shoppings.OrderBy(sh => sh.Nome), "Id", "Nome", loja.ShoppingId);
            return View(loja);
        }

        //view remover loja
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null)
            {
                return RedirectToAction("Index");
            }
            return View(loja);
        }

        //remover loja
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loja loja = db.Lojas.Find(id);
            db.Lojas.Remove(loja);
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
