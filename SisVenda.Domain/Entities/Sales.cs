using System;
using System.Collections.Generic;

namespace SisVenda.Domain.Entities
{
    public class Sales : Moviment
    {
        public Sales(string peopleId, DateTime dtMoviment, string paymentStatusId, double amountDiscount, double amountAddition, double total, string description)
            : base(peopleId, dtMoviment, paymentStatusId, amountDiscount, amountAddition, total, description)
        {
        }

        public IEnumerable<SalesItems> SalesItems { get; }
        public IEnumerable<SalesPayment> SalesPayment { get; }
    }
}
