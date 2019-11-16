using Core.DTOs;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace WebApi.Controllers
{
    [Route("/compra")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;
        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public IEnumerable<CompraDTO> GetAll()
        {
            return _compraService.GetAll();
        }

        [HttpPost]
        public bool Insert([FromBody] CompraDTO compra)
        {
            return _compraService.Salvar(compra);
        }

        [HttpGet("simular")]
        public CompraDTO Simular([FromQuery] double valor, [FromQuery] double juros, [FromQuery] int quantidadeParcela, [FromQuery] DateTime data)
        {
            return _compraService.Simular(valor, juros, quantidadeParcela, data);
        }
    }
}
