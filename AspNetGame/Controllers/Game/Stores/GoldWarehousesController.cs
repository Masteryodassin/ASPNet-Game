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
using AspNetGame.Models.Game.Stores;

namespace AspNetGame.Controllers.Game.Stores
{
    public class GoldWarehousesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GoldWarehouses
        public async Task<ActionResult> Index()
        {
            return View(await db.GoldWarehouses.ToListAsync());
        }

        // GET: GoldWarehouses/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoldWarehouse goldWarehouse = await db.GoldWarehouses.FindAsync(id);
            if (goldWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(goldWarehouse);
        }

        // GET: GoldWarehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoldWarehouses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Level,Health")] GoldWarehouse goldWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.GoldWarehouses.Add(goldWarehouse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(goldWarehouse);
        }

        // GET: GoldWarehouses/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoldWarehouse goldWarehouse = await db.GoldWarehouses.FindAsync(id);
            if (goldWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(goldWarehouse);
        }

        // POST: GoldWarehouses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Level,Health")] GoldWarehouse goldWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goldWarehouse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(goldWarehouse);
        }

        // GET: GoldWarehouses/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoldWarehouse goldWarehouse = await db.GoldWarehouses.FindAsync(id);
            if (goldWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(goldWarehouse);
        }

        // POST: GoldWarehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            GoldWarehouse goldWarehouse = await db.GoldWarehouses.FindAsync(id);
            db.GoldWarehouses.Remove(goldWarehouse);
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
