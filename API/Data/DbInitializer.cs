using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> userManager)
        {

            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            }

            if (context.Pizzas.Any()) return;

            try
            {
                if (!context.Pizzas.Any())
                {
                    var data = File.ReadAllText("./Data/SeedData/pizzas.json");
                    var pizzas = JsonSerializer.Deserialize<List<Pizza>>(data);

                    foreach (var item in pizzas)
                    {
                        context.Pizzas.Add(item);
                    }

                    await context.SaveChangesAsync();
                }




            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}