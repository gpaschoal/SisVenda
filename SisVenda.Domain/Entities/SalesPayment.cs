using System;

namespace SisVenda.Domain.Entities
{
    public class SalesPayment : Payment
    {
        public SalesPayment(string salesId, DateTime dtPaymentForecast, DateTime? dtPayment, double value, string paymentMethodsId)
            : base(dtPaymentForecast, dtPayment, value, paymentMethodsId)
        {
            SalesId = salesId;
        }

        public string SalesId { get; private set; }
        public Sales Sales { get; }
    }
}
