using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCoffi.Data;
using ProyectoCoffi.Models;
using ProyectoCoffi.Service;

namespace ProyectoCoffi.Controllers.Rest
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoApiController : ControllerBase
    {
        private readonly PedidoService _pedidoService;
        public PedidoApiController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Pedido>>> VerPedidos()
        {
            var listapedido = await _pedidoService.Mostrar();
            if (listapedido == null)
                return NotFound();
            return Ok(listapedido);
        }

        [HttpGet("{userID}")]
        public async Task<ActionResult<Pedido>> GetPedidos(string? userID)
        {
            var selecPedido = await _pedidoService.Get(userID);
            if (selecPedido == null)
                return NotFound();
            return Ok(selecPedido);
        }
    }
}