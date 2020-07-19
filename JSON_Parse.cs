using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
namespace tested
{
    public class JSON_Parse
    {

        public IList<CategoryData> Products { get; set; }

        public class CategoryData
        {
            public string Category { get; set; }
            public string[] Product { get; set; }
        }

        public void OnGet()
        {
            var json = System.IO.File.ReadAllText(@"C:\Temp1\Product_catalog.json");
            Products = JsonConvert.DeserializeObject<IList<CategoryData>>(json);
            Console.Write(Products);
        }

        
    }
}
