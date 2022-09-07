using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.ADO_Repository;
using API.Controllers.DTOS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }
        [HttpDelete]
        public bool EliminarVenta([FromBody] int id)
        {
            return VentaHandler.EliminarVenta(id);
        }
        [HttpPost]
        public bool CrearVenta([FromBody] PostVenta venta)
        {
            return VentaHandler.CrearVenta(new Venta
            {
                Comentarios = venta.Comentarios
            });
        }
    }
}