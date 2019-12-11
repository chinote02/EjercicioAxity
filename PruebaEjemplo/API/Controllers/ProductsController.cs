using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ProductsController : ApiController
    {
        BLL.Products products = new BLL.Products();

        [HttpGet]
        public DataTable Get()
        {
            DataRowCollection result = products.GetProducts().Rows;
            return result.Count > 0 ? result[0].Table : new DataTable();
        }
    }
}
