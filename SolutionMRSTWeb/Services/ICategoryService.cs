using System.Collections.Generic;
using SolutionMRSTWeb.Models;

namespace SolutionMRSTWeb.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
} 