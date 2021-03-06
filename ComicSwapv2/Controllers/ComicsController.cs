﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComicSwapv2.Models;
using System.IO;

namespace ComicSwapv2.Controllers
{
    [Authorize]
    public class ComicsController : Controller
    {
        private ComicSwapv2Context db = new ComicSwapv2Context();

        // GET: Comics
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewData["TitleSortParam"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["IssueSortParam"] = sortOrder == "Issue" ? "issue_desc" : "Issue";
            ViewData["PriceSortParam"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["ConditionSortParam"] = sortOrder == "Condition" ? "conditione_desc" : "Condition";
            ViewData["CurrentFilter"] = searchString;

            var comics = from c in db.Comics select c;

            if(!String.IsNullOrEmpty(searchString))
            {
                comics = comics.Where(c => c.Title.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "title_desc":
                    comics = comics.OrderByDescending(c => c.Title);
                    break;
                case "Issue":
                    comics = comics.OrderBy(c => c.Issue);
                    break;
                case "issue_desc":
                    comics = comics.OrderByDescending(c => c.Issue);
                    break;
                case "Price":
                    comics = comics.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    comics = comics.OrderByDescending(c => c.Price);
                    break;
                case "Condition":
                    comics = comics.OrderBy(c => c.Condition);
                    break;
                case "condition_desc":
                    comics = comics.OrderByDescending(c => c.Condition);
                    break;
                default:
                    comics = comics.OrderBy(c => c.Title);
                    break;
            }
            return View(comics.ToList());
        }

        // GET: Comics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // GET: Comics/Create
        public ActionResult Create()
        {
            ViewBag.OwnerIDs = new SelectList(db.Owners, "OwnerID", "FullName");
            return View();
        }

        // POST: Comics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComicID,OwnerID,Title,Issue,Price,Condition")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                var path = Server.MapPath("~/Images/");
                Directory.CreateDirectory(path); 

                if (Request.Files.Count > 0)
                {
                    var img = Request.Files[0];
                    if (img != null && img.ContentLength > 0)
                    {
                        var imgName = Path.GetFileName(img.FileName);
                        path = Path.Combine(path, imgName);
                        img.SaveAs(path);
                    }
                }
                if(path == Server.MapPath("~/Images/"))
                {
                    path = Path.Combine(path, "default.png");
                }

                /*
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/" + file.FileName));
                    comic.ImagePath = file.FileName;
                }
                else comic.ImagePath = "empty";
                */

                comic.ImagePath = path;
                db.Comics.Add(comic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comic);
        }

        // GET: Comics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // POST: Comics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComicID,OwnerID,Title,Issue,Price,Condition")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comic);
        }

        // GET: Comics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // POST: Comics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comic comic = db.Comics.Find(id);
            db.Comics.Remove(comic);
            db.SaveChanges();
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
