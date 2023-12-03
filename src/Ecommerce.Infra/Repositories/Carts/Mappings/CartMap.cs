using Ecommerce.Domain.Carts.Entities;
using FluentNHibernate.Mapping;

namespace Ecommerce.Infra.Repositories.Carts.Mappings
{
    public class CartMap : ClassMap<Cart>
    {
        public CartMap()
        {
            Table("cart");
            Id(c => c.Id).Column("CartId");
            Map(x => x.Email);
            References(x => x.Coupon);
            HasMany(x => x.CartProducts)
                .KeyColumn("CartId")
                .ReadOnly();
        }
    }
}
