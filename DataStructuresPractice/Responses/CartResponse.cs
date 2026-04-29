using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPractice.Responses
{
    public class CartResponse
    {
        public List<Cart> Carts { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class Cart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountedTotal { get; set; }
        public int UserId { get; set; }
        public int TotalProducts { get; set; }
        public int TotalQuantity { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountedTotal { get; set; }
        public string Thumbnail { get; set; }
    }
}
