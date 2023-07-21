using Newtonsoft.Json;
using OOPs.StockAccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.CustomerAccountManagement
{
    public class CustomerOperations
    {
        public static List<CustomerDetails> cust_list;
        public void ReadCustomerJson(string filepath)
        {
            var json = File.ReadAllText(filepath);
            cust_list = JsonConvert.DeserializeObject<List<CustomerDetails>>(json);
            foreach (var data in cust_list)
            {
                Console.WriteLine(data.Balance + " " + data.StockName + " " + data.NumberOfStock);

            }
        }


        public void BuyStock(string name,int numofShares)
        {
            int amount = 0;
            foreach(var data in StockOperations.list)
            {
                if (data.StockName.ToLower().Equals(name.ToLower()))
                {
                    foreach (var item in cust_list)
                    {
                        if (item.StockName.ToLower().Equals(name.ToLower()))
                        {
                            amount = numofShares * data.SharePrice;
                            data.NoOfShares -= numofShares;
                            item.Balance -= amount;
                            item.NumberOfStock += numofShares;
                        }
                    }
                }
            }
        }
        public void SellStock(string name, int numofShares)
        {
            int amount = 0;
            foreach (var data in StockOperations.list)
            {
                if (data.StockName.ToLower().Equals(name.ToLower()))
                {
                    foreach (var item in cust_list)
                    {
                        if (item.StockName.ToLower().Equals(name.ToLower()))
                        {
                            amount = numofShares * data.SharePrice;
                            data.NoOfShares += numofShares;
                            item.Balance += amount;
                            item.NumberOfStock -= numofShares;
                        }
                    }
                }
            }
        }

        public void WriteToCustomerJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(cust_list);
            File.WriteAllText(filepath, json);
        }
    }

}
