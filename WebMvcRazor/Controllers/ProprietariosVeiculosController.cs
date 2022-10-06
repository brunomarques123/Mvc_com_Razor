using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcRazor.ViewModel;

namespace WebMvcRazor.Controllers
{
    public class ProprietariosVeiculosController : Controller
    {
        public ActionResult Index (int id)
        {
            HttpCookie cookie = Request.Cookies["AgenciaAuto"];
            if(cookie == null)
            {
                ViewBag.Title = "Veiculos do proprietário";
                ViewBag.Message = " Relação de veiculos de ";

                var proprietario = new ProprietariosVeiculosViewModel();
                var lista = proprietario.GetVeiculos(id);

                return View(lista);
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }
    }
}