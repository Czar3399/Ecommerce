using Ecommerce.Domain.Carts.Entities;
using Ecommerce.Domain.Products.Entities;
using Vault.Base.Entities;

namespace Ecommerce.Domain.CartProducts.Entities
{
    public class CartProduct : EntityBase
    {
        public virtual int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual decimal TotalPrice => Quantity * Product.Price;
    }
}
