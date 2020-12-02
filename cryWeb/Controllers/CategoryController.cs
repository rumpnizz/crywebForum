using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cryWeb.Models;
using cryWeb.DataContext;
using System.Data.Entity.Migrations;
using cryWeb.Factories;

namespace cryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private IForumContext _context;
        protected IForumContext db
        {
            get { return _context ?? (_context = ForumContextFactory.GetForumContext()); }
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            var categories = db.Categories.Include(c => c.Parent);
            return View(categories.ToList());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            Category category = db.Categories.FirstOrDefault(i => i.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name", category.ParentId);
            return View(category);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.FirstOrDefault(i => i.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name", category.ParentId);
            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.AddOrUpdate(category);
                //db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name", category.ParentId);
            return View(category);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Category category = db.Categories.FirstOrDefault(i => i.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.FirstOrDefault(i => i.Id == id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}