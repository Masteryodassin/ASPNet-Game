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
using AspNetGame.Models.Game;

namespace AspNetGame.Controllers.Game.Defence
{
    public class LaserTowersController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: LaserTowers
        public async Task<ActionResult> Index()
        {
            return View(await db.LaserTowers.ToListAsync());
        }

        // GET: LaserTowers/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaserTower laserTower = await db.LaserTowers.FindAsync(id);
            if (laserTower == null)
            {
                return HttpNotFound();
            }
            return View(laserTower);
        }

        // GET: LaserTowers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaserTowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,AttackPoint,Level,Health")] LaserTower laserTower)
        {
            if (ModelState.IsValid)
            {
                db.LaserTowers.Add(laserTower);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(laserTower);
        }

        // GET: LaserTowers/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaserTower laserTower = await db.LaserTowers.FindAsync(id);
            if (laserTower == null)
            {
                return HttpNotFound();
            }
            return View(laserTower);
        }

        // POST: LaserTowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,AttackPoint,Level,Health")] LaserTower laserTower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laserTower).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(laserTower);
        }

        // GET: LaserTowers/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaserTower laserTower = await db.LaserTowers.FindAsync(id);
            if (laserTower == null)
            {
                return HttpNotFound();
            }
            return View(laserTower);
        }

        // POST: LaserTowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LaserTower laserTower = await db.LaserTowers.FindAsync(id);
            db.LaserTowers.Remove(laserTower);
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
