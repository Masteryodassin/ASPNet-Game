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
    public class IronWarehousesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IronWarehouses
        public async Task<ActionResult> Index()
        {
            return View(await db.IronWarehouses.ToListAsync());
        }

        // GET: IronWarehouses/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IronWarehouse ironWarehouse = await db.IronWarehouses.FindAsync(id);
            if (ironWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(ironWarehouse);
        }

        // GET: IronWarehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IronWarehouses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Level,Health")] IronWarehouse ironWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.IronWarehouses.Add(ironWarehouse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ironWarehouse);
        }

        // GET: IronWarehouses/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IronWarehouse ironWarehouse = await db.IronWarehouses.FindAsync(id);
            if (ironWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(ironWarehouse);
        }

        // POST: IronWarehouses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Level,Health")] IronWarehouse ironWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ironWarehouse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ironWarehouse);
        }

        // GET: IronWarehouses/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IronWarehouse ironWarehouse = await db.IronWarehouses.FindAsync(id);
            if (ironWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(ironWarehouse);
        }

        // POST: IronWarehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            IronWarehouse ironWarehouse = await db.IronWarehouses.FindAsync(id);
            db.IronWarehouses.Remove(ironWarehouse);
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
