using Domain.Commands;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        [HttpPost]
        [Route("CadastrarVeiculo")]
        public async Task <IActionResult> PostAsync([FromBody] VeiculoCommand command)
        {
            return Ok(await _veiculoService.PostAsync(command));
        }
        [HttpGet]
        [Route("SimularAluguel")]
        public IActionResult GetAsync() 
        {
            return Ok();
        }
        [HttpGet]
        [Route("Alugar")]
        public IActionResult PostAsync() 
        {
            return Ok();
        }
      
        [HttpGet("Veiculos alugados")]
        public async Task<IActionResult> GetVeiculoslugadosAsync()
        {
            return Ok(await _veiculoService.GetVeiculosAlugadosAsync());
        }
        [HttpGet("Veiculos Disponiveis")]
        public async Task<IActionResult> GetVeiculosDisponiveisAsync()
        {
            return Ok(await _veiculoService.GetVeiculosDisponiveisAsync());
        }
    }
}
