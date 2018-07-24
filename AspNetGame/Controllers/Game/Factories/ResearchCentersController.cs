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
using AspNetGame.Models.Game.Factories;

namespace AspNetGame.Controllers.Game.Factories
{
    public class ResearchCentersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResearchCenters
        public async Task<ActionResult> Index()
        {
            return View(await db.ResearchCenters.ToListAsync());
        }

        // GET: ResearchCenters/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchCenter researchCenter = await db.ResearchCenters.FindAsync(id);
            if (researchCenter == null)
            {
                return HttpNotFound();
            }
            return View(researchCenter);
        }

        // GET: ResearchCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResearchCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Level,Health")] ResearchCenter researchCenter)
        {
            if (ModelState.IsValid)
            {
                db.ResearchCenters.Add(researchCenter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(researchCenter);
        }

        // GET: ResearchCenters/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchCenter researchCenter = await db.ResearchCenters.FindAsync(id);
            if (researchCenter == null)
            {
                return HttpNotFound();
            }
            return View(researchCenter);
        }

        // POST: ResearchCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Level,Health")] ResearchCenter researchCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(researchCenter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(researchCenter);
        }

        // GET: ResearchCenters/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchCenter researchCenter = await db.ResearchCenters.FindAsync(id);
            if (researchCenter == null)
            {
                return HttpNotFound();
            }
            return View(researchCenter);
        }

        // POST: ResearchCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ResearchCenter researchCenter = await db.ResearchCenters.FindAsync(id);
            db.ResearchCenters.Remove(researchCenter);
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
