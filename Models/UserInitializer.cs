using Microsoft.AspNetCore.Identity;

namespace TestTaskIronWaterStudio.Models
{
    public static class UserInitializer
    {
        public static async Task CreateAdminUser(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            var username = configuration["Auth:Username"];
            var password = configuration["Auth:Password"];

            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                var newUser = new IdentityUser
                {
                    UserName = username
                };

                var createUserResult = await userManager.CreateAsync(newUser, password);

                if (createUserResult.Succeeded)
                {
                    Console.WriteLine("User created successfully.");
                }
                else
                {
                    Console.WriteLine($"Error creating user: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                Console.WriteLine("User already exists.");
            }
        }
    }
}
