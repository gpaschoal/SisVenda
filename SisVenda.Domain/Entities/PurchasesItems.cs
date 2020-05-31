using SisVenda.Domain.Base.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class PurchasesItems : MovimentItems
    {
        public PurchasesItems(string productsProfileId, int quantityItem, double costPrice, double salePrice, string purchasesId)
            : base(productsProfileId, quantityItem, costPrice, salePrice)
        {
            PurchasesId = purchasesId;
        }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string PurchasesId { get; private set; }
        public Purchases Purchases { get; }
    }
}
