#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace StripePro.Common.Data.Interfaces;

public interface IAudited :
    ICreationAudited,
    IModificationAudited
{
}