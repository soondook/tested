using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace tested
{

    class MyClass
    {
        public string Path { get; set; }
        public string DataTime { get; set; }
    }

    public class CategoryData
    {
        public IList<string> Category { get; set; }
        public IList<string> Product { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            //List<MyClass> data = new List<MyClass>() { };
            List<string> data = new List<string>() { };
            List<string> data1 = new List<string>() { };

            //List<MyClass> data = new List<MyClass>() { new MyClass() { Path = "email1@email.com", DataTime = "good2go" }, new MyClass() { Path = "email2@email.com", DataTime = "good2go" } };
            string[] input = { "2020806" };
            string[] input1 = { "2020807" };
            //data.Add(new MyClass() { Path = "crank arp", DataTime = "1235" });
            data.AddRange(input);
            data1.AddRange(input1);

            //Serialize
            var json = JsonConvert.SerializeObject(new
            {
                Product = data,
                Category = data1
            });
            Console.WriteLine(json);
            //Deserialize
            CategoryData Products = JsonConvert.DeserializeObject<CategoryData>(json);
            //CategoryData Products = JsonConvert.DeserializeObject<CategoryData>(json);
            //string pp = "";
            foreach (string Product1 in Products.Product)
            {
                foreach (string pp in Products.Category)
                {

                    Console.WriteLine(Product1.ToString() + pp.ToString());
                }
            }
        }
    }
}
