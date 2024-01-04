﻿using Domain.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        [HttpPost("CadastrarVeiculo")]
        public IActionResult PostAsync([FromBody] VeiculoCommand command) 
        {
            return Ok();
        }
        public IActionResult SimularAluguel() 
        {
            return Ok();
        }
        public IActionResult Alugar() 
        {
            return Ok();
        }
    }
}