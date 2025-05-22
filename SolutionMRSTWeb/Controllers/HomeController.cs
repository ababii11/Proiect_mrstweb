using System;
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
            // Create a list for recipes
            var recipes = new System.Collections.Generic.List<Recipe>();
            
            // Adding variety of sample recipes
            recipes.Add(new Recipe 
            {
                RecipeId = 1,
                Name = "Classic Italian Pasta",
                Description = "A delicious traditional Italian pasta dish with rich tomato sauce.",
                PrepTime = 10,
                CookTime = 20,
                Ingredients = "Pasta, Tomatoes, Garlic, Olive oil, Basil",
                Instructions = "1. Cook pasta according to package instructions.\n2. Prepare sauce with tomatoes and garlic.\n3. Combine and garnish with fresh basil.",
                ImageUrl = "~/Images/imagesss/authentic-italian-pasta-sauce-3.jpg",
                Category = new Category { Name = "Italian", CategoryId = 1 }
            });
            
            recipes.Add(new Recipe
            {
                RecipeId = 2,
                Name = "Grilled Salmon",
                Description = "Perfectly grilled salmon with a lemon herb marinade.",
                PrepTime = 15,
                CookTime = 30,
                Ingredients = "Salmon fillets, Lemon, Herbs, Olive oil, Salt, Pepper",
                Instructions = "1. Marinate salmon with lemon, herbs, and olive oil.\n2. Preheat grill to medium-high heat.\n3. Grill salmon for about 4-5 minutes per side.",
                ImageUrl = "~/Images/imagesss/featured-grilled-salmon-recipe.jpg",
                Category = new Category { Name = "Seafood", CategoryId = 2 }
            });
            
            recipes.Add(new Recipe
            {
                RecipeId = 3,
                Name = "Chocolate Cake",
                Description = "Rich and moist chocolate cake with creamy frosting.",
                PrepTime = 20,
                CookTime = 40,
                Ingredients = "Flour, Sugar, Cocoa powder, Eggs, Butter, Milk, Baking powder",
                Instructions = "1. Mix dry ingredients in one bowl.\n2. Mix wet ingredients in another bowl.\n3. Combine wet and dry ingredients.\n4. Bake at 350°F for 35-40 minutes.\n5. Let cool before frosting.",
                ImageUrl = "~/Images/imagesss/IMG_4117-feature.jpg",
                Category = new Category { Name = "Dessert", CategoryId = 3 }
            });

            recipes.Add(new Recipe
            {
                RecipeId = 4,
                Name = "Greek Salad",
                Description = "Fresh and tangy Greek salad with feta cheese and olives.",
                PrepTime = 15,
                CookTime = 0,
                Ingredients = "Cucumber, Tomato, Red onion, Feta cheese, Kalamata olives, Olive oil, Oregano",
                Instructions = "1. Chop cucumber, tomato, and red onion.\n2. Combine in a bowl with olives.\n3. Crumble feta cheese on top.\n4. Drizzle with olive oil and sprinkle oregano.",
                ImageUrl = "~/Images/Simply-Recipes-Easy-Greek-Salad-LEAD-2-4601eff771fd4de38f9722e8cafc897a.jpg",
                Category = new Category { Name = "Mediterranean", CategoryId = 4 }
            });

            recipes.Add(new Recipe
            {
                RecipeId = 5,
                Name = "Homemade Pizza",
                Description = "Delicious homemade pizza with your favorite toppings.",
                PrepTime = 30,
                CookTime = 15,
                Ingredients = "Pizza dough, Tomato sauce, Mozzarella cheese, Pepperoni, Bell peppers, Mushrooms, Olive oil",
                Instructions = "1. Roll out the dough.\n2. Spread sauce and add toppings.\n3. Bake in preheated oven at 450°F for 12-15 minutes.",
                ImageUrl = "~/Images/IMG_1710.jpg",
                Category = new Category { Name = "Italian", CategoryId = 1 }
            });
            
            recipes.Add(new Recipe
            {
                RecipeId = 6,
                Name = "Vegetable Stir-Fry",
                Description = "Quick and healthy vegetable stir-fry with soy sauce.",
                PrepTime = 10,
                CookTime = 8,
                Ingredients = "Bell peppers, Broccoli, Carrots, Snap peas, Soy sauce, Ginger, Garlic, Vegetable oil",
                Instructions = "1. Heat oil in a wok or large pan.\n2. Add garlic and ginger.\n3. Add vegetables and stir-fry for 5-7 minutes.\n4. Add soy sauce and stir to combine.",
                ImageUrl = "~/Images/VegetableStirFry_9.jpg",
                Category = new Category { Name = "Asian", CategoryId = 5 }
            });
            
            recipes.Add(new Recipe
            {
                RecipeId = 7,
                Name = "Beef Tacos",
                Description = "Spicy beef tacos with fresh toppings.",
                PrepTime = 15,
                CookTime = 15,
                Ingredients = "Ground beef, Taco shells, Lettuce, Tomato, Cheese, Sour cream, Taco seasoning",
                Instructions = "1. Brown beef in a pan.\n2. Add taco seasoning and water.\n3. Heat taco shells.\n4. Fill shells with beef and toppings.",
                ImageUrl = "~/Images/Ground-Beef-Tacos-TIMG.jpg",
                Category = new Category { Name = "Mexican", CategoryId = 6 }
            });
            
            recipes.Add(new Recipe
            {
                RecipeId = 8,
                Name = "Banana Bread",
                Description = "Moist and delicious banana bread with walnuts.",
                PrepTime = 15,
                CookTime = 55,
                Ingredients = "Ripe bananas, Flour, Sugar, Eggs, Butter, Baking soda, Salt, Walnuts",
                Instructions = "1. Mash bananas in a bowl.\n2. Mix in other ingredients.\n3. Pour into greased loaf pan.\n4. Bake at 350°F for 55-60 minutes.",
                ImageUrl = "~/Images/banana-sour-cream-bread-DDMFS-4x3-42e521007c6241ca9db1a870f93d70b4.jpg",
                Category = new Category { Name = "Baking", CategoryId = 7 }
            });
            
            // Setup categories for dropdown
            var categories = new System.Collections.Generic.List<System.Web.Mvc.SelectListItem>
            {
                new System.Web.Mvc.SelectListItem { Value = "1", Text = "Italian" },
                new System.Web.Mvc.SelectListItem { Value = "2", Text = "Seafood" },
                new System.Web.Mvc.SelectListItem { Value = "3", Text = "Dessert" },
                new System.Web.Mvc.SelectListItem { Value = "4", Text = "Mediterranean" },
                new System.Web.Mvc.SelectListItem { Value = "5", Text = "Asian" },
                new System.Web.Mvc.SelectListItem { Value = "6", Text = "Mexican" },
                new System.Web.Mvc.SelectListItem { Value = "7", Text = "Baking" }
            };
            ViewBag.Categories = new SelectList(categories, "Value", "Text");
            
            // Filter by category if specified
            if (categoryId.HasValue && categoryId > 0)
            {
                recipes = recipes.Where(r => r.Category.CategoryId == categoryId.Value).ToList();
            }
            
            // Filter by search term if specified
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                recipes = recipes.Where(r => 
                    r.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 || 
                    r.Ingredients.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();
            }
            
            return View(recipes);
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
                
                case 4:
                    recipe = new Recipe
                    {
                        RecipeId = 4,
                        Name = "Greek Salad",
                        Description = "Fresh and tangy Greek salad with feta cheese and olives.",
                        PrepTime = 15,
                        CookTime = 0,
                        Ingredients = "Cucumber, Tomato, Red onion, Feta cheese, Kalamata olives, Olive oil, Oregano",
                        Instructions = "1. Chop cucumber, tomato, and red onion.\n2. Combine in a bowl with olives.\n3. Crumble feta cheese on top.\n4. Drizzle with olive oil and sprinkle oregano.",
                        ImageUrl = "~/Images/Simply-Recipes-Easy-Greek-Salad-LEAD-2-4601eff771fd4de38f9722e8cafc897a.jpg",
                        Category = new Category { Name = "Mediterranean" }
                    };
                    break;
                
                case 5:
                    recipe = new Recipe
                    {
                        RecipeId = 5,
                        Name = "Homemade Pizza",
                        Description = "Delicious homemade pizza with your favorite toppings.",
                        PrepTime = 30,
                        CookTime = 15,
                        Ingredients = "Pizza dough, Tomato sauce, Mozzarella cheese, Pepperoni, Bell peppers, Mushrooms, Olive oil",
                        Instructions = "1. Roll out the dough.\n2. Spread sauce and add toppings.\n3. Bake in preheated oven at 450°F for 12-15 minutes.",
                        ImageUrl = "~/Images/IMG_1710.jpg",
                        Category = new Category { Name = "Italian" }
                    };
                    break;
                
                case 6:
                    recipe = new Recipe
                    {
                        RecipeId = 6,
                        Name = "Vegetable Stir-Fry",
                        Description = "Quick and healthy vegetable stir-fry with soy sauce.",
                        PrepTime = 10,
                        CookTime = 8,
                        Ingredients = "Bell peppers, Broccoli, Carrots, Snap peas, Soy sauce, Ginger, Garlic, Vegetable oil",
                        Instructions = "1. Heat oil in a wok or large pan.\n2. Add garlic and ginger.\n3. Add vegetables and stir-fry for 5-7 minutes.\n4. Add soy sauce and stir to combine.",
                        ImageUrl = "~/Images/VegetableStirFry_9.jpg",
                        Category = new Category { Name = "Asian" }
                    };
                    break;
                
                case 7:
                    recipe = new Recipe
                    {
                        RecipeId = 7,
                        Name = "Beef Tacos",
                        Description = "Spicy beef tacos with fresh toppings.",
                        PrepTime = 15,
                        CookTime = 15,
                        Ingredients = "Ground beef, Taco shells, Lettuce, Tomato, Cheese, Sour cream, Taco seasoning",
                        Instructions = "1. Brown beef in a pan.\n2. Add taco seasoning and water.\n3. Heat taco shells.\n4. Fill shells with beef and toppings.",
                        ImageUrl = "~/Images/Ground-Beef-Tacos-TIMG.jpg",
                        Category = new Category { Name = "Mexican" }
                    };
                    break;
                
                case 8:
                    recipe = new Recipe
                    {
                        RecipeId = 8,
                        Name = "Banana Bread",
                        Description = "Moist and delicious banana bread with walnuts.",
                        PrepTime = 15,
                        CookTime = 55,
                        Ingredients = "Ripe bananas, Flour, Sugar, Eggs, Butter, Baking soda, Salt, Walnuts",
                        Instructions = "1. Mash bananas in a bowl.\n2. Mix in other ingredients.\n3. Pour into greased loaf pan.\n4. Bake at 350°F for 55-60 minutes.",
                        ImageUrl = "~/Images/banana-sour-cream-bread-DDMFS-4x3-42e521007c6241ca9db1a870f93d70b4.jpg",
                        Category = new Category { Name = "Baking" }
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