using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Credit
    {
        public int creditId { get; set; }
        public string bank { get; set; }
        public string title { get; set; }
        public string rate { get; set; }
        public int sum { get; set; }
    }
}