using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SolutionMRSTWeb.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public int CookingTime { get; set; } // in minutes

        [Required]
        public string Difficulty { get; set; } // Easy, Medium, Hard

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Foreign key for the user who created the recipe
        public int UserId { get; set; }

        // Navigation property
        public virtual User User { get; set; }

        // Categories for the recipe
        public virtual ICollection<Category> Categories { get; set; }
    }
} 