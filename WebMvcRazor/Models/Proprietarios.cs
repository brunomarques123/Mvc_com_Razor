using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebMvcRazor.Models
{
    public class Proprietarios
    {
        private readonly static string _conn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage ="O nome do Propritario é obrigatorio")]
        public string Nome { get; set; }

    }
}