using System;
using System.Collections.Generic;

namespace ECommerceApplication;
public class Operations
{
    static List<CustomerDetails> customerList = new List<CustomerDetails>();
    static List<ProductDetails> productList = new List<ProductDetails>();
    static List<OrderDetails> orderList = new List<OrderDetails>();
    static CustomerDetails currentCustomer = null;
    public static void MainMenu()
    {
        int userChoice;
        do
        {
            Console.WriteLine($"\n--------------------Main Menu--------------------");
            Console.WriteLine($"\n1. Registration");
            Console.WriteLine($"\n2. Login and Purchase");
            Console.WriteLine($"\n3. Exit");
            Console.WriteLine($"\nEnter your choice:");
            userChoice = Int32.Parse(Console.ReadLine());

            switch(userChoice)
            {
                case 1:
                {
                    CustomerRegistration();
                    break;
                }
                case 2:
                {
                    CustomerLogin();
                    break;
                }
                case 3:
                {
                    Console.WriteLine($"\nExiting Main Menu\n");
                    break;
                }
            }
        }while(userChoice != 3);
    }   

    public static void CustomerRegistration()
    {

        string customerName, customerCity, customerPhoneNumber, customerMailID;
        double customerWalletBalance;

        Console.WriteLine($"\n----------------------Customer Registration----------------------\n");
        Console.WriteLine($"\nEnter Your Name: ");
        customerName = Console.ReadLine();
        Console.WriteLine($"\nEnter Your City: ");
        customerCity = Console.ReadLine();
        Console.WriteLine($"\nEnter Phone Number: ");
        customerPhoneNumber = Console.ReadLine();
        Console.WriteLine($"\nEnter Mail ID: ");
        customerMailID = Console.ReadLine();
        Console.WriteLine($"\nEnter the Initial Wallet Balance: ");
        customerWalletBalance = double.Parse(Console.ReadLine());

        CustomerDetails customer = new CustomerDetails(customerName, customerCity, customerPhoneNumber, customerMailID, customerWalletBalance);
        customerList.Add(customer);
        Console.WriteLine($"\nYour Customer ID: {customer.CustomerID}\n");

    }

    public static void CustomerLogin()
    {
        string customerID;
        Console.WriteLine($"\nEnter the Customer ID:");
        customerID = Console.ReadLine().ToUpper();
        bool flag = false;
        foreach(CustomerDetails customer in customerList)
        {
            if (customerID == customer.CustomerID)
            {
                flag = true;
                currentCustomer = customer;
                Console.WriteLine($"\nLogged in Successfully");
            }
        }
        if(!flag)
        {
            Console.WriteLine($"\nInvalid Customer ID!");
        }
        else
        {
            SubMenu();
        }
    }

    public static void SubMenu()
    {
        int userChoice;
        do
        {
            Console.WriteLine($"\n1. Purchase");
            Console.WriteLine($"\n2. Order History");
            Console.WriteLine($"\n3. Cancel Order");
            Console.WriteLine($"\n4. Show Details");
            Console.WriteLine($"\n5. Wallet Recharge");
            Console.WriteLine($"\n6. Wallet Balance");
            Console.WriteLine($"\n7. Exit");
            Console.WriteLine($"\nEnter your Choice: ");
            userChoice = Int32.Parse(Console.ReadLine());

            switch(userChoice)
            {
                case 1:
                {
                    Purchase();
                    break;
                }
                case 2:
                {
                    OrderHistory();
                    break;
                }
                case 3:
                {
                    CancelOrder();
                    break;
                }
                case 4:
                {
                    ShowDetails();
                    break;
                }
                case 5:
                {
                    WalletBalance();
                    break;
                }
                case 6:
                {
                    WalletBalance();
                    break;
                }
                case 7:
                {
                    Console.WriteLine($"\n-----------------Exit Sub Menu-----------------\n");
                    break;
                }
            }
        }while(userChoice != 7);
    }
    
    public static void Purchase()
    {
        Console.WriteLine($"\n-----------------Purchase-----------------\n");
        foreach(ProductDetails product in productList)
        {
            Console.WriteLine($"Product ID: {product.ProductID}");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"Price: {product.ProductPrice}");
            Console.WriteLine($"Stock: {product.ProductStock}");
            Console.WriteLine($"Shipping Duration: {product.ShippingDuration}\n");
        }
        bool check = false;
        Console.WriteLine($"\nEnter the Product ID: ");
        string productID = Console.ReadLine().ToUpper();
        
