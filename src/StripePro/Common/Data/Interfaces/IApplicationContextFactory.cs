#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore.Design;
using StripePro.Common.Data.Contexts;

namespace StripePro.Common.Data.Interfaces;

public interface IApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
}