using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebMvcRazor
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "VeiculosSalvar",
                "Veiculos/Salvar",
                new { controller = "Veiculos", action = "Salvar"});

            routes.MapRoute(
                "VeiculosExcluir",
                "Veiculos/Excluir/:id",
                new { controller = "Veiculos", action = "Excluir", id =0});

            routes.MapRoute(
                "VeiculosAlterar",
                "Veiculos/Alterar/:id",
                new { controller = "Veiculos", action = "Alterar", id = 0});

            routes.MapRoute(
                "VeiculosAdicionar",
                "Veiculos/Adicionar",
                new { controller = "Veiculos", action = "Adicionar"});

            //routes.MapRoute(
            //    "Login",
            //    "Login/ChecarLogin",
            //    new { controller = "ChecarLogin",  action = "Index"
            //    });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
