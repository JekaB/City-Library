using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;

using City_Library.Context;
using City_Library.Models;

namespace City_Library.Controllers
{
    public class BookController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Book
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Title")
            {
                return View(db.Books.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Books.Where(x => x.Author.Name.StartsWith(search) || search == null).ToList());
            }
           // return View(db.Books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookId", "Name");
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorId", "Name");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherId", "Name");
            ViewBag.BookSeriesID = new SelectList(db.BookSeries, "BookSeriesId", "Name");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {

                throw;
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Find(id);
            Author author = db.Authors.Find(book.AuthorId);
            ViewBag.Name = book.Name;
            ViewBag.Author = author.Name;
            ViewBag.BookID = new SelectList(db.Books, "BookId", "Name");
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorId", "Name");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherId", "Name");
            ViewBag.BookSeriesID = new SelectList(db.BookSeries, "BookSeriesId", "Name");
            
            if (book == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            book.BookId = id;
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", book.AuthorId);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "Name", book.PublisherId);
            ViewBag.BookSeriesID = new SelectList(db.BookSeries, "BookSeriesID", "Name", book.BookSeriesId);
            try
            {
                
                    db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Book b)
        {
            try
            {
                Book book = new Book();
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    book = db.Books.Find(id);
                    if (book == null)
                    {
                        HttpNotFound();
                    }
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }

        // Get: Book/SortByAuthor
        public ActionResult SortByAuthor()
        {
            return View(db.Books.OrderBy(x => x.Author.Name).ToList());
        }

        // Get: Book/SortBookSeries
        public ActionResult SortBookSeries()
        {
            return View(db.Books.OrderBy(x => x.BookSeries.Name).ToList());
        }

        // Get: Book/SortPublisher
        public ActionResult SortPublisher()
        {
            return View(db.Books.OrderBy(x => x.Publisher.Name).ToList());
        }

        // Get: Book/SortTitle
        public ActionResult SortTitle()
        {
            return View(db.Books.OrderBy(x => x.Name).ToList());
        }

        // Get: Book/SortDescription
        public ActionResult SortDescription()
        {
            return View(db.Books.OrderBy(x => x.Description).ToList());
        }
    }
}
