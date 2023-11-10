﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Engines.Interfaces
{
    public interface IEngineService : IService<Engine>
    {
        Task<List<T>> GetEngines<T>() where T : EngineOutput;
    }
}