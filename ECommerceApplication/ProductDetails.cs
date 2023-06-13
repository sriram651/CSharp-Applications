using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class ProductDetails
    {
        private static int s_productID = 100;
        public string ProductID { get; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public int ShippingDuration { get; set; }
        public ProductDetails(string productName, double productPrice, int productStock, int shippingDuration)
        {
            ++s_productID;
            ProductID = "PID" + s_productID;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductStock = productStock;
            ShippingDuration = shippingDuration;
        }
    }
}