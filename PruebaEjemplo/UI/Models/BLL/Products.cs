using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace UI.Models.BLL
{
    public class Products
    {
        public List<DTO.Products> GetProductList()
        {
            HttpClient client = new HttpClient();
            List<DTO.Products> responseMessage = new List<DTO.Products>();

            //La ruta se coloca asi directo para motivos de ejemplo, pero esto iria en un archivo de configuracion
            string path = string.Format("http://localhost:55918/api/Products");

            var task = client.GetAsync(path).ContinueWith((taskwithresponse) =>
            {
                var r = taskwithresponse.Result;
                var jsonString = r.Content.ReadAsStringAsync();
                jsonString.Wait();
                responseMessage = JsonConvert.DeserializeObject<List<DTO.Products>>(jsonString.Result);
            });

            task.Wait();

            return responseMessage;
        }
    }
}