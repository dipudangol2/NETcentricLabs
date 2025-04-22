using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityAuthDemo.Data
{
	public class SeedData
	{
		public static async Task Initialize(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

			string[] roles = { "Admin", "User" };

			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
				{
					var roleResult = await roleManager.CreateAsync(new IdentityRole(role));
					if (!roleResult.Succeeded)
					{
						Console.WriteLine($"❌ Failed to create role '{role}':");
						foreach (var error in roleResult.Errors)
							Console.WriteLine($" - {error.Description}");
					}
				}
			}

			var adminEmail = "admin@example.com";
			var adminUser = await userManager.FindByEmailAsync(adminEmail);

			if (adminUser == null)
			{
				adminUser = new IdentityUser
				{
					UserName = adminEmail,
					Email = adminEmail,
					EmailConfirmed = true
				};

				var createResult = await userManager.CreateAsync(adminUser, "Admin@123");
				if (!createResult.Succeeded)
				{
					Console.WriteLine("❌ Failed to create admin user:");
					foreach (var error in createResult.Errors)
						Console.WriteLine($" - {error.Description}");
					return; // ⛔ Stop here, can't assign roles to a non-existing user
				}

				// ✅ Only assign roles/claims after the user is successfully created
				var roleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
				if (!roleResult.Succeeded)
				{
					Console.WriteLine("❌ Failed to assign role:");
					foreach (var error in roleResult.Errors)
						Console.WriteLine($" - {error.Description}");
				}

				var claimResult = await userManager.AddClaimAsync(adminUser, new System.Security.Claims.Claim("HasDepartment", "true"));
				if (!claimResult.Succeeded)
				{
					Console.WriteLine("❌ Failed to assign claim:");
					foreach (var error in claimResult.Errors)
						Console.WriteLine($" - {error.Description}");
				}

				Console.WriteLine("✅ Admin user seeded successfully.");
			}
			else
			{
				Console.WriteLine("ℹ️ Admin user already exists.");
			}
		}

	}
}
