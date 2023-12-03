using Ecommerce.Domain.Products.Entities;
using FluentNHibernate.Mapping;

namespace Ecommerce.Infra.Repositories.Products.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Id(x => x.Id).Column("ProductId");
            Map(x => x.Price);
            Map(x => x.Description);
            Map(x => x.Name);
            Map(x => x.Category);
            Map(x => x.ImageUrl);
            Map(x => x.Trademark);
        }
    }
}
