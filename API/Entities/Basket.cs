using System.Collections.Generic;
using System.Linq;

namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();

        public void AddItem(Pizza pizza, int quantity)
        {
            if (Items.All(item => item.PizzaId != pizza.Id))
            {
                Items.Add(new BasketItem{Pizza = pizza, Quantity = quantity});
            }

            var existingItem = Items.FirstOrDefault(item => item.PizzaId == pizza.Id);
            if (existingItem != null) existingItem.Quantity += quantity;
        }

        public void RemoveItem(int pizzaId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.PizzaId == pizzaId);
            if (item == null) return;
            item.Quantity -= quantity;
            if (item.Quantity == 0) Items.Remove(item);
        }
    }
}