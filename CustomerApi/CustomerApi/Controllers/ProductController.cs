using CustomerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly PruebaContext _bdContext;

        public ProductController(PruebaContext bdContext)
        {
            _bdContext = bdContext;
        }

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            List<Product> lista = new List<Product>();
            try
            {
                lista = _bdContext.Products.ToList();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("GetById/{idProduct:int}")]
        public IActionResult GetById(int idProduct)
        {
            Product oProduct = _bdContext.Products.Find(idProduct);

            if (oProduct == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {
                //oProduct = _bdContext.Products.Include(c => c.Categoria).Where(p => p.IdProducto == idProduct).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = oProduct });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = oProduct });

            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody] Product obj)
        {
            try
            {
                _bdContext.Products.Add(obj);
                _bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Product obj)
        {
            Product oProduct = _bdContext.Products.Find(obj.IdProducto);

            if (oProduct == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                oProduct.CodigoBarra = obj.CodigoBarra is null ? oProduct.CodigoBarra : obj.CodigoBarra;
                oProduct.Deseripcion = obj.Deseripcion is null ? oProduct.Deseripcion : obj.Deseripcion;
                oProduct.Marca = obj.Marca is null ? oProduct.Marca : obj.Marca;
                oProduct.Precio = obj.Precio is null ? oProduct.Precio : obj.Precio;


                _bdContext.Update(oProduct);
                _bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Product oProduct = _bdContext.Products.Find(id);

            if (oProduct == null)
            {
                return NotFound("Producto no encontrado");
            }

            try
            {
                _bdContext.Products.Remove(oProduct);
                _bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "Producto eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
