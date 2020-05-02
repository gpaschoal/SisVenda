using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class Payment : Entity
    {
        public Payment(DateTime dtPaymentForecast, DateTime? dtPayment, double value, string paymentMethodsId)
        {
            DtPaymentForecast = dtPaymentForecast;
            DtPayment = dtPayment;
            Value = value;
            PaymentMethodsId = paymentMethodsId;
        }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtPaymentForecast { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? DtPayment { get; private set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public double Value { get; private set; }
        [Required]
        public string PaymentMethodsId { get; private set; }
        public PaymentMethods PaymentMethods { get; }
    }
}
