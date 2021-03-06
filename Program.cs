﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Collections;

namespace tested
{

    class MyClass
    {
        public string email_address { get; set; }
        public string status { get; set; }
    }


    public class RootObject
    {
        public List<Person> People { get; set; }
    }
    public class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Person1
    {

        public List<Person1> People { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    



    public class CategoryData
    {
        public IList<string> Category { get; set; }
        public IList<string> Product { get; set; }
    }

    public class CategoryData1
    {
        public string Category { get; set; }
        public IList<string> Product { get; set; }
    }


    public class MyContainer
    {
        public List<string> FirstNames { get; set; }
        public List<string> LastNames { get; set; }

        //public string Number { get; set; }
        //public string Title { get; set; }
        /*public MyContainer(string number, string title)
        {
            Number = number;
            Title = Title;
        }
        */
        public MyContainer(List<string> firstNames, List<string> lastNames)
        {
            FirstNames = firstNames;
            LastNames = lastNames;
        }
    }


    class Program
    {


        //public IList<CategoryData1> Product { get; set; }
        static void Main(string[] args)
        {


            //IInvokeOnGetBinder();
            //List<CategoryData> data = new List<CategoryData>() { };
            List<string> data = new List<string>() { };
            List<string> data1 = new List<string>() { };
            List<string> pointList2 = new List<string>() { };
            //List<MyClass> data = new List<MyClass>() { new MyClass() { Path = "email1@email.com", DataTime = "good2go" }, new MyClass() { Path = "email2@email.com", DataTime = "good2go" } };
            string[] input1 = { "2020803", "Category_2020803" };
            //string[] input2 = { "Product_2020802" };
            string[] input3 = { "2020804", "Category_2020804" };
            //string[] input4 = { "Product_2020804" };
            //data.Add(new MyClass() { Path = "crank arp", DataTime = "1235" });
            data.AddRange(input1);
            //data.AddRange(input2);
            data.AddRange(input3);
            //data1.AddRange(input4);
            //object[] array2 = data.ToArray();
            //Console.WriteLine(array2[2]);
            //Serialize
            string json5 = "{\"d\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]}";
            JObject obj = JObject.Parse(json5);
            var jarr = obj["d"].Value<JArray>();
            List<Person1> lst = jarr.ToObject<List<Person1>>();
            Console.WriteLine("{0}, {1}", lst[0].FirstName, lst[0].LastName);
            Console.WriteLine("{0}, {1}", lst[1].FirstName, lst[1].LastName);
            var results = string.Join(",", lst[1].FirstName);
            Console.WriteLine(results.ToString());

            

            JObject b = JObject.Parse(json5);
            JArray c = (JArray)b["d"];
            
            IList<Person1> person = c.ToObject<IList<Person1>>();
            string[] input2 = { "FirstName: " + person[0].FirstName, "LastName: " + person[0].LastName };
            string[] input5 = { "FirstName: " + person[1].FirstName, "LastName: " +person[1].LastName };
            //Console.WriteLine(person[0].FirstName + person[0].LastName);
            // John Smith
            pointList2.AddRange(input2);
            pointList2.AddRange(input5);
            //Console.WriteLine(person[1].FirstName +  person[1].LastName);
            // Mike Smith
            //string dogCsv = pointList2.ToArray();
            //Console.WriteLine(pointList2[1].ToString());


            List<MyClass> newData = new List<MyClass>() { new MyClass() { email_address = "email1@email.com", status = "good2go" }, new MyClass() { email_address = "email2@email.com", status = "good2go" } };
            var jsons = JsonConvert.SerializeObject(new
            {
                operations = newData
            });

            //Console.Write(jsons);
            var jsons1 = System.IO.File.ReadAllText(@"C:\Temp1\Product_catalog.json");
            CategoryData1 Products1 = JsonConvert.DeserializeObject<CategoryData1>(jsons1);
            //MyClass Products1 = JsonConvert.DeserializeObject<MyClass>(jsons);
            
            foreach (string Product2 in Products1.Product)
{
                //Console.Write(Product2);
            }

            string json3 = "{\"People\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]}";

            var result = JsonConvert.DeserializeObject<RootObject>(json3);
            var firstNames = result.People.Select(p => p.FirstName).ToList();
            var lastNames = result.People.Select(p => p.LastName).ToList();
            //string[] input2 = { firstNames.ToList(), lastNames.ToString()};
            //pointList2.AddRange(firstNames);
            //pointList2.AddRange(lastNames);
            //pointList2.Add(new MyContainer(firstNames, lastNames).FirstNames.ToString());
            //pointList2.AddRange(input2);
            /*
            foreach (string Product2 in pointList2)
            {
                
                //Console.Write("FirstName: " + Product2.ToString());
            }
            */
            //Console.Write(pointList2[0]);
            object[] array = pointList2.ToArray();
            int i = -1;
            for (i = 0; i < pointList2.Count; i++)
            {
                //jsn = array.GetValue(i);
                //object jsn2 = array.GetValue(6);
                //obj[$"{i}"] = $"{jsn}";
                //obj[$"{2}"] = $"{jsn2}";
                //Console.WriteLine(array.GetValue(i) + $"{i}");
            }
            

            var json = JsonConvert.SerializeObject(new
            {
                Product = data,
                Category = data1
            });
            //Console.WriteLine(json);
            //Deserialize
            //CategoryData Products = JsonConvert.DeserializeObject<CategoryData>(json);
            //CategoryData Products = JsonConvert.DeserializeObject<CategoryData>(json);
            //string pp = "";
            /*
            JArray a = JArray.Parse("[" + json3 + "]");
            i = 0;
            foreach (JObject o in a.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    i++;
                    var name = p.Name;
                    var  value = p.Value.ToString();
                    var response1 = value.Replace("[", "").Replace("]", "");
                    response1 = response1.Replace("{", "").Replace("}", "");
                    IEnumerable<string> items = (IEnumerable<string>)(IEnumerable)response1;
                    Console.WriteLine(response1);
                    //pointList2.AddRange(response1.ToList());
                    
                    if (name.StartsWith("Id"))
                    {
                        Console.WriteLine(name + " -- " + value);
                    }
                    if (name.StartsWith("Token"))
                    {
                        Console.WriteLine(name + " -- " + value);
                    }
                    
                }
            }
            */

        }

        
    }

    
}
