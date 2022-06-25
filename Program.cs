using System;
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
using tested.Services;
using System.Net.Mail;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace tested
{

    public class MyClass
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

        //public List<Person1> People { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class CategoryData
    {
        public List<Person1> Category { get; set; }
        public List<MyClass> Product { get; set; }
    }
    
    public class CategoryData1
    {
        public string Category { get; set; }
        public List<string> Product { get; set; }
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
        
        public MyContainer(List<string> firstNames, List<string> lastNames)
        {
            FirstNames = firstNames;
            LastNames = lastNames;
        }
        */
    }


    class Program
    {
        private static mailConfig _config;
        private static EmailConfig _email;
        //public IList<CategoryData1> Product { get; set; }
        static void Main(string[] args)
        {

            string encrypt = "passwordAdministratorPassword2017";
            string encryptedText = "";
            //PSInvoke.PowerNETDOM(encrypt);
            encryptedText = PSInvoke.PowerEDM(encrypt);
            Console.WriteLine(encryptedText);
            //AES_Encrypt.AesEDM(encrypt);
            AES_Encrypt.DecryptAES(encryptedText);
            //string hosts = "smtp.gmail.com";
            //EmailSender(string host, int port, bool enableSSL, string userName, string password)

            //EmailSender(_email);

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
            string json5 = "{\"d\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"},{\"FirstName\":\"John\",\"LastName\":\"Neil\"}]}";
            JObject obj = JObject.Parse(json5);
            var jarr = obj["d"].Value<JArray>();
            List<Person1> lst = jarr.ToObject<List<Person1>>();
            //Console.WriteLine("{0}, {1}", lst[0].FirstName, lst[0].LastName);
            //Console.WriteLine("{0}, {1}", lst[1].FirstName, lst[1].LastName);
            List<Person1> listOfLists = new List<Person1>();
            //input.SelectMany(list => list).ToList()
            var results = string.Join(",", lst[1].FirstName);
            //Console.WriteLine(results.ToString());



            JObject b = JObject.Parse(json5);
            JArray c = (JArray)b["d"];

            List<Person1> person = c.ToObject<List<Person1>>();
            for (int i = 0; i < person.Count; i++)
            {
                string[] input2 = { "FirstName: " + person[i].FirstName, "LastName: " + person[i].LastName };
                //string[] input5 = { "FirstName: " + person[1].FirstName, "LastName: " + person[1].LastName };
                //string[] input6 = { "FirstName: " + person[2].FirstName, "LastName: " + person[2].LastName };
                //Console.WriteLine(person[0].FirstName + person[0].LastName);
                // John Smith
                pointList2.AddRange(input2);
                //pointList2.AddRange(input5);
                //pointList2.AddRange(input6);
            }
            //Console.WriteLine(person[1].FirstName +  person[1].LastName);
            // Mike Smith
            //string dogCsv = pointList2.ToArray();
            //Console.WriteLine(pointList2[1].ToString());
            List<MyClass> arrays = new List<MyClass>() { };
            arrays.Add(new MyClass() { email_address = "email1@email.com", status = "good1go" });
            arrays.Add(new MyClass() { email_address = "email2@email.com", status = "good2go" });
            //list.Add(new Test(1, 2));
            //object[,] arrays = new object[,]{ { "email1@email.com", "good1go" }, { "email1@email.com", "good2go" } };
            //string[] input5 = {"email1@email.com", "good1go"};
            //string[] input6 = {"email2@email.com", "good2go" };
            //object[,] additionalItem = "foobar";
            //string result = arrays.
            //arrays.AddRange(input6);
            //arrays.SetValue(${ "email1@email.com"}, ${ "good1go"});
            //Console.WriteLine(arrays[1].email_address + arrays[1].status);

            List<MyClass> newData = new List<MyClass>() { };
            newData.AddRange(new List<MyClass>() { new MyClass() { email_address = "email3@email.com", status = "good3go" } });
            newData.AddRange(new List<MyClass>() { new MyClass() { email_address = "email4@email.com", status = "good4go" } });
            //string[] input_ = { email_address = "email1@email.com", status = "good1go" }
            //newData = new List<MyClass>() { new MyClass() { email_address = "email1@email.com", status = "good1go" } };
            //newData = new List<MyClass>() { new MyClass() { email_address = "email2@email.com", status = "good2go" } };
            //email_address = "email1@email.com", status = "good1go" }, new MyClass() { email_address = "email2@email.com", status = "good2go" } };
            /*
            var jsons = JsonConvert.SerializeObject(new
            {
                operations = newData
            });
            */
            //Console.Write(jsons);
            var jsons1 = File.ReadAllText(@"C:\Temp1\Product_catalog.json");
            CategoryData1 Products1 = JsonConvert.DeserializeObject<CategoryData1>(jsons1);
            //MyClass Products1 = JsonConvert.DeserializeObject<MyClass>(jsons);

            foreach (string Product3 in Products1.Product)
            {
                Console.WriteLine(Product3.ToString());
            }

            string json3 = "{\"People\":[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"},{\"FirstName\":\"John\",\"LastName\":\"Neil\"}]}";

            var result = JsonConvert.DeserializeObject<RootObject>(json3);
            var firstNames = result.People.Select(p => p.FirstName).ToList();
            var lastNames = result.People.Select(p => p.LastName).ToList();
            //string[] input2 = { firstNames.ToList(), lastNames.ToString()};
            //pointList2.AddRange(firstNames);
            //pointList2.AddRange(lastNames);
            //pointList2.Add(new MyContainer(firstNames, lastNames).FirstNames.ToString());
            //pointList2.AddRange(input2);

            foreach (string Product3 in pointList2)
            {

                //Console.WriteLine(Product2.ToString());
            }
            /*
            //Console.Write(pointList2[0]);
            object[] array = pointList2.ToArray();
            //int i = -1;
            for (int i = 0; i < pointList2.Count; i++)
            {
                //jsn = array.GetValue(i);
                //object jsn2 = array.GetValue(6);
                //obj[$"{i}"] = $"{jsn}";
                //obj[$"{2}"] = $"{jsn2}";
                //Console.WriteLine(array.GetValue(i) + $"{i}");
            }
            */
            List<Person1> json6 = new List<Person1>() { };
            //string json6 = "[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"},{\"FirstName\":\"John\",\"LastName\":\"Neil\"}]";
            json6.AddRange(new List<Person1>() { new Person1() { FirstName = "Hans", LastName = "Olo" } });
            var json = JsonConvert.SerializeObject(new
            {
                Product = newData,
                Category = json6
            });
            Console.WriteLine(json);
            //Deserialize
            CategoryData Products = JsonConvert.DeserializeObject<CategoryData>(json);
            //Console.WriteLine(Products.Product[1].email_address);
            foreach (var Product3 in Products.Product)
            {
                Console.WriteLine(Product3.email_address);

                foreach (var Product4 in Products.Category)
                {
                    Console.WriteLine(Product4.FirstName + Product4.LastName);
                }
            }

            //return json6;
        }




        //public static IFormFile Attachment { get; set; }
        public System.Net.Mail.AttachmentCollection Attachments { get; }
        public static string EmailSender(EmailConfig _email)
        {

            
            using (MailMessage mm = new MailMessage("atmtechportal.for.all@gmail.com", "soondook@gmail.com"))
            {
               
                //_email.To = "soondook@gmail.com";
                mm.Subject = "1";
                mm.Body = "2";
                //string file = "data.xls";
                string file = Path.GetFileName("C:\\cygwin64\\home\\OpenSSH\\sql_res1.yml");
                Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                mm.Attachments.Add(data);
                //if (Attachment.Length > 0)
                //{
                //Attachment at = new Attachment(Server.MapPath("~/Uploaded/txt.doc"));
                //string fileName = Path.GetFileName("C:\\cygwin64\\home\\OpenSSH\\sql_res1.yml");
                //string fileName = Path.GetFileName(Attachment.FileName);
                //mm.Attachments.Add(new Attachment(_email.Attachment.OpenReadStream(), fileName));
                //}

                mm.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("atmtechportal.for.all@gmail.com", "erqgwvcuobazlpvy");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
            return null;
        }

    } 
}
