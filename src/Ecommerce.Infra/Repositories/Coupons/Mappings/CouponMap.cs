using Ecommerce.Domain.Cupoms.Entities;
using Ecommerce.Domain.Cupoms.Enums;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Ecommerce.Infra.Repositories.Coupons.Mappings
{
    public class CouponMap : ClassMap<Coupon>
    {
        public CouponMap()
        {
            Table("coupon");
            Id(x => x.Id).Column("couponId");
            Map(x => x.Token);
            Map(x => x.DiscontValue);
            Map(x => x.LimitationValue);
            Map(x => x.DiscontType).CustomType<EnumCharType<DiscontTypeEnum>>();
            Map(x => x.LimitationType).CustomType<EnumCharType<LimitationTypeEnum>>();
        }
    }
}
