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
    public class ShoppingsController : Controller
    {
        private SaphyrContext db = new SaphyrContext();

        //View para exibir os shoppings cadastrados
        public ActionResult Index()
        {
            //pega os shoppings e inclui os gerentes
            var gerentes = db.Shoppings.Include(sh => sh.Gerente);
            return View(db.Shoppings.ToList());
        }

        //exibir o shopping por id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Shopping shopping = db.Shoppings.Find(id);

            //redireciona para a pagina listar shoppings
            if (shopping == null)
            {
                return RedirectToAction("Index");
            }
            //resgata as lojas do shopping
            ViewBag.Lojas = shopping.Loja.ToList();
            return View(shopping);
        }

        //somente exibe a view de criacao
        public ActionResult Create()
        {
            //coloca o gerente
            ViewBag.GerenteId = new SelectList(db.Gerentes.OrderBy(g => g.Nome), "Id", "Nome");            
            return View();
        }

        //criacao novo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shopping shopping)
        {

            if (ModelState.IsValid)
            {
                db.Shoppings.Add(shopping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //coloca o gerente
            ViewBag.GerenteId = new SelectList(db.Gerentes.OrderBy(g => g.Nome), "Id", "Nome",shopping.GerenteId);
            return View(shopping);
        }

        //view edicao de shopping
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping shopping = db.Shoppings.Find(id);
            if (shopping == null)
            {
                return RedirectToAction("Index");
            }
            //coloca o gerente
            ViewBag.GerenteId = new SelectList(db.Gerentes.OrderBy(g => g.Nome), "Id", "Nome", shopping.GerenteId);

            return View(shopping);
        }

        //edicao de shopping
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //coloca o gerente
            ViewBag.GerenteId = new SelectList(db.Gerentes.OrderBy(g => g.Nome), "Id", "Nome", shopping.GerenteId);

            return View(shopping);
        }

        //view remover shopping
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping shopping = db.Shoppings.Find(id);
            if (shopping == null)
            {
                return RedirectToAction("Index");
            }

            //resgata as lojas do shopping
            ViewBag.Lojas = shopping.Loja.ToList();
            return View(shopping);
        }

        //remover shopping
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shopping shopping = db.Shoppings.Find(id);
            db.Shoppings.Remove(shopping);
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
