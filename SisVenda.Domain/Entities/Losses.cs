using SisVenda.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class Losses : Entity
    {
        public Losses(Guid idProduct, DateTime dtMoviment, string description)
        {
            IdProduct = idProduct;
            DtMoviment = dtMoviment;
            Description = description;
        }

        public Guid IdProduct { get; private set; }
        public Product Product { get; private set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtMoviment { get; private set; }
        [Column(TypeName = "varchar(150)")]
        public string Description { get; private set; }
    }
}
