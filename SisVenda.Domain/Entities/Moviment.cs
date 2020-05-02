using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class Moviment : Entity
    {
        public Moviment(Guid idPeople, DateTime dtMoviment, DateTime? dtPayment, DateTime? dtPaymentForecast, Guid idPaymentMethods, double amountDiscount, double amountAddition, double total)
        {
            IdPeople = idPeople;
            DtMoviment = dtMoviment;
            DtPayment = dtPayment;
            DtPaymentForecast = dtPaymentForecast;
            IdPaymentMethods = idPaymentMethods;
            AmountDiscount = amountDiscount;
            AmountAddition = amountAddition;
            Total = total;
        }

        public Guid IdPeople { get; private set; }
        public People People { get; }
        [Column(TypeName = "datetime")]
        public DateTime DtMoviment { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? DtPayment { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? DtPaymentForecast { get; private set; }
        public Guid IdPaymentMethods { get; private set; }
        public PaymentMethods PaymentMethods { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double AmountDiscount { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double AmountAddition { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double Total { get; private set; }

        //public IEnumerable<MovimentItems> Items { get; }
    }
}
