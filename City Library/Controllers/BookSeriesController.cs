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
    public class BookSeriesController : Controller
    {
        private BookContext db = new BookContext();

        // GET: BookSeries
        public ActionResult Index()
        {
            return View(db.BookSeries.ToList());
        }

        // GET: BookSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSeries bookSeries = db.BookSeries.Find(id);
            if (bookSeries == null)
            {
                HttpNotFound();
            }
            return View(bookSeries);
        }

        // GET: BookSeries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookSeries/Create
        [HttpPost]
        public ActionResult Create(BookSeries bookSeries)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BookSeries.Add(bookSeries);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bookSeries);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookSeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSeries bookSeries = db.BookSeries.Find(id);
            if (bookSeries == null)
            {
                HttpNotFound();
            }
            return View(bookSeries);
        }

        // POST: BookSeries/Edit/5
        [HttpPost]
        public ActionResult Edit(BookSeries bookSeries)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bookSeries).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bookSeries);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: BookSeries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSeries bookSeries = db.BookSeries.Find(id);
            if (bookSeries == null)
            {
                HttpNotFound();
            }
            return View(bookSeries);
        }

        // POST: BookSeries/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, BookSeries bs)
        {
            try
            {
                BookSeries bookSeries = new BookSeries();
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    bookSeries = db.BookSeries.Find(id);
                    if (bookSeries == null)
                    {
                        return HttpNotFound();
                    }
                    db.BookSeries.Remove(bookSeries);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bookSeries);
            }
            catch 
            {
                return View();
            }
        }
    }
}
