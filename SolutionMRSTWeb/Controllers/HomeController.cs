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
            // Create different sample recipes based on the ID
            Recipe recipe;
            
            switch(id)
            {
                case 1:
                    recipe = new Recipe
                    {
                        RecipeId = 1,
                        Name = "Classic Italian Pasta",
                        Description = "A delicious traditional Italian pasta dish with rich tomato sauce.",
                        PrepTime = 10,
                        CookTime = 20,
                        Ingredients = "Pasta, Tomatoes, Garlic, Olive oil, Basil",
                        Instructions = "1. Cook pasta according to package instructions.\n2. Prepare sauce with tomatoes and garlic.\n3. Combine and garnish with fresh basil.",
                        ImageUrl = "~/Images/imagesss/authentic-italian-pasta-sauce-3.jpg",
                        Category = new Category { Name = "Italian" }
                    };
                    break;
                
                case 2:
                    recipe = new Recipe
                    {
                        RecipeId = 2,
                        Name = "Grilled Salmon",
                        Description = "Perfectly grilled salmon with a lemon herb marinade.",
                        PrepTime = 15,
                        CookTime = 30,
                        Ingredients = "Salmon fillets, Lemon, Herbs, Olive oil, Salt, Pepper",
                        Instructions = "1. Marinate salmon with lemon, herbs, and olive oil.\n2. Preheat grill to medium-high heat.\n3. Grill salmon for about 4-5 minutes per side.",
                        ImageUrl = "~/Images/imagesss/featured-grilled-salmon-recipe.jpg",
                        Category = new Category { Name = "Seafood" }
                    };
                    break;
                
                case 3:
                    recipe = new Recipe
                    {
                        RecipeId = 3,
                        Name = "Chocolate Cake",
                        Description = "Rich and moist chocolate cake with creamy frosting.",
                        PrepTime = 20,
                        CookTime = 40,
                        Ingredients = "Flour, Sugar, Cocoa powder, Eggs, Butter, Milk, Baking powder",
                        Instructions = "1. Mix dry ingredients in one bowl.\n2. Mix wet ingredients in another bowl.\n3. Combine wet and dry ingredients.\n4. Bake at 350°F for 35-40 minutes.\n5. Let cool before frosting.",
                        ImageUrl = "~/Images/imagesss/IMG_4117-feature.jpg",
                        Category = new Category { Name = "Dessert" }
                    };
                    break;
                
                default:
                    recipe = new Recipe
                    {
                        RecipeId = id ?? 1,
                        Name = "Sample Recipe",
                        Description = "This is a sample recipe description.",
                        PrepTime = 15,
                        CookTime = 30,
                        Ingredients = "Sample ingredients list",
                        Instructions = "Sample cooking instructions.",
                        ImageUrl = "~/Images/imagesss/authentic-italian-pasta-sauce-3.jpg",
                        Category = new Category { Name = "Sample Category" }
                    };
                    break;
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