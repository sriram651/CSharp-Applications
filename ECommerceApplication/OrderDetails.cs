using System;

namespace ECommerceApplication
{
    public enum OrderStatus{Default, Ordered, Cancelled}
    public class OrderDetails
    {
        private static int s_orderID = 1000;
        public string OrderID { get; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus CurrentOrderStatus = OrderStatus.Default;

        public OrderDetails(string customerID, string productID, double totalPrice, DateTime purchaseDate, int quantity, OrderStatus currentOrderStatus)
        {
            ++s_orderID;
            OrderID = "OID" + s_orderID;
            CustomerID = customerID;
            ProductID = productID;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            CurrentOrderStatus = currentOrderStatus;
        }
    }
}