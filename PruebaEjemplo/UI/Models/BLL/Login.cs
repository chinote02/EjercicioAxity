using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI.Models.BLL
{
    public class Login
    {
        public DTO.ResponseMessage Authenticate (string usr, string pwd)
        {
            HttpClient client = new HttpClient();
            DTO.ResponseMessage responseMessage = new DTO.ResponseMessage();

            //La ruta se coloca asi directo para motivos de ejemplo, pero esto iria en un archivo de configuracion
            string path = string.Format("http://localhost:55918/api/Login?usr={0}&pwd={1}", usr, pwd);
            
            var task = client.GetAsync(path).ContinueWith((taskwithresponse) =>
            {
                var r = taskwithresponse.Result;
                var jsonString = r.Content.ReadAsStringAsync();
                jsonString.Wait();
                //Corregir el parseo, existe el objeto response desde el controlador origen
                responseMessage = JsonConvert.DeserializeObject<DTO.ResponseMessage>(jsonString.Result);

                if (!r.IsSuccessStatusCode)
                    responseMessage.HasError = true;

                if (string.IsNullOrEmpty(responseMessage.HttpReDirect))
                    responseMessage.HttpReDirect = "/Home/DetailList";
            });

            task.Wait();

            return responseMessage;
        }
    }
}