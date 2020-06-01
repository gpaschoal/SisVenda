using SisVenda.Domain.Entities;

namespace SisVenda.Domain.Responses
{
    public class ProductsResponse : IResponse
    {
        public ProductsResponse() { }
        public ProductsResponse(Products products)
        {
            Id = products.Id;
            Name = products.Name;
            Description = products.Description;
            QuantityStock = products.QuantityStock;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double QuantityStock { get; set; }
    }
}
