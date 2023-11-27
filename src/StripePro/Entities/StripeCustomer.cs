﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using StripePro.Common.Data.Bases;
using StripePro.Interfaces;

namespace StripePro.Entities;

public class StripeCustomer : BaseEntity<StripeCustomer>, IHasId, ILiveMode
{
    public StripeAddress Address { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }
    public string Name { get; set; }
    public long Balance { get; set; }

    public ICollection<StripeCharge> Charges { get; set; }
    public ICollection<StripePaymentIntent> PaymentIntents { get; set; }
    public ICollection<StripeCard> Cards { get; set; }
    public ICollection<StripeInvoice> Invoices { get; set; }
    public ICollection<StripeSubscriptionSchedule> Schedules { get; set; }
    public ICollection<StripeSubscription> Subscriptions { get; set; }

    public StripeSetupIntent SetupIntent { get; set; }

    public override void Configure(EntityTypeBuilder<StripeCustomer> builder)
    {
        builder.ToTable(nameof(Customer), "Stripe");
        builder.HasKey(e => e.Id);

        builder.OwnsOne(x => x.Address);
    }

    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public ICollection<StripePaymentMethod> PaymentMethods { get; set; }


    //public CashBalance CashBalance { get; set; }

    public long Created { get; set; }

    public string Currency { get; set; }


    public bool? Deleted { get; set; }

    public bool? Delinquent { get; set; }


    //public Discount Discount { get; set; }

    public string Email { get; set; }


    public string InvoicePrefix { get; set; }

    //public CustomerInvoiceSettings InvoiceSettings { get; set; }

    public long NextInvoiceSequence { get; set; }

    //public CustomerTax Tax { get; set; }

    public string TaxExempt { get; set; }


}