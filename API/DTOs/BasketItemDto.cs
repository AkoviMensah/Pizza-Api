namespace API.DTOs
{
    public class BasketItemDto
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
        public string Crust { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
    }
}