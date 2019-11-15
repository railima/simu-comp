using Core.DTOs;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
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


    }
}
