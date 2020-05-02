using SisVenda.Domain.Base.Entities;
using System;
using System.Collections.Generic;

namespace SisVenda.Domain.Entities
{
    public class Purchases : Moviment
    {
        public Purchases(string peopleId, DateTime dtMoviment, string paymentStatusId, double amountDiscount, double amountAddition, double total, string description)
            : base(peopleId, dtMoviment, paymentStatusId, amountDiscount, amountAddition, total, description)
        {
        }

        public IEnumerable<PurchasesItems> PurchasesItems { get; }
        public IEnumerable<PurchasesPayments> PurchasePayments { get; }
    }
}
