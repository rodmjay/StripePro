﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Extensions;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public class PhraseService : BaseService<Phrase>, IPhraseService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(PhraseService)}.{callerName}] - {message}";
    }

    private readonly ILogger<PhraseService> _logger;
    private readonly IRepositoryAsync<Language> _languageRepository;
    private readonly IRepositoryAsync<ApplicationPhrase> _applicationPhraseRepository;
    private readonly IRepositoryAsync<EngineLanguage> _engineLanguageRepository;

    public PhraseService(IServiceProvider serviceProvider, ILogger<PhraseService> logger) : base(serviceProvider)
    {
        _logger = logger;
        _languageRepository = UnitOfWork.RepositoryAsync<Language>();
        _applicationPhraseRepository = UnitOfWork.RepositoryAsync<ApplicationPhrase>();
        _engineLanguageRepository = UnitOfWork.RepositoryAsync<EngineLanguage>();
    }

    private IQueryable<Phrase> Phrases => Repository.Queryable()
        .Include(x => x.Applications)
        .Include(x => x.MachineTranslations);

    private IQueryable<ApplicationPhrase> ApplicationPhrases => _applicationPhraseRepository.Queryable()
        .Include(x => x.Phrase)
        .ThenInclude(x => x.MachineTranslations);

    private IQueryable<EngineLanguage> EngineLanguages => _engineLanguageRepository.Queryable().Include(x => x.Engine);

    private IQueryable<Language> Languages => _languageRepository.Queryable().Include(x => x.Engines);

    public async Task<Result> EnsurePhrasesWithLanguage(Guid applicationId, string languageId)
    {
        var applicationPhrases = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId)
            .Select(x => x.Phrase).ToListAsync();

        var engines = await EngineLanguages.Where(x => x.LanguageId == languageId).Select(x => x.Engine)
            .Where(x => x.Enabled).ToListAsync();

        bool requiresUpdate = false;

        foreach (var phrase in applicationPhrases)
        {
            var hasLanguage = phrase.MachineTranslations.HasLanguage(languageId);
            phrase.ObjectState = ObjectState.Modified;
            if (!hasLanguage)
            {
                requiresUpdate = true;
                foreach (var engine in engines)
                {
                    phrase.MachineTranslations.Add(new MachineTranslation()
                    {
                        EngineId = engine.Id,
                        LanguageId = languageId,
                        ObjectState = ObjectState.Added
                    });
                }

                Repository.InsertOrUpdateGraph(phrase);
            }
        }

        if (requiresUpdate)
        {
            var records = Repository.Commit();
            if (records > 0)
            {
                return Result.Success();
            }

            return Result.Failed();
        }
        return Result.Success();
    }

    public async Task<Result> EnsurePhraseWithLanguages(PhraseCreateOptions input)
    {
        var phrase = await Phrases.Where(x => x.Text == input.Text).FirstOrDefaultAsync();

        var languages = await Languages.Where(x => input.Languages.Contains(x.Id)).ToListAsync();

        if (phrase == null)
        {
            phrase = new Phrase()
            {
                Text = input.Text,
                ObjectState = ObjectState.Added
            };

            foreach (var lang in languages)
            {
                foreach (var engine in lang.Engines)
                {
                    if (engine.Engine.Enabled)
                    {
                        phrase.MachineTranslations.Add(new MachineTranslation()
                        {
                            LanguageId = lang.Id,
                            EngineId = engine.EngineId,
                            TranslationDate = null,
                            Text = null,
                            ObjectState = ObjectState.Added,
                        });
                    }
                }
            }

            var phraseRecords = Repository.Insert(phrase, true);
            if (phraseRecords > 0)
            {
                _logger.LogInformation(GetLogMessage("New phrase created: {0}"), input.Text);
                return Result.Success(phrase.Id);
            }

            return Result.Failed();
        }
        else
        {
            var phraseLanguages = phrase.MachineTranslations.Select(x => x.LanguageId).Distinct().ToList();

            bool requiresLanguageAdjustment = false;

            foreach (var lang in input.Languages)
            {
                if (!phraseLanguages.Contains(lang))
                {
                    requiresLanguageAdjustment = true;

                    var language = languages.First(x => x.Id == lang);

                    var engines = language.Engines.Select(x => x.Engine).Where(x => x.Enabled).ToList();

                    foreach (var engine in engines)
                    {
                        phrase.MachineTranslations.Add(new MachineTranslation()
                        {
                            EngineId = engine.Id,
                            LanguageId = lang,
                            ObjectState = ObjectState.Added
                        });
                    }
                }
            }

            if (requiresLanguageAdjustment)
            {
                var records = Repository.Update(phrase, true);
                if (records > 0)
                {
                    return Result.Success(phrase.Id);
                }
            }
            else
            {
                return Result.Success(phrase.Id);
            }
        }

        return Result.Failed();
    }

}