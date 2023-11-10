﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Translations.Entities;

public class ApplicationTranslation : BaseEntity<ApplicationTranslation>, ITranslation
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public int PhraseId { get; set; }
    public ApplicationPhrase ApplicationPhrase { get; set; }
    public Language Language { get; set; }
    public int Id { get; set; }
    public string LanguageId { get; set; }
    public DateTime? TranslationDate { get; set; }
    public string Text { get; set; }
    public TranslationEngine EngineId { get; set; }
    public ApplicationEngine Engine { get; set; }
    public ApplicationEngineLanguage ApplicationLanguage { get; set; }
    public bool IsDeleted { get; set; }

    public override void Configure(EntityTypeBuilder<ApplicationTranslation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.ApplicationPhrase)
            .WithMany(x => x.MachineTranslations)
            .HasForeignKey(x => new {x.ApplicationId, x.PhraseId});

        builder.HasOne(x => x.Application)
            .WithMany(x => x.Translations)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApplicationLanguage)
            .WithMany(x => x.Translations)
            .HasForeignKey(x => new {x.ApplicationId, x.EngineId, x.LanguageId});

        builder.HasOne(x => x.Engine)
            .WithMany(x => x.MachineTranslations)
            .HasForeignKey(x => new {x.ApplicationId, x.EngineId})
            .IsRequired(false);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}