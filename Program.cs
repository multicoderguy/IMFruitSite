using IMFruitSite.DAL;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace IMFruitSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new FruitContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var fruitId = context.Fruits.FirstOrDefault(f => f.FruitId == 1);
                if(fruitId == null)
                {
                    Console.WriteLine("something went wrong");
                    
                }

            }
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FruitContext>();
            builder.Services.AddMemoryCache();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Fruits}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
