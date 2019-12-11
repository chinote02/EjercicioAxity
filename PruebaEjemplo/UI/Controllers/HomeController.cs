using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        Models.BLL.Login login = new Models.BLL.Login();
        Models.BLL.Products products = new Models.BLL.Products();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Login(string usr, string pwd)
        {
            Models.DTO.ResponseMessage result = login.Authenticate(usr, pwd);
            return Json(new { result }, JsonRequestBehavior.AllowGet) ;
        }

        public ActionResult DetailList()
        {
            //Incluir validación de sesión
            ViewBag.ProductList = products.GetProductList();

            return View();
        }
    }
}