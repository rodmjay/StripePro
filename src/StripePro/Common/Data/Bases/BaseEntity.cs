#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StripePro.Common.Data.Enums;
using StripePro.Common.Data.Interfaces;
using StripePro.Common.Validation;

namespace StripePro.Common.Data.Bases;

public abstract class BaseEntity : ValidatableModel, IObjectState
{
    [NotMapped] [IgnoreDataMember] public ObjectState ObjectState { get; set; }
}

public abstract class BaseEntity<T> : BaseEntity, IEntityTypeConfiguration<T> where T : class
{
    public abstract void Configure(EntityTypeBuilder<T> builder);
}