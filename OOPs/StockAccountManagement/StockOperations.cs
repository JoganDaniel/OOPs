using Newtonsoft.Json;
using OOPs.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.StockAccountManagement
{
    public class StockOperations
    {
        public static List<StockDetails> list;
        public void ReadStockJson(string filepath)
        {
            var json = File.ReadAllText(filepath);
            list = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.StockName + " " + data.NoOfShares + " " + data.SharePrice);

            }

        }
        public void WriteToStockJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filepath, json);
        }
    }
}
