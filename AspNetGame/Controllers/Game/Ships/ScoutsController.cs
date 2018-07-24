using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetGame.Models;
using AspNetGame.Models.Game.Ships;

namespace AspNetGame.Controllers.Game.Ships
{
    public class ScoutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Scouts
        public async Task<ActionResult> Index()
        {
            return View(await db.Scouts.ToListAsync());
        }

        // GET: Scouts/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scout scout = await db.Scouts.FindAsync(id);
            if (scout == null)
            {
                return HttpNotFound();
            }
            return View(scout);
        }

        // GET: Scouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Moving,Level,Health")] Scout scout)
        {
            if (ModelState.IsValid)
            {
                db.Scouts.Add(scout);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(scout);
        }

        // GET: Scouts/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scout scout = await db.Scouts.FindAsync(id);
            if (scout == null)
            {
                return HttpNotFound();
            }
            return View(scout);
        }

        // POST: Scouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Moving,Level,Health")] Scout scout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scout).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(scout);
        }

        // GET: Scouts/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scout scout = await db.Scouts.FindAsync(id);
            if (scout == null)
            {
                return HttpNotFound();
            }
            return View(scout);
        }

        // POST: Scouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Scout scout = await db.Scouts.FindAsync(id);
            db.Scouts.Remove(scout);
            await db.SaveChangesAsync();
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
