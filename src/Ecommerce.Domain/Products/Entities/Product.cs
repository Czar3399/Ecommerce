using Vault.Base.Entities;

namespace Ecommerce.Domain.Products.Entities
{
    public class Product : EntityBase
    {
        public virtual string Name { get; set; }    
        public virtual string ImageUrl { get; set; }
        public virtual string Category { get;set; }
        public virtual string Description { get; set; }
        public virtual string Trademark { get; set; }
        public virtual decimal Price { get; set; }
    }
}
