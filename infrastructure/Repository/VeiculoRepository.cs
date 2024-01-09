using Dapper;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VeiculoRepository: IVeiculoRepository
    {
        private string stringconnection = "";
        public async Task<string> PostAsync(Veiculo command)
        {
            string queryInsert = @"INSERT INTO Veiculo(Placa, AnoFabricacao, TipoVeiculoId, Estado, MontadoraId)\\r\\nVALUES(@Placa, @Anofabricacao, @TipoVeiculoId, @Estado, @MontadoraId)\\r\\n\";
            using (var conn = new SqlConnection())
            {
                conn.Execute(queryInsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnoFabricacao,
                    TipoVeiculoId = command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraId = command.Montadora,
                });
                return "Veiculo Cadastrado com Sucesso !"
            }
        }
        public void PostAsync()
        {

        }
        public void GetAsync()
        {

        }
    }
}
