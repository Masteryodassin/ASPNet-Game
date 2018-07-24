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
using AspNetGame.Models.Game.Defence;

namespace AspNetGame.Controllers.Game.Defence
{
    public class PowerShieldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PowerShields
        public async Task<ActionResult> Index()
        {
            return View(await db.PowerShields.ToListAsync());
        }

        // GET: PowerShields/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PowerShield powerShield = await db.PowerShields.FindAsync(id);
            if (powerShield == null)
            {
                return HttpNotFound();
            }
            return View(powerShield);
        }

        // GET: PowerShields/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PowerShields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Level,Health")] PowerShield powerShield)
        {
            if (ModelState.IsValid)
            {
                db.PowerShields.Add(powerShield);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(powerShield);
        }

        // GET: PowerShields/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PowerShield powerShield = await db.PowerShields.FindAsync(id);
            if (powerShield == null)
            {
                return HttpNotFound();
            }
            return View(powerShield);
        }

        // POST: PowerShields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Level,Health")] PowerShield powerShield)
        {
            if (ModelState.IsValid)
            {
                db.Entry(powerShield).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(powerShield);
        }

        // GET: PowerShields/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PowerShield powerShield = await db.PowerShields.FindAsync(id);
            if (powerShield == null)
            {
                return HttpNotFound();
            }
            return View(powerShield);
        }

        // POST: PowerShields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            PowerShield powerShield = await db.PowerShields.FindAsync(id);
            db.PowerShields.Remove(powerShield);
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
