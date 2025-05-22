using System.Data.Entity;
using eUseControl.Domain.Entities.Recipe;

namespace eUseControl.Data
{
    public class ReteteContext : DbContext
    {
        public ReteteContext() : base("name=ReteteContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ReteteContext>());
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>()
                .HasRequired(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId);
        }
    }
} 