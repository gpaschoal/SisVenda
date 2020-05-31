using SisVenda.Domain.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class SalesPayment : Payment
    {
        public SalesPayment(string salesId, DateTime dtPaymentForecast, DateTime? dtPayment, double value, string paymentMethodsId)
            : base(dtPaymentForecast, dtPayment, value, paymentMethodsId)
        {
            SalesId = salesId;
        }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string SalesId { get; private set; }
        public Sales Sales { get; }
    }
}
