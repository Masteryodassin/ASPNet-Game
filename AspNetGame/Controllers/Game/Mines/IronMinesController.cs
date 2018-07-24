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
using AspNetGame.Models.Game.Mines;

namespace AspNetGame.Controllers.Game.Mines
{
    public class IronMinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IronMines
        public async Task<ActionResult> Index()
        {
            return View(await db.IronMines.ToListAsync());
        }

        // GET: IronMines/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IronMine ironMine = await db.IronMines.FindAsync(id);
            if (ironMine == null)
            {
                return HttpNotFound();
            }
            return View(ironMine);
        }

        // GET: IronMines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IronMines/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Level,Health")] IronMine ironMine)
        {
            if (ModelState.IsValid)
            {
                db.IronMines.Add(ironMine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ironMine);
        }

        // GET: IronMines/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IronMine ironMine = await db.IronMines.FindAsync(id);
            if (ironMine == null)
            {
                return HttpNotFound();
            }
            return View(ironMine);
        }

        // POST: IronMines/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Level,Health")] IronMine ironMine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ironMine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ironMine);
        }

        // GET: IronMines/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IronMine ironMine = await db.IronMines.FindAsync(id);
            if (ironMine == null)
            {
                return HttpNotFound();
            }
            return View(ironMine);
        }

        // POST: IronMines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            IronMine ironMine = await db.IronMines.FindAsync(id);
            db.IronMines.Remove(ironMine);
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
