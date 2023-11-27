#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using StripePro.Common.Data.Bases;

namespace StripePro.Entities;

public class StripePayout : BaseEntity<StripePayout>, IHasId
{
    public override void Configure(EntityTypeBuilder<StripePayout> builder)
    {
        builder.ToTable(nameof(Payout), "Stripe");
        builder.HasKey(x => x.Id);
    }

    public string Id { get; set; }
}