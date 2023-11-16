using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("{nombre?}")]
        public IActionResult GetAll(string? nombre)
        {
            List<object> list = BL.Producto.GetAll(nombre);

            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{idProducto}")]
        public IActionResult Delete(int idProducto)
        {
            int affectedRow = BL.Producto.Delete(idProducto);

            if (affectedRow == 1)
            {
                return Ok("Correct");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add(ML.Producto producto)
        {
            int affectedRow = BL.Producto.Add(producto);

            if (affectedRow == 1)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("byId/{idProducto}")]
        public IActionResult GetById(int idProducto)
        {
            object producto = BL.Producto.GetById(idProducto);

            if (producto != null) 
            {
                return Ok(producto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update(ML.Producto producto)
        {
            int affectedRow = BL.Producto.Update(producto);

            if (affectedRow == 1)
            {
                return Ok("Succesfully updated");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