        foreach(ProductDetails product in productList)
        {
            if(productID == product.ProductID)
            {
                check = true;
                Console.WriteLine($"\nEnter Count of Product:");
                int productCount = Int32.Parse(Console.ReadLine());
                if (product.ProductStock >= productCount)
                {
                    double totalPrice = (product.ProductPrice * productCount) + 50;
                    if (currentCustomer.CustomerWalletBalance >= totalPrice)
                    {
                        currentCustomer.Withdraw(totalPrice);
                        product.ProductStock -= productCount;
                        OrderDetails newOrder = new OrderDetails(currentCustomer.CustomerID, product.ProductID, totalPrice, DateTime.Now, productCount, OrderStatus.Ordered);
                        orderList.Add(newOrder);
                        Console.WriteLine($"\nOrder Placed Successfully!");
                        Console.WriteLine($"\nYour Updated Wallet balance is Rs.{currentCustomer.CustomerWalletBalance}");
                    }
                    else
                    {
                        Console.WriteLine($"\nYou dont have enough wallet balance, Please recharge and come back later!");
                        
                    }
                }
                else
                {
                    Console.WriteLine($"\nStock Unavailable");
                }
            }
        }
        if(!check)
        {
            Console.WriteLine($"\nInvalid Product ID!");
        }
    }
    
    public static void OrderHistory()
    {
        Console.WriteLine($"\n------------------Order History------------------\n");
        bool orderFlag = false;
        foreach(OrderDetails order in orderList)
        {
            if (currentCustomer.CustomerID == order.CustomerID)
            {
                orderFlag = true;
                Console.WriteLine($"\nOrder ID: {order.OrderID}");
                Console.WriteLine($"\nCustomer ID: {order.CustomerID}");
                Console.WriteLine($"\nProduct ID: {order.ProductID}");
                Console.WriteLine($"\nQuantity: {order.Quantity}");
                Console.WriteLine($"\nTotal Price: {order.TotalPrice}");
                Console.WriteLine($"\nPurchase Date: {order.PurchaseDate}");
                Console.WriteLine($"\nOrder Status: {order.CurrentOrderStatus}\n");
            }
        }
        if (!orderFlag)
        {
            Console.WriteLine($"\nInvalid Order ID!");
        }
    }
    
    public static void CancelOrder()
    {
        string orderID;
        foreach(OrderDetails order in orderList)
        {
            if (currentCustomer.CustomerID == order.CustomerID && order.CurrentOrderStatus == OrderStatus.Ordered)
            {
                Console.WriteLine($"\nOrder ID: {order.OrderID}");
                Console.WriteLine($"\nCustomer ID: {order.CustomerID}");
                Console.WriteLine($"\nProduct ID: {order.ProductID}");
                Console.WriteLine($"\nQuantity: {order.Quantity}");
                Console.WriteLine($"\nTotal Price: {order.TotalPrice}");
                Console.WriteLine($"\nPurchase Date: {order.PurchaseDate}");
                Console.WriteLine($"\nOrder Status: {order.CurrentOrderStatus}\n");
            }
        }
        Console.WriteLine($"\nEnter Order ID to Cancel: ");
        orderID = Console.ReadLine().ToUpper();
        
        foreach(OrderDetails order in orderList)
        {
            if (orderID == order.OrderID)
            {
                if (order.CurrentOrderStatus == OrderStatus.Ordered)
                {
                    order.CurrentOrderStatus = OrderStatus.Cancelled;
                    foreach(ProductDetails product in productList)
                    {
                        if (order.ProductID == product.ProductID)
                        {
                            product.ProductStock += order.Quantity;
                        }
                    }
                    currentCustomer.RechargeWallet((order.TotalPrice - 50));
                    Console.WriteLine($"\nOrder Cancelled Successfully!\n");
                    Console.WriteLine($"\nYour Updated Wallet Balance is Rs.{currentCustomer.CustomerWalletBalance}\n");
                }
            }
        }
    }

    public static void ShowDetails()
    {
        
        Console.WriteLine($"Customer ID: {currentCustomer.CustomerID}\nCustomer Name: {currentCustomer.CustomerName}");
        Console.WriteLine($"Customer City: {currentCustomer.CustomerCity}\nCustomer Phone Number: {currentCustomer.CustomerPhoneNumber}");
        Console.WriteLine($"Customer Wallet Balance: {currentCustomer.CustomerWalletBalance}\nCustomer Mail ID: {currentCustomer.CustomerMailID}\n");

    }
    public static void RechargeWallet()
    {
        Console.WriteLine($"\n-----------------Recharge Wallet-----------------\n");
        Console.WriteLine($"\nEnter the Recharge Amount: ");
        double rechargeAmount = double.Parse(Console.ReadLine());
        currentCustomer.RechargeWallet(rechargeAmount);
        Console.WriteLine($"\nYour Current Wallet Balance is Rs.{currentCustomer.CustomerWalletBalance}");
    }

    public static void WalletBalance()
    {
        Console.WriteLine($"\n------------Wallet Balance------------\n");
        Console.WriteLine($"\nYour Current Wallet Balance is Rs.{currentCustomer.CustomerWalletBalance}");
    }

    public static void AddDefaultValues()
    {
        // Adding Default Values for CustomerDetails Class

        customerList.Add(new CustomerDetails("Ravi", "Chennai", "9885858588", "ravi@mail.com", 50000));
        customerList.Add(new CustomerDetails("Baskaran", "Chennai", "9888475757", "baskaran@mail.com", 60000));
        

        // Adding Default Values for ProductDetails Class

        productList.Add(new ProductDetails("Mobile", 10000, 10, 3));
        productList.Add(new ProductDetails("Tablet", 15000, 5, 2));
        productList.Add(new ProductDetails("Camera", 20000, 3, 4));
        productList.Add(new ProductDetails("iPhone", 50000, 5, 6));
        productList.Add(new ProductDetails("Laptop", 40000, 3, 3));

        // Adding Default Values for OrderDetails Class

        DateTime date = DateTime.Now;
        OrderDetails order1 = new OrderDetails("CID1001","PID101", 20000, date, 2, OrderStatus.Ordered);
        orderList.Add(order1); 
        OrderDetails order2 = new OrderDetails("CID1002","PID103", 40000, date, 2, OrderStatus.Ordered);     
        orderList.Add(order2);            
        }
}
