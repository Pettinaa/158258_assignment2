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
using WebApplication222222.ViewModels;
using PagedList;


namespace WebApplication222222.Controllers
{
    public class CharactersController : Controller
    {
        private WebApplication222222Context db = new WebApplication222222Context();

        // GET: Characters
        public ActionResult Index(string element, string search, string sortBy, int? page)
        {
            CharacterIndexViewModel viewModel = new CharacterIndexViewModel();
            var characters = db.Characters.Include(p => p.Element);

            if (!String.IsNullOrEmpty(search))
            {
                characters = characters.Where(p => p.Name.Contains(search) ||
                p.Nationality.Contains(search) ||
                p.Element.Name.Contains(search));
                //ViewBag.Search = search;
                viewModel.Search = search;

            }
            viewModel.CatsWithCount = from matchingCharacters in characters
                                      where matchingCharacters.ElementID != null
                                      group matchingCharacters by
                                      matchingCharacters.Element.Name into catGroup
                                      select new ElementWithCount()
                                      {
                                          ElementName = catGroup.Key,
                                          CharacterCount = catGroup.Count()
                                      };
            //ViewBag.Category = new SelectList(categories);
            //return View(products.ToList());
            if (!String.IsNullOrEmpty(element))
            {
                characters = characters.Where(p => p.Element.Name == element);
                viewModel.Element = element;
            }
            //sort the results
            switch (sortBy)
            {
                case "rerun_lowest":
                    characters = characters.OrderBy(p => p.Rerun);
                    break;
                case "rerun_highest":
                    characters = characters.OrderByDescending(p => p.Rerun);
                    break;
                default:
                    characters = characters.OrderBy(p => p.Name);
                    break;
            }
            viewModel.SortBy = sortBy;
            viewModel.Sorts = new Dictionary<string, string>
             {
                 {"Rerun low to high", "rerun_lowest" },
                 {"Rerun high to low", "rerun_highest" }
             };
            const int PageItems = 8;
            int currentPage = (page ?? 1);
            viewModel.Characters = characters.ToPagedList(currentPage, PageItems);

           return View(viewModel);

        }



        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.ElementID = new SelectList(db.Elements, "ID", "Name");
            return View();
        }

        // POST: Characters/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Nationslity,ElementID")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ElementID = new SelectList(db.Elements, "ID", "Name", character.ElementID);
            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.ElementID = new SelectList(db.Elements, "ID", "Name", character.ElementID);
            return View(character);
        }

        // POST: Characters/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Nationslity,ElementID")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ElementID = new SelectList(db.Elements, "ID", "Name", character.ElementID);
            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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
