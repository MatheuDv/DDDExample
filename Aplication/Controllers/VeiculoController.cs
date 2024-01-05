using Domain.Commands;
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

        [HttpPost]
        [Route("CadastrarVeiculo")]
        public async Task <IActionResult> PostAsync([FromBody] VeiculoCommand command)
        {
            await _veiculoService.PostAsync(command);
            return Ok();
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
    }
}
