using System.Collections.Generic;
using System.Linq;
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
                await userManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});
            }

            if (context.Pizzas.Any()) return;

            var Pizzas = new List<Pizza>
            {
                new Pizza
                {
                    Name = "1st Pizza",
                    Description =
                        "Peperoni cruse large, additional topping",
                    Price = 20000,
                    PictureUrl = "https://images.unsplash.com/photo-1513104890138-7c749659a591?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                    Crust = "original",
                    Type = "Meats",
                    QuantityInStock = 100
                },
               
                new Pizza
                {
                    Name = "Pizza 2",
                    Description =
                        "the vegie pizza has 5 topping mia",
                    Price = 18000,
                    PictureUrl = "https://images.unsplash.com/photo-1590947132387-155cc02f3212?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                    Crust = "original",
                    Type = "Veggie",
                    QuantityInStock = 100
                },
                new Pizza
                {
                    Name = "Pizza 8",
                    Description =
                        "the vegie pizza has 5 topping mia",
                    Price = 18000,
                    PictureUrl = "https://images.unsplash.com/photo-1618213957768-7789409b9dd8?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80",
                    Crust = "original",
                    Type = "Veggie",
                    QuantityInStock = 100
                },
                new Pizza
                {
                    Name = "Pizza great",
                    Description =
                        "the vegie pizza has 5 topping mia",
                    Price = 18000,
                    PictureUrl = "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1169&q=80",
                    Crust = "original",
                    Type = "Veggie",
                    QuantityInStock = 100
                },
                new Pizza
                {
                    Name = "Pizza 579",
                    Description =
                        "the vegie pizza has 5 topping mia",
                    Price = 18000,
                    PictureUrl = "https://images.unsplash.com/photo-1593560708920-61dd98c46a4e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=435&q=80",
                    Crust = "original",
                    Type = "Veggie",
                    QuantityInStock = 100
                },
                new Pizza
                {
                    Name = "Pizza 5 best",
                    Description =
                        "the vegie pizza has 5 topping mia",
                    Price = 18000,
                    PictureUrl = "https://images.unsplash.com/photo-1566843972142-a7fcb70de55a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                    Crust = "original",
                    Type = "Veggie",
                    QuantityInStock = 100
                },
                new Pizza
                {
                    Name = "Pizza reminder",
                    Description =
                        "the vegie pizza has 5 topping mia",
                    Price = 18000,
                    PictureUrl = "https://images.unsplash.com/photo-1585238342024-78d387f4a707?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80",
                    Crust = "original",
                    Type = "Veggie",
                    QuantityInStock = 100
                },
                new Pizza
                {
                    Name = "Pizza 556",
                    Description =
                        "the vegie pizza has 5 topping mia",
                    Price = 18000,
                    PictureUrl = "https://images.unsplash.com/photo-1573821663912-569905455b1c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80",
                    Crust = "original",
                    Type = "Veggie",
                    QuantityInStock = 100
                },
            };

            foreach (var Pizza in Pizzas)
            {
                context.Pizzas.Add(Pizza);
            }

            context.SaveChanges();
        }
    }
}