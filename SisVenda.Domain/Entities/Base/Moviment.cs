using SisVenda.Domain.Entities;
using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Base.Entities
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
        public string PeopleId { get; set; }
        public People People { get; }
        [Column(TypeName = "datetime")]
        public DateTime DtMoviment { get; set; }
        [Required]
        public string PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double AmountDiscount { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double AmountAddition { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public double Total { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; set; }
    }
}
