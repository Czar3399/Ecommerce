namespace Ecommerce.Application.Carts.DataTransfers.Responses
{
    public class CartSimpleResponse
    {
        public long Id { get; set; }
        public decimal DiscountValue { get;set; }
        public decimal TotalPrice { get;set; }
        public decimal TotalWithDiscount { get; set; }
    }
}
