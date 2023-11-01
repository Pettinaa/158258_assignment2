using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication222222.Data;
using WebApplication222222.Models;

namespace WebApplication222222.Controllers
{
    public class ElementsController : Controller
    {
        private WebApplication222222Context db = new WebApplication222222Context();

        // GET: Elements
        public ActionResult Index()
        {
            return View(db.Elements.OrderBy(c => c.Name).ToList());
        }

        // GET: Elements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // GET: Elements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Elements/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Element element)
        {
            if (ModelState.IsValid)
            {
                db.Elements.Add(element);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(element);
        }

        // GET: Elements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // POST: Elements/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Element element)
        {
            if (ModelState.IsValid)
            {
                db.Entry(element).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(element);
        }

        // GET: Elements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        // POST: Elements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Element element = db.Elements.Find(id);
            db.Elements.Remove(element);
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
