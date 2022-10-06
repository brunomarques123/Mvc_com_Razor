using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcRazor.Models;

namespace WebMvcRazor.ViewModel
{
    public class VeiculosViewModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public short Ano { get; set; }
        public short Fabricacao { get; set; }
        public string Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public SimNao Automatico { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

        public VeiculosViewModel(int id, string marca, string modelo, short ano, short fabricacao, string cor, Combustivel combustivel, SimNao automatico, decimal valor, bool ativo)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Fabricacao = fabricacao;
            Cor = cor;
            Combustivel = combustivel;
            Automatico = automatico;
            Valor = valor;
            Ativo = ativo;
        }
    }
}