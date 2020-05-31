using SisVenda.Domain.Base.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class SalesItems : MovimentItems
    {
        public SalesItems(string productsProfileId, int quantityItem, double costPrice, double salePrice, string salesId)
            : base(productsProfileId, quantityItem, costPrice, salePrice)
        {
            SalesId = salesId;
        }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string SalesId { get; private set; }
        public Sales Sales { get; }
    }
}
