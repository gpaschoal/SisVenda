using SisVenda.Domain.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class Losses : Entity
    {
        public Losses(string productsProfileId, DateTime dtMoviment, string description)
        {
            ProductsProfileId = productsProfileId;
            DtMoviment = dtMoviment;
            Description = description;
        }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string ProductsProfileId { get; private set; }
        public ProductsProfile ProductsProfile { get; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtMoviment { get; private set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; private set; }
    }
}
