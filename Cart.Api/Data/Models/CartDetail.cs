using CartApi.Data.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartApi.Data.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        [NotMapped]
        public Carts Cart { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
