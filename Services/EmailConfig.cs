using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace tested
{
    public class EmailConfig
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IFormFile Attachment { get; set; }
    }
    public class mailConfig
    {
        public string mailFrom { get; set; }
        public string mailpassword { get; set; }
    }
}
