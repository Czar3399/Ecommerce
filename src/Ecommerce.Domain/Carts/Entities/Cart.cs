using Ecommerce.Domain.CartProducts.Entities;
using Ecommerce.Domain.Cupoms.Entities;
using Vault.Base.Entities;

namespace Ecommerce.Domain.Carts.Entities
{
    public class Cart : EntityBase
    {
        public virtual string Email { get; set; }
        public virtual IEnumerable<CartProduct> CartProducts { get; set; }
        public virtual Coupon Coupon { get; set; }
        public virtual decimal DiscountValue => Coupon is null ? 0 : Coupon.GetDiscountValue(this);
        public virtual decimal TotalPrice => CartProducts is null ? 0 :  CartProducts.Sum(x => x.TotalPrice);
        public virtual decimal TotalWithDiscount => TotalPrice - DiscountValue;
    }
}
