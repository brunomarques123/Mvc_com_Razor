using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcRazor.Models;

namespace WebMvcRazor.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["Erro"] != null)
                ViewBag.Erro = Session["Erro"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult ChecarLogin()
        {
            var usuario = new Usuarios();
            usuario.Email = Request["Email"];
            usuario.Senha = Request["PassWord"];

            if (usuario.Login())
            {
                Session["Autorizado"] = "OK";
                Session.Remove("Erro");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["Erro"] = "Senha ou usúario invalidos";
                //Response.Redirect("/Login/Index");
                return RedirectToAction("Index", "Login");
            }
        }
    }
}