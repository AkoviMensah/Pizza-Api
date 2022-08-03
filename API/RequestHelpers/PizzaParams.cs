namespace API.RequestHelpers
{
    public class PizzaParams : PaginationParams
    {
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public string Types { get; set; }
        public string Crusts { get; set; }
    }
}