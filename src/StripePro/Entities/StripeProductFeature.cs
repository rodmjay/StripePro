#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StripePro.Common.Data.Bases;
using StripePro.Interfaces;

namespace StripePro.Entities;

public class StripeProductFeature : BaseEntity<StripeProductFeature>, IHasProduct
{
    public override void Configure(EntityTypeBuilder<StripeProductFeature> builder)
    {
        builder.ToTable("ProductFeature", "Stripe");
        builder.HasKey(x => new { x.ProductId, x.Name });

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Features)
            .HasForeignKey(x => x.ProductId);
    }

    public StripeProduct Product { get; set; }
    public string ProductId { get; set; }
    public string Name { get; set; }
}