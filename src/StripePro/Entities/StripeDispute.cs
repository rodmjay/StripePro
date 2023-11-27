using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using StripePro.Common.Data.Bases;

namespace StripePro.Entities
{
    public class StripeDispute : BaseEntity<StripeDispute>, IHasId
    {
        public override void Configure(EntityTypeBuilder<StripeDispute> builder)
        {
            builder.ToTable(nameof(Dispute), "Stripe");
            builder.HasKey(x => x.Id);
        }

        public string Id { get; set; }
    }
}
