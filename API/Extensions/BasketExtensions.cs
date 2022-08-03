using System.Linq;
using API.DTOs;
using API.Entities;

namespace API.Extensions
{
    public static class BasketExtensions
    {
        public static BasketDto MapBasketToDto(this Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    PizzaId = item.PizzaId,
                    Name = item.Pizza.Name,
                    Price = item.Pizza.Price,
                    PictureUrl = item.Pizza.PictureUrl,
                    Type = item.Pizza.Type,
                    Crust = item.Pizza.Crust,
                    Quantity = item.Quantity
                }).ToList()
            };
        }
    }
}