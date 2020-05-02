using System;

namespace SisVenda.Domain.Entities
{
    public class PurchasesPayments : Payment
    {
        public PurchasesPayments(string purchasesId, DateTime dtPaymentForecast, DateTime? dtPayment, double value, string paymentMethodsId)
            : base(dtPaymentForecast, dtPayment, value, paymentMethodsId)
        {
            PurchasesId = purchasesId;
        }

        public string PurchasesId { get; private set; }
        public Purchases Purchases { get; }
    }
}
