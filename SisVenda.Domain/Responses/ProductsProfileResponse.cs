﻿using SisVenda.Domain.Entities;

namespace SisVenda.Domain.Responses
{
    public class ProductsProfileResponse : IResponse
    {
        public ProductsProfileResponse() { }
        public ProductsProfileResponse(ProductsProfile productsProfile)
        {
            if (productsProfile is null) return;

            Id = productsProfile.Id?.Trim();
            UnitMeasurementId = productsProfile.UnitMeasurementId?.Trim();
            ProductsId = productsProfile.ProductsId?.Trim();
            BarCode = productsProfile.BarCode?.Trim();
        }

        public string Id { get; private set; }
        public string UnitMeasurementId { get; private set; }
        public string ProductsId { get; private set; }
        public string BarCode { get; private set; }
    }
}
