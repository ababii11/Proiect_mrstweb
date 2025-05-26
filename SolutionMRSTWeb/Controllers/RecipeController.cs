using System;
using System.Linq;
using System.Web.Mvc;
using SolutionMRSTWeb.Models;

namespace SolutionMRSTWeb.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipe
        public ActionResult Index(string searchString, string difficulty, int? cookingTime, string category)
        {
            var recipes = db.Recipes.AsQueryable();

            // Apply filters
            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(r => r.Title.Contains(searchString) || 
                                           r.Description.Contains(searchString) ||
                                           r.Ingredients.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(difficulty))
            {
                recipes = recipes.Where(r => r.Difficulty == difficulty);
            }

            if (cookingTime.HasValue)
            {
                recipes = recipes.Where(r => r.CookingTime <= cookingTime.Value);
            }

            if (!String.IsNullOrEmpty(category))
            {
                recipes = recipes.Where(r => r.Categories.Any(c => c.Name == category));
            }

            // Get categories for filter dropdown
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Difficulties = new[] { "Easy", "Medium", "Hard" };

            return View(recipes.ToList());
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            var recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.CreatedAt = DateTime.Now;
                recipe.UserId = 1; // TODO: Get actual user ID from authentication
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.Categories.ToList();
            return View(recipe);
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            var recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Categories.ToList();
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.UpdatedAt = DateTime.Now;
                db.Entry(recipe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.Categories.ToList();
            return View(recipe);
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            var recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
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