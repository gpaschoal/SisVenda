using SisVenda.Domain.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class PurchasesPayments : Payment
    {
        public PurchasesPayments(string purchasesId, DateTime dtPaymentForecast, DateTime? dtPayment, double value, string paymentMethodsId)
            : base(dtPaymentForecast, dtPayment, value, paymentMethodsId)
        {
            PurchasesId = purchasesId;
        }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string PurchasesId { get; private set; }
        public Purchases Purchases { get; }
    }
}
