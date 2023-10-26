﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;

namespace TranslationPro.Base.Users.Entities;

public class UserLogin : IdentityUserLogin<int>, IEntityTypeConfiguration<UserLogin>, IObjectState
{
    public User User { get; set; }

    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasKey(x => new
        {
            x.UserId,
            x.ProviderKey,
            x.LoginProvider
        });

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserLogins)
            .HasForeignKey(x => x.UserId);
    }

    [NotMapped] [IgnoreDataMember] public ObjectState ObjectState { get; set; }
}