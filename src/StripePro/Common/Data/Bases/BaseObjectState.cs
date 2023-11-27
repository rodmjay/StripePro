#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using StripePro.Common.Data.Enums;
using StripePro.Common.Data.Interfaces;

namespace StripePro.Common.Data.Bases;

public abstract class BaseObjectState : IObjectState
{
    [NotMapped][IgnoreDataMember] public ObjectState ObjectState { get; set; }
}