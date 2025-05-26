using System.Collections.Generic;
using SolutionMRSTWeb.Models;

namespace SolutionMRSTWeb.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
        IEnumerable<Recipe> GetFeaturedRecipes();
        void CreateRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(int id);
    }
} 