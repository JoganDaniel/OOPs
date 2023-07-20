using OOPs.DataInventoryManagement;
using OOPs.InventoryManagement;
using System;
namespace OOPs
{
    public class Program
    {
        static string inventory_filepath = @"E:\Bridgelabz\OOPs\OOPs\OOPs\InventoryManagement\InventoryManagementData.json";
        private static void Main(string[] args)
        {
            //InventoryDetailsOperations details = new InventoryDetailsOperations();
            //details.ReadInventoryJson(inventory_filepath);
            bool flag = true;
            InventoryManagementOperations manage = new InventoryManagementOperations();
            while (flag)
            {
                Console.WriteLine("1.Display inventory\n2.Add to inventory\n3.Delete from inventory\n4.Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        manage.ReadInventoryJson(inventory_filepath);
                        break;
                    case 2:
                        Console.WriteLine("Enter the item name (Rice,Wheat,Pulse)");
                        string name = Console.ReadLine();
                        manage.AddInventoryManagement(name);
                        manage.WriteToJsonFile(inventory_filepath);
                        break;
                    case 3:
                        Console.WriteLine("Enter the item name (Rice,Wheat,Pulse)");
                        string name1 = Console.ReadLine();
                        manage.DeleteInventory(name1, inventory_filepath);
                        break;
                    case 4:
                        flag = false;
                        break;
                }
            }
            
        }
    }
}