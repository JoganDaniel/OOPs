using OOPs.CustomerAccountManagement;
using OOPs.DataInventoryManagement;
using OOPs.InventoryManagement;
using OOPs.StockAccountManagement;
using System;
namespace OOPs
{
    public class Program
    {
        static string stock_filePath = @"E:\Bridgelabz\OOPs\OOPs\OOPs\StockAccountManagement\StockManagementData.json";
        static string customer_filePath = @"E:\Bridgelabz\OOPs\OOPs\OOPs\CustomerAccountManagement\CustomerData.json";
        private static void Main(string[] args)
        {
            
            StockOperations operations = new StockOperations();
            Console.WriteLine("Enter your total amount");
            int amount = Convert.ToInt32(Console.ReadLine());
            CustomerOperations customerOperations = new CustomerOperations(amount);
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.Display Stocks and Customer Details\n2.Buy Stock\n3.Sell Stock\n4.Display Amount\n5.Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Stock Details");
                        operations.ReadStockJson(stock_filePath);
                        Console.WriteLine("\nCustomer Details");
                        customerOperations.ReadCustomerJson(customer_filePath);
                        break;
                    case 2:
                        Console.WriteLine("Enter Stock Name");
                        string stock = Console.ReadLine();
                        Console.WriteLine("Enter number of shares");
                        int numShare = Convert.ToInt32(Console.ReadLine());
                        customerOperations.BuyStock(stock, numShare);
                        customerOperations.WriteToCustomerJsonFile(customer_filePath);
                        operations.WriteToStockJsonFile(stock_filePath);
                        break;
                    case 3:
                        Console.WriteLine("Enter Stock Name");
                        string stock1 = Console.ReadLine();
                        Console.WriteLine("Enter number of shares");
                        int numShare1 = Convert.ToInt32(Console.ReadLine());
                        customerOperations.SellStock(stock1, numShare1);
                        customerOperations.WriteToCustomerJsonFile(customer_filePath);
                        operations.WriteToStockJsonFile(stock_filePath);
                        break;
                    case 4:
                        Console.WriteLine("Amount balance : "+customerOperations.amount);
                        break;
                    case 5:
                        flag = false;
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}