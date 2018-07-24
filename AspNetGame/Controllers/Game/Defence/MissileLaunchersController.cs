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
    public class MissileLaunchersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MissileLaunchers
        public async Task<ActionResult> Index()
        {
            return View(await db.MissileLaunchers.ToListAsync());
        }

        // GET: MissileLaunchers/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissileLauncher missileLauncher = await db.MissileLaunchers.FindAsync(id);
            if (missileLauncher == null)
            {
                return HttpNotFound();
            }
            return View(missileLauncher);
        }

        // GET: MissileLaunchers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MissileLaunchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,AttackPoint,Level,Health")] MissileLauncher missileLauncher)
        {
            if (ModelState.IsValid)
            {
                db.MissileLaunchers.Add(missileLauncher);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(missileLauncher);
        }

        // GET: MissileLaunchers/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissileLauncher missileLauncher = await db.MissileLaunchers.FindAsync(id);
            if (missileLauncher == null)
            {
                return HttpNotFound();
            }
            return View(missileLauncher);
        }

        // POST: MissileLaunchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,AttackPoint,Level,Health")] MissileLauncher missileLauncher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missileLauncher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(missileLauncher);
        }

        // GET: MissileLaunchers/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissileLauncher missileLauncher = await db.MissileLaunchers.FindAsync(id);
            if (missileLauncher == null)
            {
                return HttpNotFound();
            }
            return View(missileLauncher);
        }

        // POST: MissileLaunchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            MissileLauncher missileLauncher = await db.MissileLaunchers.FindAsync(id);
            db.MissileLaunchers.Remove(missileLauncher);
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
