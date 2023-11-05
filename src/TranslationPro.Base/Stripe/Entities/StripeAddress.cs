﻿using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeAddress : BaseObjectState
{
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string PostalCode { get; set; }
}