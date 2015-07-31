using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;

using City_Library.Context;
using City_Library.Models;
using System.Data.Entity;

namespace City_Library.Controllers
{
    public class PublisherController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Publisher
        public ActionResult Index()
        {
            return View(db.Publishers.ToList());
        }

        // GET: Publisher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }

            return View(publisher);
        }

        // GET: Publisher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publisher/Create
        [HttpPost]
        public ActionResult Create(Publisher publisher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Publishers.Add(publisher);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(publisher);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Publisher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Publisher/Edit/5
        [HttpPost]
        public ActionResult Edit(Publisher publisher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(publisher).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(publisher);
            }
            catch
            {
                return View();
            }
        }

        // GET: Publisher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Publisher/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Publisher pub)
        {
            var publisher = db.Publishers.Where(x => x.PublisherId == id).SingleOrDefault();
            if (publisher != null)
            {
                db.Publishers.Remove(publisher);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
