using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Task2.Web.Api.Models;

public class DataSeeder
{
    public static async Task SeedData(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        const string adminRole = "Admin";

        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole(adminRole));
            if (!roleResult.Succeeded)
            {
                throw new System.Exception("Failed to create role: " + string.Join(", ", roleResult.Errors));
            }
        }

        const string userRole = "User";

        if (!await roleManager.RoleExistsAsync(userRole))
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole(userRole));
            if (!roleResult.Succeeded)
            {
                throw new System.Exception("Failed to create role: " + string.Join(", ", roleResult.Errors));
            }
        }

        var existingAdminUser = await userManager.FindByEmailAsync("admin@gmail.com");
        if (existingAdminUser == null)
        {
            var adminUser = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com"
            };

            var userResult = await userManager.CreateAsync(adminUser, "Admin@123");
            if (userResult.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
            else
            {
                throw new System.Exception("Failed to create admin user: " + string.Join(", ", userResult.Errors));
            }
        }
    }
}
