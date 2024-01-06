using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVeiculoService
    {
        // A interface é um contrato apenas usamos para  adicionar métodos, não é feita a implementação de nada.
        Task <string> PostAsync(VeiculoCommand command);
        void PostAsync();
        void GetAsync();
    }
}
