#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace StripePro.Common.Data.Enums;

public enum DbIsolationLevel
{
    Chaos,
    ReadCommitted,
    ReadUncommitted,
    RepeatableRead,
    Serializable,
    Snapshot,
    Unspecified
}