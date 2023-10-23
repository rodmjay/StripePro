﻿using System;
using System.Linq.Expressions;
using TranslationPro.Base.Common.Queries;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Models;

namespace TranslationPro.Base.Phrases.Extensions;

public static class PhraseFiltersExtensions
{
    public static Expression<Func<Phrase, bool>> GetExpression(this PhraseFilters query)
    {
        var expr = PredicateBuilder.True<Phrase>();

        if (query.ContainsText != null)
            expr = expr.And(x => x.Text.Contains(query.ContainsText));

        if (query.Id != null)
            expr = expr.And(x => x.Id == query.Id.Value);

        return expr;
    }
}