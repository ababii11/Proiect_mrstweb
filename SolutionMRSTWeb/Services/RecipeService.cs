using System.Collections.Generic;
using System.Linq;
using SolutionMRSTWeb.Models;

namespace SolutionMRSTWeb.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return _context.Recipes.Find(id);
        }

        public IEnumerable<Recipe> GetFeaturedRecipes()
        {
            return _context.Recipes.Take(6).ToList(); // Get first 6 recipes as featured
        }

        public void CreateRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _context.Entry(recipe).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
        }
    }
} 