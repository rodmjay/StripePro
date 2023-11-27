#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Data;

namespace StripePro.Common.Data.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection DbConnection { get; }
}