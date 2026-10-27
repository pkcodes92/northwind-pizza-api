namespace NorthwindPizza.Api.DTO.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int OrderStatusId { get; set; }

        public string OrderDate { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
    }
}
