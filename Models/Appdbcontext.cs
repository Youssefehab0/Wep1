using Microsoft.EntityFrameworkCore;
using Talab.Models.Entities;
using Talab.Models.ViewModel;

namespace Talab.Models
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<FavoriteRecipes> FavoriteRecipes { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().
                HasOne(x=>x.User).WithMany(c=>c.Recipe).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Recipe>().
                HasOne(x => x.Category).WithMany(c => c.Recipe).HasForeignKey(x => x.CatId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FavoriteRecipes>().
                HasOne(x => x.User).WithMany(c => c.FavoriteRecipes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FavoriteRecipes>().
                HasOne(x => x.Recipe).WithMany(c => c.FavoriteRecipes).HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
