#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Common.Data.Enums;

namespace StripePro.Common.Data.Interfaces;

public interface IObjectState
{
    public ObjectState ObjectState { get; set; }
}