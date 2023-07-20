using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.StockAccountManagement
{
    internal class StockOperations
    {
        public void ReadStockJson(string filepath)
        {
            var json = File.ReadAllText(filepath);
            List<StockDetails> list = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.StockName + " " + data.NoOfShares + " " + data.SharePrice);

            }
        }
}
}
