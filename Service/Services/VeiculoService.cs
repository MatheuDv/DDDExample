using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        public void GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> PostAsync(VeiculoCommand command)
        {
            if (command == null)
            {
                // Trate a situação em que command é nulo.
                return "Todos os campos são obrigatórios";
            }

            // Incluir validação, só podem cadastrar veículos com até 5 anos de uso.
            int anoAtual = DateTime.Now.Year;
            if ((anoAtual - command.AnoFabricacao) > 5)
            {
                return "O veículo não pode ter mais de 5 anos de uso";
            }

            // Incluir somente carros do tipo SUV, Sedan e Hatch.
            if (command.TipoVeiculo != ETipoVeiculo.SUV
                && command.TipoVeiculo != ETipoVeiculo.Hatch
                && command.TipoVeiculo != ETipoVeiculo.Sedan)
            
                return "O tipo de veículo não é permitido";

            return _veiculoRepository.PostAsync(command);


            // TODO: Implementar a lógica para cadastrar o veículo.

            // Retorna uma tarefa completada sem um resultado específico.
            return "Cadastro Realizado com Sucesso";
        }

        public void PostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
