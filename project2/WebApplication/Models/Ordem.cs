using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Ordem
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public int companyId { get; set; }
        public string email { get; set; }
        public int type { get; set; }
        public int quant { get; set; }

        public string creationDate { get; set; }
        public string executionDate { get; set; }
        public double valueStock { get; set; }
        public int state { get; set; }
    }
}