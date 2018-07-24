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
    public class PlutoniumWarehousesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlutoniumWarehouses
        public async Task<ActionResult> Index()
        {
            return View(await db.PlutoniumWarehouses.ToListAsync());
        }

        // GET: PlutoniumWarehouses/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlutoniumWarehouse plutoniumWarehouse = await db.PlutoniumWarehouses.FindAsync(id);
            if (plutoniumWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(plutoniumWarehouse);
        }

        // GET: PlutoniumWarehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlutoniumWarehouses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Level,Health")] PlutoniumWarehouse plutoniumWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.PlutoniumWarehouses.Add(plutoniumWarehouse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(plutoniumWarehouse);
        }

        // GET: PlutoniumWarehouses/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlutoniumWarehouse plutoniumWarehouse = await db.PlutoniumWarehouses.FindAsync(id);
            if (plutoniumWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(plutoniumWarehouse);
        }

        // POST: PlutoniumWarehouses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Level,Health")] PlutoniumWarehouse plutoniumWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plutoniumWarehouse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(plutoniumWarehouse);
        }

        // GET: PlutoniumWarehouses/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlutoniumWarehouse plutoniumWarehouse = await db.PlutoniumWarehouses.FindAsync(id);
            if (plutoniumWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(plutoniumWarehouse);
        }

        // POST: PlutoniumWarehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            PlutoniumWarehouse plutoniumWarehouse = await db.PlutoniumWarehouses.FindAsync(id);
            db.PlutoniumWarehouses.Remove(plutoniumWarehouse);
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
