#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using StripePro.Common.Data.Bases;
using StripePro.Interfaces;

namespace StripePro.Entities;

public class StripeSetupIntent : BaseEntity<StripeSetupIntent>, IHasId, IHasCustomer
{
    public override void Configure(EntityTypeBuilder<StripeSetupIntent> builder)
    {
        builder.ToTable(nameof(SetupIntent), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithOne(x => x.SetupIntent)
            .HasForeignKey<StripeSetupIntent>(x => x.CustomerId);
    }

    public string Id { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
}