using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcRazor.Models;

namespace WebMvcRazor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Autorizado"] != null)
            {
                return View();
            }
            else
            {
                //Response.Redirect("/Login/Index");
                //return null;
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Veiculo()
        {
            ViewBag.Title = "Vende-se";
            ViewBag.Message = "Relação de veiculos";

            if (Session["Autorizado"] != null)
            {
                var lista = Veiculos.GetCarros();
                ViewBag.Lista = lista;

                return View();
            }
            else
            {
                //    Response.Redirect("/Login/Index");
                //    return null;
                return RedirectToAction("Index", "Login");
            }


        }

        public ActionResult Contact()
        {
            if (Session["Autorizado"] != null)
            {
                ViewBag.Message = "Seus Contatos.";

                return View();
            }
            else
            {
                //Response.Redirect("/Login/Index");
                //return null;
                return RedirectToAction("Index", "Login");
            }

        }
    }
}