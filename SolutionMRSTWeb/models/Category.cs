using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SolutionMRSTWeb.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation property
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
} 