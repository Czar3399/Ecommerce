using Ecommerce.Domain.CartProducts.Entities;
using FluentNHibernate.Mapping;

namespace Ecommerce.Infra.Repositories.CartProducts.Mappings
{
    public class CartProductMap : ClassMap<CartProduct>
    {
        public CartProductMap()
        {
            Table("cartProduct");
            Id(x => x.Id);
            Map(x => x.Quantity);
            References(x => x.Product).Column("ProductId");
            References(x => x.Cart).Column("CartId");
        }
    }
}
