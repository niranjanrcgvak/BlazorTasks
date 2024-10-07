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

        // Define the admin role name
        const string adminRole = "Admin";

        // Check if the admin role exists, if not create it
        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole(adminRole));
            if (!roleResult.Succeeded)
            {
                // Handle role creation errors (optional)
                throw new System.Exception("Failed to create role: " + string.Join(", ", roleResult.Errors));
            }
        }

        // Define the admin role name
        const string userRole = "User";

        // Check if the admin role exists, if not create it
        if (!await roleManager.RoleExistsAsync(userRole))
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole(userRole));
            if (!roleResult.Succeeded)
            {
                // Handle role creation errors (optional)
                throw new System.Exception("Failed to create role: " + string.Join(", ", roleResult.Errors));
            }
        }

        // Check if the admin user exists
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
                // Add user to the admin role
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
            else
            {
                // Handle user creation errors (optional)
                throw new System.Exception("Failed to create admin user: " + string.Join(", ", userResult.Errors));
            }
        }
    }
}
