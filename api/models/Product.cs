using System;

namespace api.models
{
    public class Product
    {
        public string? ProdID { get; set; }
        public int CatID { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
