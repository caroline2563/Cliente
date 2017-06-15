using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cliente.Models;

namespace Cliente.Controllers
{
    public class ClienteDBsController : Controller
    {
        private Context db = new Context();

        // GET: ClienteDBs
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: ClienteDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteDB clienteDB = db.Clientes.Find(id);
            if (clienteDB == null)
            {
                return HttpNotFound();
            }
            return View(clienteDB);
        }

        // GET: ClienteDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataNasc,Endereco,Telefone,Cpf")] ClienteDB clienteDB)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clienteDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clienteDB);
        }

        // GET: ClienteDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteDB clienteDB = db.Clientes.Find(id);
            if (clienteDB == null)
            {
                return HttpNotFound();
            }
            return View(clienteDB);
        }

        // POST: ClienteDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataNasc,Endereco,Telefone,Cpf")] ClienteDB clienteDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clienteDB);
        }

        // GET: ClienteDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteDB clienteDB = db.Clientes.Find(id);
            if (clienteDB == null)
            {
                return HttpNotFound();
            }
            return View(clienteDB);
        }

        // POST: ClienteDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteDB clienteDB = db.Clientes.Find(id);
            db.Clientes.Remove(clienteDB);
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
