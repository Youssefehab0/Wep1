using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Talab.Models;
using Talab.Repo.Empelemation;
using Talab.Repo.IRepo;

namespace Talab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Appdbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connect")));
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IRecipeRepo, RecipeRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
