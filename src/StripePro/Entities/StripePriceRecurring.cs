using StripePro.Common.Data.Bases;

namespace StripePro.Entities;

public class StripePriceRecurring : BaseObjectState
{
    public string AggregateUsage { get; set; }

    public string Interval { get; set; }

    public long IntervalCount { get; set; }

    public long? TrialPeriodDays { get; set; }

    public string UsageType { get; set; }
}