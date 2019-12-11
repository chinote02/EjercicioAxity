using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BLL;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        BLL.Login login = new BLL.Login();

        [HttpGet]
        public IHttpActionResult Get([FromUri]string usr, [FromUri]string pwd)
        {
            Models.ResponseMessage responseMessage = new Models.ResponseMessage();

            if (login.IsValid(usr, pwd)) {
                //Se puede validar que aunque tenga las credenciales correctas. El usuario no tenga permisos de acceder al modulo.
                //La complejidad del Login, puede ser diferente, pero por motivos practicos. Se genera de dicha manera.
                responseMessage.Message = "Correcto";
                //Se puede enviar a un modulo diferente en caso de ser necesario. De ahí la redirección, pero para caso del ejericio, nos evitamos la fatiga y enviamos directo al listado
                responseMessage.HttpReDirect = "/Home/DetailList";
                //Para complementar la validación de algún modulo, puede que tengas un login correcto, pero no acceso a la aplicación.
                responseMessage.HasError = false;
            }
            else {
                return BadRequest("Acceso denegado");
            }

            return Ok(new { response = JsonConvert.SerializeObject(responseMessage) });
        }
    }
}
