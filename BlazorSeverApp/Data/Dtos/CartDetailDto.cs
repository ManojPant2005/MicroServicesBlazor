namespace BlazorSeverApp.Data.Dtos
{
    public class CartDetailDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public CartDto? Cart { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int Count { get; set; }
    }
}
