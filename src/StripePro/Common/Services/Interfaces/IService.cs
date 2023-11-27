#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using StripePro.Common.Data.Interfaces;

namespace StripePro.Common.Services.Interfaces;

public interface IService<TEntity> where TEntity : class, IObjectState
{
    public MapperConfiguration ProjectionMapping { get; }
    public IRepositoryAsync<TEntity> Repository { get; }
}