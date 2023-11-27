using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using StripePro.Common.Data.Bases;

namespace StripePro.Entities;

public class StripeSession : BaseEntity<StripeSession>, IHasId
{
    public override void Configure(EntityTypeBuilder<StripeSession> builder)
    {
        builder.ToTable("Session", "Stripe");
        builder.HasKey(x => x.Id);
    }

    public string Id { get; set; }
}