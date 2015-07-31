using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using System.Data.Entity;

using City_Library.Context;
using City_Library.Models;

namespace City_Library.Controllers
{
    public class AuthorController : Controller
    {
        private BookContext db = new BookContext();
        // GET: Author
        public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }

        // GET: Author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(author);                
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(author).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(author);
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Author auth)
        {
            try
            {
                Author author = new Author();
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    author = db.Authors.Find(id);
                    if (author == null)
                    {
                        return HttpNotFound();
                    }
                    db.Authors.Remove(author);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(author);
            }
            catch 
            {
                return View();
            }
        }
    }
}
