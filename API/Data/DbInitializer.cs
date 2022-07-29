using System.Collections.Generic;
using System.Linq;
using API.Entities;

namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
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
            };

            foreach (var Pizza in Pizzas)
            {
                context.Pizzas.Add(Pizza);
            }

            context.SaveChanges();
        }
    }
}