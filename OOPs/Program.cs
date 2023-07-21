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
            //InventoryDetailsOperations details = new InventoryDetailsOperations();
            //details.ReadInventoryJson(inventory_filepath);
            //bool flag = true;
            //InventoryManagementOperations manage = new InventoryManagementOperations();
            //while (flag)
            //{
            //    Console.WriteLine("1.Display inventory\n2.Add to inventory\n3.Delete from inventory\n4.Exit");
            //    int ch = Convert.ToInt32(Console.ReadLine());
            //    switch (ch)
            //    {
            //        case 1:
            //            manage.ReadInventoryJson(inventory_filepath);
            //            break;
            //        case 2:
            //            Console.WriteLine("Enter the item name (Rice,Wheat,Pulse)");
            //            string name = Console.ReadLine();
            //            manage.AddInventoryManagement(name);
            //            manage.WriteToJsonFile(inventory_filepath);
            //            break;
            //        case 3:
            //            Console.WriteLine("Enter the item name (Rice,Wheat,Pulse)");
            //            string name1 = Console.ReadLine();
            //            manage.DeleteInventory(name1, inventory_filepath);
            //            break;
            //        case 4:
            //            flag = false;
            //            break;
            //    }
            //}
            StockOperations operations = new StockOperations();
            CustomerOperations customerOperations = new CustomerOperations();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.Display Stocks and Customer Details\n2.Buy Stock\n3.Sell Stock\n4.Exit");
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
                        flag = false;
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}