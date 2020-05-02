using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class Losses : Entity
    {
        public Losses(string productId, DateTime dtMoviment, string description)
        {
            ProductId = productId;
            DtMoviment = dtMoviment;
            Description = description;
        }

        [Required]
        public string ProductId { get; private set; }
        public Products Product { get; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtMoviment { get; private set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; private set; }
    }
}
