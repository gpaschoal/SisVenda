using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class Moviment : Entity
    {
        public Moviment(string peopleId, DateTime dtMoviment, string paymentStatusId, double amountDiscount, double amountAddition, double total, string description)
        {
            PeopleId = peopleId;
            DtMoviment = dtMoviment;
            PaymentStatusId = paymentStatusId;
            AmountDiscount = amountDiscount;
            AmountAddition = amountAddition;
            Total = total;
            Description = description;
        }

        [Required]
        public string PeopleId { get; private set; }
        public People People { get; }
        [Column(TypeName = "datetime")]
        public DateTime DtMoviment { get; private set; }
        [Required]
        public string PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double AmountDiscount { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double AmountAddition { get; private set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double Total { get; private set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; private set; }
    }
}
