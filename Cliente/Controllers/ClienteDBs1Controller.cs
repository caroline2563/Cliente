using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cliente.Models;

namespace Cliente.Controllers
{
    public class ClienteDBs1Controller : ApiController
    {
        private Context db = new Context();

        // GET: api/ClienteDBs1
        public IQueryable<ClienteDB> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/ClienteDBs1/5
        [ResponseType(typeof(ClienteDB))]
        public IHttpActionResult GetClienteDB(int id)
        {
            ClienteDB clienteDB = db.Clientes.Find(id);
            if (clienteDB == null)
            {
                return NotFound();
            }

            return Ok(clienteDB);
        }

        // PUT: api/ClienteDBs1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClienteDB(int id, ClienteDB clienteDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clienteDB.Id)
            {
                return BadRequest();
            }

            db.Entry(clienteDB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteDBExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClienteDBs1
        [ResponseType(typeof(ClienteDB))]
        public IHttpActionResult PostClienteDB(ClienteDB clienteDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(clienteDB);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clienteDB.Id }, clienteDB);
        }

        // DELETE: api/ClienteDBs1/5
        [ResponseType(typeof(ClienteDB))]
        public IHttpActionResult DeleteClienteDB(int id)
        {
            ClienteDB clienteDB = db.Clientes.Find(id);
            if (clienteDB == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(clienteDB);
            db.SaveChanges();

            return Ok(clienteDB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteDBExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
    }
}