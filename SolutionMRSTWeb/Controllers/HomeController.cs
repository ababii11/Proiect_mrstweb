using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Recipe;


namespace MRSTWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;

        public HomeController()
        {
            var bl = new BusinessLogic();
            // Initialize recipe and category services
            // Since these aren't implemented, we'll create empty lists for now
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Recipes
        public ActionResult Recipes(int? categoryId = null, string searchTerm = null)
        {
            // Create an empty list to avoid null reference exception
            var recipes = new System.Collections.Generic.List<Recipe>();
            
            // Add some sample recipes if needed
            // recipes.Add(new Recipe { /* properties */ });
            
            // Add categories to ViewBag for dropdown
            ViewBag.Categories = new SelectList(new System.Collections.Generic.List<SelectListItem>());
            
            return View(recipes); // Pass non-null model to view
        }

        // GET: Recipe Details
        public ActionResult RecipeDetails(int? id)
        {
            // Return empty view or create dummy recipe if needed
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
    }
}