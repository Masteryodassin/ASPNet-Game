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
using AspNetGame.Models.Game;

namespace AspNetGame.Controllers.Game.Factories
{
    public class WeaponFactoriesController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: WeaponFactories
        public async Task<ActionResult> Index()
        {
            return View(await db.WeaponFactories.ToListAsync());
        }

        // GET: WeaponFactories/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponFactory weaponFactory = await db.WeaponFactories.FindAsync(id);
            if (weaponFactory == null)
            {
                return HttpNotFound();
            }
            return View(weaponFactory);
        }

        // GET: WeaponFactories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeaponFactories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Level,Health")] WeaponFactory weaponFactory)
        {
            if (ModelState.IsValid)
            {
                db.WeaponFactories.Add(weaponFactory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(weaponFactory);
        }

        // GET: WeaponFactories/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponFactory weaponFactory = await db.WeaponFactories.FindAsync(id);
            if (weaponFactory == null)
            {
                return HttpNotFound();
            }
            return View(weaponFactory);
        }

        // POST: WeaponFactories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Level,Health")] WeaponFactory weaponFactory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weaponFactory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(weaponFactory);
        }

        // GET: WeaponFactories/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponFactory weaponFactory = await db.WeaponFactories.FindAsync(id);
            if (weaponFactory == null)
            {
                return HttpNotFound();
            }
            return View(weaponFactory);
        }

        // POST: WeaponFactories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            WeaponFactory weaponFactory = await db.WeaponFactories.FindAsync(id);
            db.WeaponFactories.Remove(weaponFactory);
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
