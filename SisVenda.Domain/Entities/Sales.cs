using System;

namespace SisVenda.Domain.Entities
{
    public class Sales : Moviment
    {
        public Sales(Guid idPeople, DateTime dtMoviment, DateTime? dtPayment, DateTime? dtPaymentForecast, Guid idPaymentMethods, double amountDiscount, double amountAddition, double total)
            : base(idPeople, dtMoviment, dtPayment, dtPaymentForecast, idPaymentMethods, amountDiscount, amountAddition, total)
        {
        }
    }
}
