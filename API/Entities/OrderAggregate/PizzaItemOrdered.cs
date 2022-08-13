using Microsoft.EntityFrameworkCore;

namespace API.Entities.OrderAggregate
{
    [Owned]
    public class PizzaItemOrdered
    {
        public int PizzaId { get; set; }       
        public string Name { get; set; }
        public string PictureUrl { get; set; }
    }
}