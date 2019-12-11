using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.DTO
{
    public class Products
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
    }
}