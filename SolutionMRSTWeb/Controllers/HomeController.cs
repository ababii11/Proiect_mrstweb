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
            _recipeService = bl.GetRecipeService();
            _categoryService = bl.GetCategoryService();
        }

        // GET: Home
        public ActionResult Index()
        {
            var featuredRecipes = _recipeService.GetFeaturedRecipes().ToList();
            return View(featuredRecipes);
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        private void SetCategories(int? selectedId = null)
        {
            var categories = _categoryService.GetAllCategories().ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name", selectedId);
        }

        // GET: Recipes
        public ActionResult Recipes(int? categoryId, string searchTerm)
        {
            SetCategories(categoryId);
            var recipes = _recipeService.GetAllRecipes();
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                recipes = recipes.Where(r => r.CategoryId == categoryId.Value);
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                recipes = recipes.Where(r => r.Name.Contains(searchTerm));
            }
            return View(recipes.ToList());
        }

        // GET: Recipe Details
        public ActionResult RecipeDetails(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
    }
}