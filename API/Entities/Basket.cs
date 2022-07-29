using System.Collections.Generic;
using System.Linq;

namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();

        public void AddItem(Pizza Pizza, int quantity)
        {
            if (Items.All(item => item.PizzaId != Pizza.Id))
            {
                Items.Add(new BasketItem{Pizza = Pizza, Quantity = quantity});
            }

            var existingItem = Items.FirstOrDefault(item => item.PizzaId == Pizza.Id);
            if (existingItem != null) existingItem.Quantity += quantity;
        }

        public void RemoveItem(int PizzaId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.PizzaId == PizzaId);
            if (item == null) return;
            item.Quantity -= quantity;
            if (item.Quantity == 0) Items.Remove(item);
        }
    }
}