using SisVenda.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Base.Entities
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
        public DateTime DtPaymentForecast { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DtPayment { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public double Value { get; set; }
        [Required]
        public string PaymentMethodsId { get; set; }
        public PaymentMethods PaymentMethods { get; }
    }
}
