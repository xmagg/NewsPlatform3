using NewsPlatform3.Models;

namespace NewsPlatform3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateDataUser();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static async Task CreateDataUser()
        {
            using (var context = new DbNewsContext())
            {
                context.Database.EnsureCreated();

                var user1 = new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "admin",
                    Password = "admin",
                    Level = 1
                };
                var u1 = await context.Users.AddAsync(user1);
                var result = await context.SaveChangesAsync();
            }
        }

    }
}