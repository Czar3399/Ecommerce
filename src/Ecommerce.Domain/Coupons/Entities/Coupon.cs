using Ecommerce.Domain.Carts.Entities;
using Ecommerce.Domain.Cupoms.Enums;
using Ecommerce.Domain.Cupoms.Models;
using System.Text.Json;
using Vault.Base.Entities;

namespace Ecommerce.Domain.Cupoms.Entities
{
    public class Coupon : EntityBase
    {
        public virtual string Token { get; set; }
        public virtual LimitationTypeEnum? LimitationType { get; set; }
        public virtual DiscontTypeEnum? DiscontType { get; set; }
        public virtual string LimitationValue { get; set; }
        public virtual string DiscontValue { get; set; }

        public Coupon()
        {
            Token = GenerateToken();
        }

        private static string GenerateToken()
        {
            return null;
        }

        public virtual decimal GetDiscountValue(Cart cart)
        {
            if (DiscontType is DiscontTypeEnum.Percentage)
            {
                var discountModel = JsonSerializer.Deserialize<PercentageDiscontModel>(DiscontValue);

                var minimalValue = Math.Min(discountModel.MaxValue, cart.TotalPrice);
                return minimalValue * (discountModel.Percentage / 100);
            }

            if (DiscontType is DiscontTypeEnum.Flat)
            {
                return decimal.Parse(DiscontValue);
            }

            return 0;
        }
    }
}
