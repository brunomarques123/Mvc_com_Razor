using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebMvcRazor.Models;

namespace WebMvcRazor.ViewModel
{
    public class ProprietariosVeiculosViewModel
    {
        private readonly static string _conn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int Id { get; set; }
        public string Nome { get; set; }
        public List<VeiculosViewModel> Veiculos { get; set; }


        public ProprietariosVeiculosViewModel GetVeiculos(int id)
        {
            var sql = "SELECT Id, Nome FROM Proprietarios WHERE Id=@idProprietario";

            var proprietarioVeiculos = new ProprietariosVeiculosViewModel();
            var listaVeiculos = new List<VeiculosViewModel>();

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();

                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdProprietario", id);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    proprietarioVeiculos.Id = Convert.ToInt32(dr["Id"]);
                                    proprietarioVeiculos.Nome = dr["Nome"].ToString();
                                }
                            }
                        }
                        cmd.CommandText = "SELECT Id, Nome Marca, Modelo, Ano, Fabricacao, Cor, Combustivel, Automatico, Valor, Ativo FROM tb_veiculos WHERE Proprietario = @IdProprietario";

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    listaVeiculos.Add(new VeiculosViewModel(
                                        Convert.ToInt32(dr["Id"]),
                                        dr["Marca"].ToString(),
                                        dr["Modelo"].ToString(),
                                        Convert.ToInt16(dr["Ano"]),
                                        Convert.ToInt16(dr["Fabricacao"]),
                                        dr["Cor"].ToString(),
                                        (Combustivel)Convert.ToByte(dr["Combustivel"]),
                                        (SimNao)Convert.ToByte(dr["Automatico"]),
                                        Convert.ToDecimal(dr["Valor"]),
                                        Convert.ToBoolean(dr["Ativo"])
                                        ));

                                }
                            }
                        }
                    }
                  
                }

            }
            catch (Exception ex)
            {
                               
                Console.WriteLine("Falha: " + ex.Message);
            }
            proprietarioVeiculos.Veiculos = listaVeiculos;

            return proprietarioVeiculos;
        }

    }
}