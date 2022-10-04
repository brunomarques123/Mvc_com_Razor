using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcRazor.Models;

namespace WebMvcRazor.Controllers
{
    public class VeiculosController : Controller
    {
        // GET: Veiculos
        public ActionResult Adicionar()
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Adicionar Veiculos";
            return View();
        }

        public ActionResult Alterar(int id)
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Alterar Veiculos " + id;

            var veiculo = new Veiculos();
            veiculo.GetVeiculo(id);
            //ViewBag.Veiculo = veiculo;

            return View(veiculo);
        }
        public ActionResult Excluir(int id)
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Excluir Veiculos " + id;

            var veiculo = new Veiculos();
            veiculo.GetVeiculo(id);
            ViewBag.Veiculo = veiculo;

            return View();
        }



        [HttpPost]
        public ActionResult Salvar(Veiculos veiculo)
        {
            //var veiculo = new Veiculos();
            //veiculo.Id = Convert.ToInt32("0" + Request["id"]);
            //veiculo.Nome = Request["nome"];
            //veiculo.Modelo = Request["modelo"];
            //veiculo.Ano = Convert.ToInt16(Request["fabricacao"]);
            //veiculo.Fabricacao = Convert.ToInt16(Request["fabricacao"]);
            //veiculo.Cor = Request["cor"];
            //veiculo.Combustivel = Convert.ToByte(Request["combustivel"]);
            //veiculo.Automatico = false;
            //veiculo.Valor = Convert.ToDecimal(Request["valor"]);
            //veiculo.Ativo = true;

            if (ModelState.IsValid)
            {
                veiculo.Salvar();
                //Response.Redirect("/Home/Veiculo");
                return RedirectToAction("Veiculo", "Home");
            }
            else
            {
                ViewBag.Title = "Veiculos";
                if(Convert.ToInt32("0" + Request["id"]) == 0)
                {
                    ViewBag.Message = "Adicionar veiculos";
                    return View("Adicionar");
                }
                else
                {
                    ViewBag.veiculo = veiculo;
                    ViewBag.Message = "Alterar veiculos" + veiculo.Id;
                    return View("Alterar");
                }
                
            }
                

            

           
        }

        [HttpPost]
        public void Excluir()
        {
            var veiculo = new Veiculos();
            veiculo.Id = Convert.ToInt32("0" + Request["id"]);

            veiculo.Excluir();
                
        }
    }
}