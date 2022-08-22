using System.Linq;
using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;

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

        public static IQueryable<Basket> RetrieveBasketWithItems(this IQueryable<Basket> query, string buyerId)
        {
            return query.Include(i => i.Items).ThenInclude(p => p.Pizza).Where(b => b.BuyerId == buyerId);
        }
    }
}