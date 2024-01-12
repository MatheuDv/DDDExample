using Dapper;
using Domain.Commands;
using Domain.Entidades;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=true";

        public async Task<string> PostAsync(VeiculoCommand command)
        {
            string queryInsert = @"
                INSERT INTO Veiculo(Placa, AnoFabricacao, TipoVeiculoId, Estado, MontadoraId)
                VALUES(@Placa, @AnoFabricacao, @TipoVeiculoId, @Estado, @MontadoraId)";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                await conn.ExecuteAsync(queryInsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnoFabricacao,
                    TipoVeiculoId = (int)command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraId = (int)command.Montadora
                });

                return "Veiculo Cadastrado com sucesso";
            }
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculosAlugadosAsync()
        {
            string querySelect = "SELECT * FROM Veiculo WHERE StatusAluguel = 1";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                var carrosAlugados = await conn.QueryAsync<Veiculo>(querySelect);
                return carrosAlugados;
            }
        }
        public async Task<IEnumerable<Veiculo>> GetVeiculosDisponiveisAsync()
        {
            string querySelect = "SELECT * FROM Veiculo WHERE StatusAluguel = 0";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                var carrosAlugados = await conn.QueryAsync<Veiculo>(querySelect);
                return carrosAlugados;
            }
        }



        public void PostAsync()
        {
            throw new NotImplementedException();
        }

        public void GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<VeiculoCommand>> IVeiculoRepository.GetVeiculosAlugadosAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<VeiculoCommand>> IVeiculoRepository.GetVeiculosDisponiveisAsync()
        {
            throw new NotImplementedException();
        }
    }
}
