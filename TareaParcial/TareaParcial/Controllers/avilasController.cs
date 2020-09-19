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
using TareaParcial.Models;

namespace TareaParcial.Controllers
{
    public class avilasController : ApiController
    {
        private DataContext db = new DataContext();
        [Authorize]
        // GET: api/avilas
        public IQueryable<avila> Getavilas()
        {
            return db.avilas;
        }
        [Authorize]
        // GET: api/avilas/5
        [ResponseType(typeof(avila))]
        public IHttpActionResult Getavila(int id)
        {
            avila avila = db.avilas.Find(id);
            if (avila == null)
            {
                return NotFound();
            }

            return Ok(avila);
        }
        [Authorize]
        // PUT: api/avilas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putavila(int id, avila avila)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avila.avilaID)
            {
                return BadRequest();
            }

            db.Entry(avila).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!avilaExists(id))
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
        [Authorize]
        // POST: api/avilas
        [ResponseType(typeof(avila))]
        public IHttpActionResult Postavila(avila avila)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.avilas.Add(avila);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = avila.avilaID }, avila);
        }
        [Authorize]
        // DELETE: api/avilas/5
        [ResponseType(typeof(avila))]
        public IHttpActionResult Deleteavila(int id)
        {
            avila avila = db.avilas.Find(id);
            if (avila == null)
            {
                return NotFound();
            }

            db.avilas.Remove(avila);
            db.SaveChanges();

            return Ok(avila);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool avilaExists(int id)
        {
            return db.avilas.Count(e => e.avilaID == id) > 0;
        }
    }
}