using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("BasketItems")]
    public class BasketItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // navigation properties
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}