using System;

namespace api.models
{
    public class Order
    {
        public int? OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ShipDate { get; set; }
        public string? CustID { get; set; }
        public string? ProdID { get; set; }
        public string? ShipMode { get; set; }
        public Product? Prod { get; internal set; }


        // }
        public Order(int _OrderID, DateTime _OrderDate,
                     int _Quantity, DateTime _ShipDate,
                     string _CustID, string _ProdId,
                     string _ShipMode, Product _Prod)
        {
            OrderID = _OrderID;
            OrderDate = _OrderDate;
            Quantity = _Quantity;
            ShipDate = _ShipDate;
            CustID = _CustID;
            ProdID = _ProdId;
            ShipMode = _ShipMode;

        }

        public double total(double _price, double _numUnits)
        {
            return _numUnits * _price;
        }

        public double getGST(double _price)
        {
            return _price * 0.1;
        }

    }
}