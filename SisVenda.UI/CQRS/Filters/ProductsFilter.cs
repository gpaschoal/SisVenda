﻿namespace SisVenda.UI.CQRS.Filters
{
    public class ProductsFilter : IFilter
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int RowsByPage { get; set; }
        public int PageNumber { get; set; }
    }
}
