namespace Market.Service.DTOs
{
    public class ProductForUserDto
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
