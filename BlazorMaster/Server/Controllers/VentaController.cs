using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorMaster.Server.Models;
using Microsoft.EntityFrameworkCore;
using BlazorMaster.Shared;

namespace BlazorMaster.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly DbpruebaContext _dbContext;

        public VentaController(DbpruebaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VentaDTO ventaDTO)
        {
            try
            {
                var mdVenta = new Venta();
                var mdDetalleVenta = new List<DetalleVenta>();

                mdVenta.Cliente = ventaDTO.Cliente;
                mdVenta.Total = ventaDTO.Total;

                foreach(var item in ventaDTO.DetalleVenta)
                {
                    mdDetalleVenta.Add(new DetalleVenta
                    {
                        IdProducto = item.Producto.IdProducto,
                        Cantidad = item.Cantidad,
                        SubTotal = item.SubTotal,
                    });
                }

                mdVenta.DetalleVenta = mdDetalleVenta;
                _dbContext.Venta.Add(mdVenta);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex);
            }
        }

    }
}
