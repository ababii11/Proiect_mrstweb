using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SolutionMRSTWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Recipe entity
            modelBuilder.Entity<Recipe>()
                .HasRequired(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .WillCascadeOnDelete(false);

            // Configure Category entity
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Recipes)
                .WithMany(r => r.Categories)
                .Map(m =>
                {
                    m.ToTable("RecipeCategories");
                    m.MapLeftKey("CategoryId");
                    m.MapRightKey("RecipeId");
                });
        }
    }
} 