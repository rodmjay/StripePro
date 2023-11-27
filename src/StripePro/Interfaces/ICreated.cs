#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;

namespace StripePro.Interfaces;

public interface ICreated
{
    DateTimeOffset Created { get; set; }
}