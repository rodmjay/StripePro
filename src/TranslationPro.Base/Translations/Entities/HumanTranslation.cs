﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Phrases.Entities;

namespace TranslationPro.Base.Translations.Entities;

public class HumanTranslation : BaseEntity<HumanTranslation>
{
    public Guid ApplicationId { get; set; }
    public Language Language { get; set; }
    public string LanguageId { get; set; }
    public Application Application { get; set; }
    public ApplicationPhrase Phrase { get; set; }
    public int PhraseId { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }

    public override void Configure(EntityTypeBuilder<HumanTranslation> builder)
    {
        builder.HasKey(x => new { x.ApplicationId, x.PhraseId, x.LanguageId });

        builder.HasOne(x => x.Phrase)
            .WithMany(x => x.HumanTranslations)
            .HasForeignKey(x => new { x.ApplicationId, x.PhraseId });

        builder.HasOne(x => x.Application)
            .WithMany(x => x.HumanTranslations)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}