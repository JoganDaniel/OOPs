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
        public int amount;
        public CustomerOperations(int amount) {
            this.amount = amount;
        }
        public static List<CustomerDetails> cust_list;

        public void ReadCustomerJson(string filepath)
        {
            var json = File.ReadAllText(filepath);
            cust_list = JsonConvert.DeserializeObject<List<CustomerDetails>>(json);
            foreach (var data in cust_list)
            {
                Console.WriteLine(data.StockSymbol + " " + data.NumberOfStock + " " + data.SharePrice);

            }
        }


        public void BuyStock(string name,int numofShares)
        {
            StockDetails buyStock = new StockDetails();
            foreach (var data in StockOperations.list)
            {
                if (data.StockName.ToLower().Equals(name.ToLower()))
                {
                    if (data.NoOfShares >= numofShares && data.SharePrice * numofShares <= amount)
                    { 
                        buyStock = data;
                        data.NoOfShares -= numofShares;
                        amount -= data.SharePrice * numofShares;
                        break;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if(buyStock==null)
            {
                Console.WriteLine("Stock name doesnt exists");

            }
            else
            {
                CustomerDetails buyCustomerStocks = new CustomerDetails();
                foreach(var data in cust_list)
                {
                    if(data.StockSymbol.ToLower().Equals(name.ToLower()))
                    {
                        buyCustomerStocks = data;
                        data.NumberOfStock +=numofShares;
                        break;
                    }
                    else
                    {
                        buyCustomerStocks = null;
                    }
                }
                if (buyCustomerStocks==null)
                {
                    buyCustomerStocks = new CustomerDetails();
                    buyCustomerStocks.StockSymbol= name;
                    buyCustomerStocks.SharePrice=buyStock.SharePrice;
                    buyCustomerStocks.NumberOfStock = numofShares;
                    cust_list.Add(buyCustomerStocks);
                }
            }
        }

        public void SellStock(string name, int numofShares)
        {
            CustomerDetails sellCustomerStocks = new CustomerDetails();
            foreach (var data in cust_list)
            {
                if (data.StockSymbol.ToLower().Equals(name.ToLower()))
                {
                    if (numofShares <= data.NumberOfStock)
                    {
                        sellCustomerStocks = data;
                        data.NumberOfStock -= numofShares;
                        break;
                    }
                }
                else
                {
                    sellCustomerStocks = null;
                }
            }
            if (sellCustomerStocks == null)
            {
                Console.WriteLine("No stocks available or entered shares exceeded your holding");
            }
            else
            {
                StockDetails sellStock = new StockDetails();
                foreach (var data in StockOperations.list)
                {
                    if (data.StockName.ToLower().Equals(name.ToLower()))
                    {
                            sellStock = data;
                            data.NoOfShares += numofShares;
                            amount += data.SharePrice * numofShares;
                            break;
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
