using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities.Recipe
{
    public class Category
    {
        public Category()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
} 